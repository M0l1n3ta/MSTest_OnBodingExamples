//using Application.DTO.CustomersManagement;
using Prueba_1.Enums;
using AutoFixture;
using System;
using System.Collections.Generic;

namespace Prueba_1.Models
{
	public class TestDataDTO
	{
		public string CallerCorrelationId { get; set; }
		public string CallID { get; set; }
		public string Environment { get; set; }
		public ServiceModel ServiceType { get; set; }
		public Setting Settings { get; set; }
		public string AgentId { get; set; }
		public decimal TodaysRate { get; set; }
		public string AgentCustID { get; set; }
		public string BankID { get; set; }
		public string TransRefID { get; set; }
		public string BankAccountNo { get; set; }
		public string BankRoutingCode { get; set; }
		public string BankBranchName { get; set; }
		public string BankBranchNo { get; set; }
		public string BankBranchCity { get; set; }
		public string SendingBranchNo { get; set; }
		public string BankRoutingType { get; set; }
		public string BIC_SWIFT { get; set; }
		public string CountryFrom { get; set; }
		public string CountryTo { get; set; }
		public string PaymentCurrency { get; set; }
		public decimal PaymentAmount { get; set; }
		public string BeneficiaryCurrency { get; set; }
		public decimal BeneficiaryAmount { get; set; }
		public DeliveryMethod DeliveryMethod { get; set; }
		public string CityName { get; set; }
		public int? ItemsPerPage { get; set; }
		public int? PageNoDesired { get; set; }
		public string StateName { get; set; }
		public string CorrespNo { get; set; }
		public string PayingCorrespNo { get; set; }
		public string CorrespId { get; set; }
		public string PayingCorrespId { get; set; }
		public int CorrespLocID { get; set; }
		public int PayingCorrespLocID { get; set; }
		public string AmountType { get; set; }
		public string CustEmployerName { get; set; }
		public string CustFirstName { get; set; }
		public string CustMiddleName { get; set; }
		public string CustLastName2 { get; set; }
		public string CustLastName { get; set; }
		public string CustPhoneNo { get; set; }
		public string CustAddress { get; set; }
		public string CustCity { get; set; }
		public string RiaCustID { get; set; }
		public string CustState { get; set; }
		public string CustCountry { get; set; }
		public string CustDateBirth { get; set; }
		public string CustOccupation { get; set; }
		public string CustSourceFunds { get; set; }
		public string CustBeneRelationship { get; set; }
		public string CustPhoneCountryCode { get; set; }
		public string CustTaxID { get; set; }
		public string CustID { get; set; }
		public string CustTypeID { get; set; }
		public string CustTaxCountry { get; set; }
		public string CustZipCode { get; set; }
		public string CustCellCountryCode { get; set; }
		public string CustCellNo { get; set; }
		public string CustEmailAddress { get; set; }
		public string CustNationality { get; set; }
		public string CustEntityName { get; set; }
		public string CustDateOfIncorporation { get; set; }
		public string CustIndustryCategoryID { get; set; }
		public string CustIndustrySubCategoryID { get; set; }
		public string CustCountryOfBirth { get; set; }
		public string CustStateOfBirth { get; set; }
		public string CustCityOfBirth { get; set; }
		public string CustCountryofResidence { get; set; }
		public string CustMotherName { get; set; }
		public string CustFatherName { get; set; }
		public string CustGender { get; set; }
		public string BeneFirstName { get; set; }
		public string BeneMiddleName { get; set; }
		public string BeneLastName { get; set; }
		public string BeneLastName2 { get; set; }
		public string BeneCountryOfBirth { get; set; }
		public string BeneNationality { get; set; }
		public string BeneCityOfBirth { get; set; }
		public string BeneIDIssueDate { get; set; }
		public string BeneCountry { get; set; }
		public string BeneEntityName { get; set; }
		public string BeneIndustryCategoryID { get; set; }
		public string BeneIndustrySubCategoryID { get; set; }
		public string BeneDateOfIncorporation { get; set; }
		public string BeneDateOfBirth { get; set; }
		public string BeneOccupation { get; set; }
		public string BeneAddress { get; set; }
		public string BenePostalCode { get; set; }
		public string BeneMessage { get; set; }
		public string BeneTelNo { get; set; }
		public string BenePhoneNo { get; set; }
		public string BeneCellNo { get; set; }
		public string BeneCity { get; set; }
		public string BeneState { get; set; }
		public string BeneIDType { get; set; }
		public int BeneTypeID { get; set; }
		public string BenID { get; set; }
		public string AgentBeneID { get; set; }
		public string BeneIDNumber { get; set; }
		public string BeneIDNo { get; set; }
		public string BeneIDIssuedBy { get; set; }
		public string BeneIDIssuedByCountry { get; set; }
		public string BeneIDIssuedByState { get; set; }
		public string BeneIDExpirationDate { get; set; }
		public string BeneEmailAddress { get; set; }
		public string Valuetype { get; set; }
		public string TransferReason { get; set; }
		public int? TransferReasonID { get; set; }
		public int? CustBusinessSectorID { get; set; }
		public int OrderId { get; set; }
		public string OrderStatus { get; set; } = "Status";
		public string PCOrderNo { get; set; }
		public string SCOrderNo { get; set; }
		public string PaymentReferenceNumber { get; set; }
		public string PIN { get; set; }
		public string PmtInstruction { get; set; }
		public string SalesDate { get; set; }
		public string RefundPIN { get; set; }
		public string RiaAPIversion { get; set; }
		public string Promocode { get; set; }
		public string MobileWalletAccountNo { get; set; }
		public string ReceiptType { get; set; }
		public string Template { get; set; }
		public string ReleaseType { get; set; }
		public string ReportDate { get; set; }
		public bool OnHold { get; set; }
		public bool ExpectedStagedOrder { get; set; } = false;
		public string UnitaryBankAccountNo { get; set; }
		public string CustBankAccountNo { get; set; }
		public string CustUnitaryType { get; set; } = "IBAN";
		public string UnitaryType { get; set; }
		public string BankAccountCountry { get; set; }
		public string BankAccountType { get; set; } = "Checking";
		//public CustomerRequest.RequestElement Customer { get; set; }
		public IdentityDocuments IdentityDocument { get; set; } = new IdentityDocuments();
		public BeneIDImage BeneIdentityDocumentImages { get; set; }
		public QuestionsAnswer QuestionsAnswers { get; set; }
		public int PayingCorrespSeqID { get; set; }
		public Dictionary<string, decimal> Layouts { get; set; }
		public List<Filter> Filters { get; set; }
		public string DirectRequest { get; set; }
		public string ErrorMessageToMatch { get; set; }
		public int ProductItemID { get; set; }
		public int CustPaymentMethodID { get; set; }
		public ProductID ProductID { get; set; } = ProductID.C2C;
		public int MapID { get; set; }
		public string BankName { get; set; }
		public bool CancelOrder { get; set; } = true;
		public int CancelationReasonID { get; set; } = 50;
		public bool IndicativeRate { get; set; }
		public string QuestionIDs { get; set; }
		public string Answers { get; set; }
		public List<string> ErrorMessagesValidation { get; set; } = new List<string>();

