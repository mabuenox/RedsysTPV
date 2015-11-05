using Microsoft.VisualStudio.TestTools.UnitTesting;
using RedsysTPV.Models;
using System.Linq;

namespace RedsysTPV.Tests.Models
{
    [TestClass]
    public class ProcessedPaymentTests
    {
        [TestMethod]
        public void ProcessedPayment_ShouldNotHave_AnInvalidState()
        {
            ProcessedPayment processedPayment = new ProcessedPayment(Build.PaymentResponse(paid: true), false);
            Assert.IsFalse(processedPayment.IsPaymentPerformed.Any());
        }

        [TestMethod]
        public void ProcessedPayment_ShouldBePerformed_IfSignatureIsValidAndOrderHasBeenPaid()
        {
            ProcessedPayment processedPayment = new ProcessedPayment(Build.PaymentResponse(paid: true), true);
            Assert.IsTrue(processedPayment.IsPaymentPerformed.DefaultIfEmpty(false).Single());
        }

        [TestMethod]
        public void ProcessedPayment_ShouldNotBePerformed_IfSignatureIsValidAndOrderHasNotBeenPaid()
        {
            ProcessedPayment processedPayment = new ProcessedPayment(Build.PaymentResponse(paid: false), true);
            Assert.IsFalse(processedPayment.IsPaymentPerformed.DefaultIfEmpty(false).Single());
        }
    }
}
