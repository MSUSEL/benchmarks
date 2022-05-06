﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Funq;
using ServiceStack.Configuration;
using ServiceStack.FluentValidation;
using ServiceStack.FluentValidation.Results;
using ServiceStack.FluentValidation.Validators;
using ServiceStack.Text;
using ServiceStack.Web;

namespace ServiceStack.Validation
{
    public class ValidationFeature : IPlugin, IAfterInitAppHost, Model.IHasStringId
    {
        public string Id { get; set; } = Plugins.Validation;
        public Func<IRequest, ValidationResult, object, object> ErrorResponseFilter { get; set; }

        public bool ScanAppHostAssemblies { get; set; } = true;
        public bool TreatInfoAndWarningsAsErrors { get; set; } = true;
        public bool EnableDeclarativeValidation { get; set; } = true;

        public string AccessRole { get; set; } = RoleNames.Admin;
        
        public IValidationSource ValidationSource { get; set; } 
        
        public Dictionary<Type, string[]> ServiceRoutes { get; set; } = new Dictionary<Type, string[]> {
            { typeof(GetValidationRulesService), new []{ "/" + "validation/rules".Localize() + "/{Type}" } },
            { typeof(ModifyValidationRulesService), new []{ "/" + "validation/rules".Localize() } },
        };

        /// <summary>
        /// Specify default ErrorCodes to use when custom validation conditions are invalid
        /// </summary>
        public Dictionary<string, string> ConditionErrorCodes => Validators.ConditionErrorCodes;

        /// <summary>
        /// Specify default Error Messages to use when Validators with these ErrorCode's are invalid
        /// </summary>
        public Dictionary<string, string> ErrorCodeMessages => Validators.ErrorCodeMessages;
        
        /// <summary>
        /// Activate the validation mechanism, so every request DTO with an existing validator
        /// will be validated.
        /// </summary>
        /// <param name="appHost">The app host</param>
        public void Register(IAppHost appHost)
        {
            if (TreatInfoAndWarningsAsErrors)
            {
                if (!appHost.GlobalRequestFiltersAsync.Contains(ValidationFilters.RequestFilterAsync))
                {
                    appHost.GlobalRequestFiltersAsync.Add(ValidationFilters.RequestFilterAsync);
                }

                if (!appHost.GlobalMessageRequestFiltersAsync.Contains(ValidationFilters.RequestFilterAsync))
                {
                    appHost.GlobalMessageRequestFiltersAsync.Add(ValidationFilters.RequestFilterAsync);
                }
            }
            else
            {
                if (!appHost.GlobalRequestFiltersAsync.Contains(ValidationFilters.RequestFilterAsyncIgnoreWarningsInfo))
                {
                    appHost.GlobalRequestFiltersAsync.Add(ValidationFilters.RequestFilterAsyncIgnoreWarningsInfo);
                }

                if (!appHost.GlobalMessageRequestFiltersAsync.Contains(ValidationFilters.RequestFilterAsyncIgnoreWarningsInfo))
                {
                    appHost.GlobalMessageRequestFiltersAsync.Add(ValidationFilters.RequestFilterAsyncIgnoreWarningsInfo);
                }
                
                if (!appHost.GlobalResponseFiltersAsync.Contains(ValidationFilters.ResponseFilterAsync))
                {
                    appHost.GlobalResponseFiltersAsync.Add(ValidationFilters.ResponseFilterAsync);
                }

                if (!appHost.GlobalMessageResponseFiltersAsync.Contains(ValidationFilters.ResponseFilterAsync))
                {
                    appHost.GlobalMessageResponseFiltersAsync.Add(ValidationFilters.ResponseFilterAsync);
                }
            }

            if (ValidationSource != null)
            {
                appHost.Register(ValidationSource);
                ValidationSource.InitSchema();
            }

            var container = appHost.GetContainer();
            var hasValidationSource = ValidationSource != null || container.Exists<IValidationSource>(); 
            if (hasValidationSource && AccessRole != null)
            {
                foreach (var registerService in ServiceRoutes)
                {
                    appHost.RegisterService(registerService.Key, registerService.Value);
                }
            }

            if (ScanAppHostAssemblies)
            {
                container.RegisterValidators(((ServiceStackHost)appHost).ServiceAssemblies.ToArray());
            }
        }

        public void AfterInit(IAppHost appHost)
        {
            if (EnableDeclarativeValidation)
            {
                var container = appHost.GetContainer();
                var hasDynamicRules = ValidationSource != null || container.Exists<IValidationSource>(); 
                
                foreach (var op in appHost.Metadata.Operations)
                {
                    var hasValidateRequestAttrs = Validators.HasValidateRequestAttributes(op.RequestType);
                    if (hasValidateRequestAttrs)
                    {
                        Validators.RegisterRequestRulesFor(op.RequestType);
                        op.AddRequestTypeValidationRules(Validators.GetTypeRules(op.RequestType));
                    }
                        
                    var hasValidateAttrs = Validators.HasValidateAttributes(op.RequestType);
                    if (hasDynamicRules || hasValidateAttrs)
                    {
                        container.RegisterNewValidatorIfNotExists(op.RequestType);
                        op.AddRequestPropertyValidationRules(Validators.GetPropertyRules(op.RequestType));
                    }
                }
            }
        }

        /// <summary>
        /// Override to provide additional/less context about the Service Exception. 
        /// By default the request is serialized and appended to the ResponseStatus StackTrace.
        /// </summary>
        public virtual string GetRequestErrorBody(object request)
        {
            var requestString = "";
            try
            {
                requestString = TypeSerializer.SerializeToString(request);
            }
            catch /*(Exception ignoreSerializationException)*/
            {
                //Serializing request successfully is not critical and only provides added error info
            }

            return $"[{GetType().GetOperationName()}: {DateTime.UtcNow}]:\n[REQUEST: {requestString}]";
        }
    }

