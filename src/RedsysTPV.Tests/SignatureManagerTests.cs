using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RedsysTPV.Tests
{
    [TestClass]
    public class SignatureManagerTests
    {
        [TestMethod]
        public void GetSignature_ShouldWork()
        {
            string merchantParameters = "eyJEc19NZXJjaGFudF9BbW91bnQiOiIxNDUiLCJEc19NZXJjaGFudF9PcmRlciI6IjE5OTkwMDAwMDAwQSIsIkRzX01lcmNoYW50X01lcmNoYW50Q29kZSI6Ijk5OTAwODg4MSIsIkRzX01lcmNoYW50X0N1cnJlbmN5IjoiOTc4IiwiRHNfTWVyY2hhbnRfVHJhbnNhY3Rpb25UeXBlIjoiMCIsIkRzX01lcmNoYW50X1Rlcm1pbmFsIjoiODcxIiwiRHNfTWVyY2hhbnRfTWVyY2hhbnRVUkwiOiIiLCJEc19NZXJjaGFudF9VcmxPSyI6IiIsIkRzX01lcmNoYW50X1VybEtPIjoiIn0=";
            string merchantOrder = "19990000000A";
            string merchantKey = "Mk9m98IfEblmPfrpsawt7BmxObt98Jev";
           
            ISignatureManager signatureManager = new SignatureManager();
            var result = signatureManager.GetSignature(merchantParameters, merchantOrder, merchantKey);
            Assert.IsTrue(result == "MAlGASPeuqCw4K4ZMNIR343ljOoEAmH7B5woby1kcbs=");
        }

        [TestMethod]
        public void GetSignature_ShouldWork_2()
        {
            string merchantParameters = "eyJEc19NZXJjaGFudF9BbW91bnQiOiIxNDUiLCJEc19NZXJjaGFudF9PcmRlciI6Ijk5OTkxMTExMTExMSIsIkRzX01lcmNoYW50X01lcmNoYW50Q29kZSI6Ijk5OTAwODg4MSIsIkRzX01lcmNoYW50X0N1cnJlbmN5IjoiOTc4IiwiRHNfTWVyY2hhbnRfVHJhbnNhY3Rpb25UeXBlIjoiMCIsIkRzX01lcmNoYW50X1Rlcm1pbmFsIjoiODcxIiwiRHNfTWVyY2hhbnRfTWVyY2hhbnRVUkwiOiIiLCJEc19NZXJjaGFudF9VcmxPSyI6IiIsIkRzX01lcmNoYW50X1VybEtPIjoiIn0=";
            string merchantOrder = "999911111111";
            string merchantKey = "Mk9m98IfEblmPfrpsawt7BmxObt98Jev";

            ISignatureManager signatureManager = new SignatureManager();
            var result = signatureManager.GetSignature(merchantParameters, merchantOrder, merchantKey);
            Assert.IsTrue(result == "nGLmVWiI78Yf9fKUFh/70sSJ7S55idKI6FWgh2MkIDY=");
        }

    }
}
