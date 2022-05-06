﻿using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace StackExchange.Opserver.Data.SQL.QueryPlans
{
    public partial class ShowPlanXML
    {
        [XmlIgnore]
        public List<BaseStmtInfoType> Statements
        {
            get
            {
                if (BatchSequence == null) return new List<BaseStmtInfoType>();
                return BatchSequence.SelectMany(bs =>
                        bs.SelectMany(b => b.Items?.SelectMany(bst => bst.Statements))
                    ).ToList();
            }
        }
    }

    public partial class BaseStmtInfoType
    {
        public virtual IEnumerable<BaseStmtInfoType> Statements
        {
            get { yield return this; }
        }

        public bool IsMinor
        {
            get {
                switch (StatementType)
                {
                    case "COND":
                    case "RETURN NONE":
                        return true;
                }
                return false;
            }
        }

        private const string declareFormat = "Declare {0} {1} = {2};";
        private static readonly Regex emptyLineRegex = new Regex(@"^\s+$[\r\n]*", RegexOptions.Compiled | RegexOptions.Multiline);
        private static readonly Regex initParamsTrimRegex = new Regex(@"^\s*(begin|end)\s*", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private static readonly Regex paramRegex = new Regex(@"^\(( [^\(\)]* ( ( (?<Open>\() [^\(\)]* )+ ( (?<Close-Open>\)) [^\(\)]* )+ )* (?(Open)(?!)) )\)", RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace);
        private static readonly Regex paramSplitRegex = new Regex(@",(?=[@])", RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace);
        private static readonly char[] startTrimChars = new[] { '\n', '\r', ';' };

        public string ParameterDeclareStatement
        {
            get
            {
                //TODO: Cross-statement vars declared in an assign, used later
                return this is StmtSimpleType ss ? GetDeclareStatement(ss.QueryPlan) : "";
            }
        }

        public string StatementTextWithoutInitialParams
        {
            get
            {
                //TODO: Pair these down, seeing what looks good for now
                return this is StmtSimpleType ss ? emptyLineRegex.Replace(paramRegex.Replace(ss.StatementText ?? "", ""), "").Trim().TrimStart(startTrimChars) : "";
            }
        }

        public string StatementTextWithoutInitialParamsTrimmed
        {
            get
            {
                var orig = StatementTextWithoutInitialParams;
                return orig?.Length == 0 ? string.Empty : initParamsTrimRegex.Replace(orig, string.Empty).Trim();
            }
        }

        private string GetDeclareStatement(QueryPlanType queryPlan)
        {
            if (queryPlan?.ParameterList == null || queryPlan.ParameterList.Length == 0) return "";

            var result = StringBuilderCache.Get();
            var paramTypeList = paramRegex.Match(StatementText);
            if (!paramTypeList.Success) return "";
            // TODO: get test cases and move this to a single multi-match regex
            var paramTypes = paramSplitRegex.Split(paramTypeList.Groups[1].Value).Select(p => p.Split(StringSplits.Space));

            foreach (var p in queryPlan.ParameterList)
            {
                var paramType = paramTypes.FirstOrDefault(pt => pt[0] == p.Column);
                if (paramType != null)
                {
                    result.AppendFormat(declareFormat, p.Column, paramType[1], p.ParameterCompiledValue)
                          .AppendLine();
                }
            }
            return result.Length > 0 ? result.Insert(0, "-- Compiled Params\n").ToStringRecycle() : result.ToStringRecycle();
        }
    }

    public partial class StmtCondType
    {
        public override IEnumerable<BaseStmtInfoType> Statements
        {
            get
            {
                yield return this;
                if (Then?.Statements != null)
                {
                    foreach (var s in Then.Statements.Items) yield return s;
                }
                if (Else?.Statements != null)
                {
                    foreach (var s in Else.Statements.Items) yield return s;
                }
            }
        }
    }
}