		#region Sikhona
		public int PromoterID { get; set; }
		public int ManagerID { get; set; }
		public int PaymentPartnerID { get; set; }
		public float AgentCommissionAmount { get; set; }
		public decimal CommissionAmount { get; set; }
		public string CommissionCurrency { get; set; }
		public float AgentCommissionAmountUSD { get; set; }
		public float PaymentPartnerCostAmount { get; set; }
		public float PaymentPartnerCostAmountUSD { get; set; }
		public float MasterAgentCommissionAmount { get; set; }
		public float MasterAgentCommissionAmountUSD { get; set; }
		public bool DownloadOrders { get; set; } = false;
		#endregion

		#region Classes
		public class Filter
		{
			public string PropertyName { get; set; } = "onHold";
			public string PropertyValue { get; set; } = "false";
		}

		public class IdentityDocuments
		{
			public string CustID1Type { get; set; }
			public string CustID1IssuedByCountry { get; set; }
			public string CustID1IssuedByState { get; set; }
			public string CustID1IssuedBy { get; set; }
			public string CustID1No { get; set; }
			public string CustID1ExpDate { get; set; }
			public string CustID1IssuedDate { get; set; }
			public IdentityDocumentImage CustIdentityDocumentImages { get; set; }
		}
		public class BeneIDImage
		{
			public List<IdentityDocumentImageElement> BeneIdentityDocumentImage { get; set; } = new List<IdentityDocumentImageElement>();
		}
		public class IdentityDocumentImage
		{
			public List<IdentityDocumentImageElement> CustIdentityDocumentImage { get; set; }

		}
		public class IdentityDocumentImageElement
		{
			public byte[] IdentityDocumentImage { get; set; }
			public string ImageContentType { get; set; }
			public string ImageAgentPath { get; set; }
			public string ImageName { get; set; }
		}
		public class QuestionsAnswer
		{
			public List<QuestionAnswerElement> QuestionAnswer { get; set; } = new List<QuestionAnswerElement>();
		}
		public class QuestionAnswerElement
		{
			public int QuestionID { get; set; }
			public string Answer { get; set; }
		}
		public class Setting
		{
			public SendingAgent SendingAgentSettings { get; set; }
			public List<PayingAgent> PayingAgentSettings { get; set; } = new List<PayingAgent>();
		}
		public class SendingAgent
		{
			public List<CommonSettings> CommonSettings { get; set; } = new List<CommonSettings>();
			public List<ExportSettings> ExportSettings { get; set; } = new List<ExportSettings>();
		}
		public class PayingAgent
		{
			public string SettingValue { get; set; }
			public int SettingType { get; set; }
		}
		public class CommonSettings
		{
			public int SettingValue { get; set; }
			public int SettingType { get; set; }
			public int SettingDesc { get; set; }
		}
		public class ExportSettings
		{
			public int SettingValue { get; set; }
			public int SettingId { get; set; }
		}
		public decimal CreateRandomPaymentAmount()
		{
			Random rnd = new Random();
			return rnd.Next(10, 30);
		}

		public void SetRandomBeneficiaryName(string identifierPrefix = "Auto_")
		{
			var fixture = new Fixture();
			BeneFirstName = fixture.Create(identifierPrefix).Substring(0, 15);
			BeneLastName = fixture.Create(identifierPrefix).Substring(0, 15);
		}

		public decimal CreateRandomPaymentAmountWithDecimals()
		{
			Random rnd = new Random();
			decimal dc = rnd.Next(1000, 3000);
			return dc / 100;
		}

		public decimal CreateRandomPaymentAmountWithDecimals(decimal paymentAmount)
		{
			var minimumAmount = 0M;
			var amount = GenereateRandomNumberWithDecimals(paymentAmount);
			if (PaymentCurrency.Equals("XOF") && BeneficiaryCurrency.Equals("XOF"))
				minimumAmount = 350M;
			if (amount < 0.9M)
			{
				amount += 0.5M;
			}
			return amount + minimumAmount;
		}

		private decimal GenereateRandomNumberWithDecimals(decimal paymentAmount)
		{
			Random rnd = new Random();
			decimal dc = Convert.ToDecimal(rnd.NextDouble());
			var amount = decimal.Round((paymentAmount * dc), 2);
			return amount;
		}

		#endregion
	}
}


