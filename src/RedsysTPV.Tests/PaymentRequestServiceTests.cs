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
            PaymentRequest paymentRequest = new PaymentRequest(
                "999008881",
                "871",
                "0",
                "145",
                "978",
                "19990000000A",
                "",
                "",
                ""
                );
            IPaymentRequestService paymentRequestService = new PaymentRequestService();
            var result = paymentRequestService.GetPaymentRequestFormData(paymentRequest, merchantKey);

            Assert.IsTrue(result.Ds_SignatureVersion == "HMAC_SHA256_V1");
            Assert.IsTrue(result.Ds_MerchantParameters == "eyJEc19NZXJjaGFudF9BbW91bnQiOiIxNDUiLCJEc19NZXJjaGFudF9PcmRlciI6IjE5OTkwMDAwMDAwQSIsIkRzX01lcmNoYW50X01lcmNoYW50Q29kZSI6Ijk5OTAwODg4MSIsIkRzX01lcmNoYW50X0N1cnJlbmN5IjoiOTc4IiwiRHNfTWVyY2hhbnRfVHJhbnNhY3Rpb25UeXBlIjoiMCIsIkRzX01lcmNoYW50X1Rlcm1pbmFsIjoiODcxIiwiRHNfTWVyY2hhbnRfTWVyY2hhbnRVUkwiOiIiLCJEc19NZXJjaGFudF9VcmxPSyI6IiIsIkRzX01lcmNoYW50X1VybEtPIjoiIn0=");
            Assert.IsTrue(result.Ds_Signature == "MAlGASPeuqCw4K4ZMNIR343ljOoEAmH7B5woby1kcbs=");
        }

    }
}
