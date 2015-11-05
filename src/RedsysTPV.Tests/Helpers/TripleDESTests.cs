using Microsoft.VisualStudio.TestTools.UnitTesting;
using RedsysTPV.Helpers;

namespace RedsysTPV.Tests.Helpers
{
    [TestClass]
    public class TripleDESTests
    {
        [TestMethod]
        public void Encrypt_ShouldWork()
        {
            var key = Base64.DecodeFrom64("Mk9m98IfEblmPfrpsawt7BmxObt98Jev");
            var result = TripleDES.Encrypt(key, "abcdefg");
            var base64Result = Base64.EncodeTo64(result);
            Assert.IsTrue(base64Result == "kQG+7RwPCZo=");
        }
    }
}
