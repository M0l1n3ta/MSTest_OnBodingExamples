using System.ComponentModel;
using System.Runtime.Serialization;

namespace Prueba_1.Enums
{
    public enum DocumentTypeEnum
    {
        SendingReceipt = 1,
        PayoutReceipt = 2,
        RefundReceipt = 3
    }

    public enum ServiceResponseEnum
    {
        OK,
        KO
    }

    public enum ServiceModel
    {
        Soap,
        Rest
    }


    public enum DeliveryMethodsSupported
    {
        [Description("Office Pickup")]
        CashPickUp = 1,
        [Description("Bank Deposit")]
        BankDeposit = 2,
        [Description("Home Delivery")]
        HomeDelivery = 3,
        [Description("ATM Pickup")]
        ATMPickup = 32,
        [Description("Mobile Payment")]
        MobilePayment = 34,
        [Description("Government Contribution Plan")]
        GovernmentContributionPlan = 36
    }


    public enum DeliveryMethod
    {
        OfficePickUp = 1,
        ATM = 32,
        HomeDelivery = 3,
        BankDeposit = 2,
        MobilePayment = 34,
    }

    public enum ProductID
    {
        [EnumMember(Value = "C2C")]
        C2C = 111,
        [EnumMember(Value = "C2B")]
        C2B = 116,
        [EnumMember(Value = "B2B")]
        B2B = 117,
        [EnumMember(Value = "B2C")]
        B2C = 118
    }
}
