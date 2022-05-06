﻿using System.Threading.Tasks;
using Bit.Core.Models.Table;
using Bit.Core.Models.Business;
using Bit.Core.Enums;

namespace Bit.Core.Services
{
    public interface IPaymentService
    {
        Task CancelAndRecoverChargesAsync(ISubscriber subscriber);
        Task<string> PurchaseOrganizationAsync(Organization org, PaymentMethodType paymentMethodType,
            string paymentToken, Models.StaticStore.Plan plan, short additionalStorageGb, short additionalSeats,
            bool premiumAccessAddon);
        Task<string> UpgradeFreeOrganizationAsync(Organization org, Models.StaticStore.Plan plan,
           short additionalStorageGb, short additionalSeats, bool premiumAccessAddon);
        Task<string> PurchasePremiumAsync(User user, PaymentMethodType paymentMethodType, string paymentToken,
            short additionalStorageGb);
        Task<string> AdjustStorageAsync(IStorableSubscriber storableSubscriber, int additionalStorage, string storagePlanId);
        Task CancelSubscriptionAsync(ISubscriber subscriber, bool endOfPeriod = false,
            bool skipInAppPurchaseCheck = false);
        Task ReinstateSubscriptionAsync(ISubscriber subscriber);
        Task<bool> UpdatePaymentMethodAsync(ISubscriber subscriber, PaymentMethodType paymentMethodType,
            string paymentToken, bool allowInAppPurchases = false);
        Task<bool> CreditAccountAsync(ISubscriber subscriber, decimal creditAmount);
        Task<BillingInfo> GetBillingAsync(ISubscriber subscriber);
        Task<SubscriptionInfo> GetSubscriptionAsync(ISubscriber subscriber);
    }
}
