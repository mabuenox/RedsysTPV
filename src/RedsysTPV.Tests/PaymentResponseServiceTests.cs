using Microsoft.VisualStudio.TestTools.UnitTesting;
using RedsysTPV.Models;
using System.Linq;

namespace RedsysTPV.Tests
{
    [TestClass]
    public class PaymentResponseServiceTests
    {
        [TestMethod]
        public void GetProcessedPayment_ShouldWork_WhenSignatureIsValidAndPayIsPerformed()
        {
            var merchantParamenters = "eyJEc19EYXRlIjoiMTkvMDgvMjAxNSIsIkRzX0hvdXIiOiIxMjo0OSIsIkRzX0Ftb3VudCI6IjEyMzQ1IiwiRHNfQ3VycmVuY3kiOiI5NzgiLCJEc19PcmRlciI6Ijk5OTkxMTExMjIyMiIsIkRzX01lcmNoYW50Q29kZSI6IjAxMjM0NTYiLCJEc19UZXJtaW5hbCI6IjIiLCJEc19SZXNwb25zZSI6IjAiLCJEc19NZXJjaGFudERhdGEiOiIiLCJEc19TZWN1cmVQYXltZW50IjoiMSIsIkRzX1RyYW5zYWN0aW9uVHlwZSI6IjAiLCJEc19DYXJkX0NvdW50cnkiOiIiLCJEc19BdXRob3Jpc2F0aW9uQ29kZSI6IjAiLCJEc19Db25zdW1lckxhbmd1YWdlIjoiMCIsIkRzX0NhcmRfVHlwZSI6IkQifQ==";
            string merchantKey = "Mk9m98IfEblmPfrpsawt7BmxObt98Jev";
            string platformSignature = "UpSJaiLH6mMZZkXQAyMgImD4LaJZLInbHaN7zzKbYr4=";
        
            IPaymentResponseService paymentResponseService = new PaymentResponseService();
            ProcessedPayment result = paymentResponseService.GetProcessedPayment(merchantParamenters, merchantKey, platformSignature);

            Assert.IsTrue(result.IsValidSignature == true);
            Assert.IsTrue(result.IsPaymentPerformed.DefaultIfEmpty(false).Single());
            Assert.IsNotNull(result.PaymentResponse);
            Assert.IsTrue(result.PaymentResponse.Ds_Amount == "12345");
            Assert.IsTrue(result.PaymentResponse.Ds_AuthorisationCode == "0");
            Assert.IsTrue(result.PaymentResponse.Ds_Card_Country == "");
            Assert.IsTrue(result.PaymentResponse.Ds_Card_Type == "D");
            Assert.IsTrue(result.PaymentResponse.Ds_ConsumerLanguage == "0");
            Assert.IsTrue(result.PaymentResponse.Ds_Currency == "978");
            Assert.IsTrue(result.PaymentResponse.Ds_Date == "19/08/2015");
            Assert.IsTrue(result.PaymentResponse.Ds_Hour == "12:49");
            Assert.IsTrue(result.PaymentResponse.Ds_MerchantCode == "0123456");
            Assert.IsTrue(result.PaymentResponse.Ds_MerchantData == "");
            Assert.IsTrue(result.PaymentResponse.Ds_Order == "999911112222");
            Assert.IsTrue(result.PaymentResponse.Ds_Response == "0");
            Assert.IsTrue(result.PaymentResponse.Ds_SecurePayment == "1");
            Assert.IsTrue(result.PaymentResponse.Ds_Terminal == "2");
            Assert.IsTrue(result.PaymentResponse.Ds_TransactionType == "0");
        }