    [DefaultRequest(typeof(GetValidationRules))]
    public class GetValidationRulesService : Service
    {
        public IValidationSource ValidationSource { get; set; }
        public async Task<object> Any(GetValidationRules request)
        {
            var feature = HostContext.AssertPlugin<ValidationFeature>();
            RequestUtils.AssertAccessRole(base.Request, accessRole: feature.AccessRole, authSecret: request.AuthSecret);

            var type = HostContext.Metadata.FindDtoType(request.Type);
            if (type == null)
                throw HttpError.NotFound(request.Type);
            
            return new GetValidationRulesResponse {
                Results = await ValidationSource.GetAllValidateRulesAsync(request.Type),
            };
        }
    }

    [DefaultRequest(typeof(ModifyValidationRules))]
    public class ModifyValidationRulesService : Service
    {
        public IValidationSource ValidationSource { get; set; }

        public async Task Any(ModifyValidationRules request)
        {
            var appHost = HostContext.AssertAppHost();
            var container = appHost.GetContainer();
            var feature = appHost.AssertPlugin<ValidationFeature>();
            RequestUtils.AssertAccessRole(base.Request, accessRole: feature.AccessRole, authSecret: request.AuthSecret);

            var utcNow = DateTime.UtcNow;
            var userName = base.GetSession().GetUserAuthName();
            var rules = request.SaveRules;

            if (!rules.IsEmpty())
            {
                foreach (var rule in rules)
                {
                    if (rule.Type == null)
                        throw new ArgumentNullException(nameof(rule.Type));
                
                    if (rule.CreatedBy == null)
                    {
                        rule.CreatedBy = userName;
                        rule.CreatedDate = utcNow;
                    }
                    rule.ModifiedBy = userName;
                    rule.ModifiedDate = utcNow;
                }

                await ValidationSource.SaveValidationRulesAsync(rules);
            }

            if (!request.SuspendRuleIds.IsEmpty())
            {
                var suspendRules = await ValidationSource.GetValidateRulesByIdsAsync(request.SuspendRuleIds);
                foreach (var suspendRule in suspendRules)
                {
                    suspendRule.SuspendedBy = userName;
                    suspendRule.SuspendedDate = utcNow;
                }

                await ValidationSource.SaveValidationRulesAsync(suspendRules);
            }

            if (!request.UnsuspendRuleIds.IsEmpty())
            {
                var unsuspendRules = await ValidationSource.GetValidateRulesByIdsAsync(request.UnsuspendRuleIds);
                foreach (var unsuspendRule in unsuspendRules)
                {
                    unsuspendRule.SuspendedBy = null;
                    unsuspendRule.SuspendedDate = null;
                }

                await ValidationSource.SaveValidationRulesAsync(unsuspendRules);
            }

            if (!request.DeleteRuleIds.IsEmpty())
            {
                await ValidationSource.DeleteValidationRulesAsync(request.DeleteRuleIds.ToArray());
            }
        }
    }

    public static class ValidationExtensions
    {
        public static HashSet<Type> RegisteredDtoValidators { get; } = new HashSet<Type>();
        
        /// <summary>
        /// Auto-scans the provided assemblies for a <see cref="IValidator"/>
        /// and registers it in the provided IoC container.
        /// </summary>
        /// <param name="container">The IoC container</param>
        /// <param name="assemblies">The assemblies to scan for a validator</param>
        public static void RegisterValidators(this Container container, params Assembly[] assemblies)
        {
            RegisterValidators(container, ReuseScope.None, assemblies);
        }

        public static void RegisterValidators(this Container container, ReuseScope scope, params Assembly[] assemblies)
        {
            foreach (var assembly in assemblies)
            {
                foreach (var validator in assembly.GetTypes()
                    .Where(t => t.IsOrHasGenericInterfaceTypeOf(typeof(IValidator<>))))
                {
                    container.RegisterValidator(validator, scope);
                }
            }
        }

        public static void RegisterValidator(this Container container, Type validator, ReuseScope scope=ReuseScope.None)
        {
            var baseType = validator.BaseType;
            if (validator.IsInterface || baseType == null)
                return;

            while (baseType != null && !baseType.IsGenericType)
            {
                baseType = baseType.BaseType;
            }

            if (baseType == null)
                return;

            var dtoType = baseType.GetGenericArguments()[0];
            var validatorType = typeof(IValidator<>).MakeGenericType(dtoType);

            container.RegisterAutoWiredType(validator, validatorType, scope);

            Validators.RegisterPropertyRulesFor(dtoType);
            RegisteredDtoValidators.Add(dtoType);
        }

        internal static void RegisterNewValidatorIfNotExists(this Container container, Type requestType)
        {
            // We only need to register a new a Validator if it doesn't already exist for the Type 
            if (!RegisteredDtoValidators.Contains(requestType))
            {
                var typeValidator = typeof(DefaultValidator<>).MakeGenericType(requestType);
                container.RegisterValidator(typeValidator);
            }
        }

        public static bool HasAsyncValidators(this IValidator validator, ValidationContext context, string ruleSet=null)
        {
            if (validator is IEnumerable<IValidationRule> rules)
            {
                foreach (var rule in rules)
                {
                    if (ruleSet != null && rule.RuleSets != null && !rule.RuleSets.Contains(ruleSet))
                        continue;

                    if (rule.Validators.Any(x => x is AsyncPredicateValidator || x is AsyncValidatorBase ||  x.ShouldValidateAsync(context)))
                        return true;
                }
            }
            return false;
        }
    }
}
