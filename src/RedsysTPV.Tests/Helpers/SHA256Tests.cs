using Microsoft.VisualStudio.TestTools.UnitTesting;
using RedsysTPV.Helpers;

namespace RedsysTPV.Tests.Helpers
{
    [TestClass]
    public class SHA256Tests
    {
        [TestMethod]
        public void HashHMAC_ShouldWork()
        {
            var result = SHA256.HashHMAC("abcdefg", "12345678901234");
            Assert.IsTrue(result == "ljGdvKkYI4CzuasiUiLM81CAW1zIz31yo8lajNOxGz8=");
        }
    }
}