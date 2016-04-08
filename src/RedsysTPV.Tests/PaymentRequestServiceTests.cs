using Microsoft.VisualStudio.TestTools.UnitTesting;
using RedsysTPV.Models;

namespace RedsysTPV.Tests
{
    [TestClass]
    public class PaymentRequestServiceTests
    {
        [TestMethod]
        public void GetPaymentRequestFormData_ShouldWork()
        {
            string merchantKey = "Mk9m98IfEblmPfrpsawt7BmxObt98Jev";
            PaymentRequest paymentRequest = new PaymentRequest()
            {
                Ds_Merchant_MerchantCode = "999008881",
                Ds_Merchant_Terminal = "871",
                Ds_Merchant_TransactionType = "0",
                Ds_Merchant_Amount = "145",
                Ds_Merchant_Currency = "978",
                Ds_Merchant_Order = "19990000000A",
                Ds_Merchant_MerchantURL = "",
                Ds_Merchant_UrlOK = "",
                Ds_Merchant_UrlKO = "",
                Ds_Merchant_Paymethods = ""
            };
            var paymentRequestService = new PaymentRequestService();
            var result = paymentRequestService.GetPaymentRequestFormData(paymentRequest, merchantKey);

            Assert.AreEqual("HMAC_SHA256_V1",result.Ds_SignatureVersion);
            Assert.AreEqual("eyJEc19NZXJjaGFudF9BbW91bnQiOiIxNDUiLCJEc19NZXJjaGFudF9PcmRlciI6IjE5OTkwMDAwMDAwQSIsIkRzX01lcmNoYW50X01lcmNoYW50Q29kZSI6Ijk5OTAwODg4MSIsIkRzX01lcmNoYW50X0N1cnJlbmN5IjoiOTc4IiwiRHNfTWVyY2hhbnRfVHJhbnNhY3Rpb25UeXBlIjoiMCIsIkRzX01lcmNoYW50X1Rlcm1pbmFsIjoiODcxIiwiRHNfTWVyY2hhbnRfTWVyY2hhbnRVUkwiOiIiLCJEc19NZXJjaGFudF9VcmxPSyI6IiIsIkRzX01lcmNoYW50X1VybEtPIjoiIiwiRHNfTWVyY2hhbnRfUGF5bWV0aG9kcyI6IiJ9", result.Ds_MerchantParameters);
            Assert.AreEqual("C0SX1YRif9SHf7xPFkHARvicQokK/fvOK0K3KlT+XRw=", result.Ds_Signature);
        }
        
    }
}
