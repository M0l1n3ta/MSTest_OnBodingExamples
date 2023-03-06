using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Prueba_1.Models
{
    [Serializable()]
    [XmlRoot(ElementName = "Order")]
    public class InputOrder
    {
       

		public string OrderId { get; set; }
		public int PayingCorrespSeqID { get; set; }
		public string SalesDate { get; set; }
		public string SalesTime { get; set; }
        public string CountryFrom { get ; set ; }
        public string CountryTo { get ; set ; }

		/*
			<SendingCorrespBranchNo>agent</SendingCorrespBranchNo>
			<PayingCorrespLocID>120526111</PayingCorrespLocID>
			<PmtInstruction>Pay</PmtInstruction>
			<BeneficiaryCurrency>INR</BeneficiaryCurrency>
			<BeneficiaryAmount>1000.00</BeneficiaryAmount>
			<DeliveryMethod>34</DeliveryMethod>
			<PaymentCurrency>ZAR</PaymentCurrency>
			<PaymentAmount>211.37</PaymentAmount>
			<CustChargeCurrency>ZAR</CustChargeCurrency>
			<CustChargeAmount>0.00</CustChargeAmount>
			<BeneFirstName>VIRENDRA Mark</BeneFirstName>
			<BeneLastName>KUMAR Gary</BeneLastName>
			<BeneCity>City</BeneCity>
			<BeneState>State</BeneState>
			<BeneCountry>IN</BeneCountry>
			<BenePhoneNo>123456789</BenePhoneNo>
			<RiaCustID>77753720</RiaCustID>
			<CustFirstName>Kiriko</CustFirstName>
			<CustLastName>Verwatch</CustLastName>
			<CustAddress>Street</CustAddress>
			<CustCity>City</CustCity>
			<CustState>Gauteng</CustState>
			<CustCountry>ZA</CustCountry>
			<CustCellNo>27810181611</CustCellNo>
			<CustID1Type>ASYLUM_PAPER</CustID1Type>
			<CustID1No>202210181611432</CustID1No>
			<CustCountryOfBirth>HK</CustCountryOfBirth>
			<CustDateBirth>20001018</CustDateBirth>
			<CustBeneRelationship>Other</CustBeneRelationship>
			<TransferReason>Gift</TransferReason>
			<MobileWalletAccountNo>8447161075</MobileWalletAccountNo>
         * */
		public InputOrder(XElement c)
        {
			OrderId = (string)c.Element("OrderNo").Value;
			PayingCorrespSeqID = int.Parse(c.Element("PayingCorrespSeqID").Value);
			SalesDate = (string)c.Element("SalesDate").Value;
			CountryFrom = (string)c.Element("CountryFrom").Value;
			CountryTo = (string)c.Element("CountryTo").Value;

		}
	}
}
