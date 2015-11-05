using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RedsysTPV.Tests
{
    [TestClass]
    public class SignatureComparerTests
    {
        [TestMethod]
        public void ValidateResponseSignature_ShouldReturnsTrue_WhenSignaturesAreEqual()
        {
            SignatureComparer signatureComparer = new SignatureComparer();
            var result = signatureComparer.ValidateResponseSignature("aaaa", "aaaa");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidateResponseSignature_ShouldReturnsFalse_WhenSignaturesAreDistinct()
        {
            SignatureComparer signatureComparer = new SignatureComparer();
            var result = signatureComparer.ValidateResponseSignature("aaaa", "bbb");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidateResponseSignature_ShouldReturnsTrue_WhenSignaturesAreEqualOnUTF8Mode()
        {
            SignatureComparer signatureComparer = new SignatureComparer();
            var result = signatureComparer.ValidateResponseSignature("oUIoxu1a8j8Cih01LvIfO46+yUbh3JjjAbj/y8+rlWQ=", "oUIoxu1a8j8Cih01LvIfO46-yUbh3JjjAbj_y8-rlWQ=");
            Assert.IsTrue(result);
        }
    }
}