        [TestMethod]
        public void GetProcessedPayment_ShouldWork_WhenSignatureIsNotValid()
        {
            var merchantParamenters = "eyJEc19EYXRlIjoiMTkvMDgvMjAxNSIsIkRzX0hvdXIiOiIxMjo0OSIsIkRzX0Ftb3VudCI6IjEyMzQ1IiwiRHNfQ3VycmVuY3kiOiI5NzgiLCJEc19PcmRlciI6Ijk5OTkxMTExMjIyMiIsIkRzX01lcmNoYW50Q29kZSI6IjAxMjM0NTYiLCJEc19UZXJtaW5hbCI6IjIiLCJEc19SZXNwb25zZSI6IjAiLCJEc19NZXJjaGFudERhdGEiOiIiLCJEc19TZWN1cmVQYXltZW50IjoiMSIsIkRzX1RyYW5zYWN0aW9uVHlwZSI6IjAiLCJEc19DYXJkX0NvdW50cnkiOiIiLCJEc19BdXRob3Jpc2F0aW9uQ29kZSI6IjAiLCJEc19Db25zdW1lckxhbmd1YWdlIjoiMCIsIkRzX0NhcmRfVHlwZSI6IkQifQ==";
            string merchantKey = "Mk9m98IfEblmPfrpsawt7BmxObt98Jev";
            string platformSignature = "xxxxxx";

            IPaymentResponseService paymentResponseService = new PaymentResponseService();
            ProcessedPayment result = paymentResponseService.GetProcessedPayment(merchantParamenters, merchantKey, platformSignature);

            Assert.IsTrue(result.IsValidSignature == false);
            Assert.IsFalse(result.IsPaymentPerformed.Any());
        }

        [TestMethod]
        public void GetProcessedPayment_ShouldWork_WhenSignatureIsValidAndPayIsNotPerformed()
        {
            var merchantParamenters = "eyJEc19EYXRlIjoiMTkvMDgvMjAxNSIsIkRzX0hvdXIiOiIxMjo0OSIsIkRzX0Ftb3VudCI6IjEyMzQ1IiwiRHNfQ3VycmVuY3kiOiI5NzgiLCJEc19PcmRlciI6Ijk5OTkxMTExMjIyMiIsIkRzX01lcmNoYW50Q29kZSI6IjAxMjM0NTYiLCJEc19UZXJtaW5hbCI6IjIiLCJEc19SZXNwb25zZSI6IjEwMSIsIkRzX01lcmNoYW50RGF0YSI6IiIsIkRzX1NlY3VyZVBheW1lbnQiOiIxIiwiRHNfVHJhbnNhY3Rpb25UeXBlIjoiMCIsIkRzX0NhcmRfQ291bnRyeSI6IiIsIkRzX0F1dGhvcmlzYXRpb25Db2RlIjoiMCIsIkRzX0NvbnN1bWVyTGFuZ3VhZ2UiOiIwIiwiRHNfQ2FyZF9UeXBlIjoiRCJ9";
            string merchantKey = "Mk9m98IfEblmPfrpsawt7BmxObt98Jev";
            string platformSignature = "iRNNn9pg2j6LIaLtlm15998hp/li7e2ptwVyfmO5JAY=";

            IPaymentResponseService paymentResponseService = new PaymentResponseService();
            ProcessedPayment result = paymentResponseService.GetProcessedPayment(merchantParamenters, merchantKey, platformSignature);

            Assert.IsTrue(result.IsValidSignature == true);
            Assert.IsFalse(result.IsPaymentPerformed.DefaultIfEmpty(false).Single());
            Assert.IsNotNull(result.PaymentResponse);
            Assert.IsTrue(result.PaymentResponse.Ds_Amount == "12345");
            Assert.IsTrue(result.PaymentResponse.Ds_AuthorisationCode == "0");
            Assert.IsTrue(result.PaymentResponse.Ds_Card_Country == "");
            Assert.IsTrue(result.PaymentResponse.Ds_Card_Type == "D");
            Assert.IsTrue(result.PaymentResponse.Ds_ConsumerLanguage == "0");
            Assert.IsTrue(result.PaymentResponse.Ds_Currency == "978");
            Assert.IsTrue(result.PaymentResponse.Ds_Date == "19/08/2015");
            Assert.IsTrue(result.PaymentResponse.Ds_Hour == "12:49");
            Assert.IsTrue(result.PaymentResponse.Ds_MerchantCode == "0123456");
            Assert.IsTrue(result.PaymentResponse.Ds_MerchantData == "");
            Assert.IsTrue(result.PaymentResponse.Ds_Order == "999911112222");
            Assert.IsTrue(result.PaymentResponse.Ds_Response == "101");
            Assert.IsTrue(result.PaymentResponse.Ds_SecurePayment == "1");
            Assert.IsTrue(result.PaymentResponse.Ds_Terminal == "2");
            Assert.IsTrue(result.PaymentResponse.Ds_TransactionType == "0");
        }
    }
}
