using RedsysTPV.Models;

namespace RedsysTPV
{
    public class PaymentResponseService : IPaymentResponseService
    {
        protected readonly IMerchantParametersManager merchantParamentersManager;
        protected readonly ISignatureManager signatureManager;
        protected readonly ISignatureComparer signatureComparer;

        public PaymentResponseService()
        {
            merchantParamentersManager = new MerchantParametersManager();
            signatureManager = new SignatureManager();
            signatureComparer = new SignatureComparer();
        }

        public ProcessedPayment GetProcessedPayment(string merchantParameters, string merchantKey, string providedSignature)
        {
            var paymentResponse = merchantParamentersManager.GetPaymentResponse(merchantParameters);
            var expectedSignature = signatureManager.GetSignature(merchantParameters, paymentResponse.Ds_Order, merchantKey);
            var isValidSignature = signatureComparer.ValidateResponseSignature(expectedSignature, providedSignature);
            var result = new ProcessedPayment(paymentResponse, isValidSignature);
            return result;
        }

    }
}
