using RedsysTPV.Models;

namespace RedsysTPV
{
    public class PaymentRequestService : IPaymentRequestService
    {
        protected readonly IMerchantParametersManager merchantParamentersManager;
        protected readonly ISignatureManager signatureManager;

        public PaymentRequestService()
        {
            merchantParamentersManager = new MerchantParametersManager();
            signatureManager = new SignatureManager();
        }
        public PaymentFormData GetPaymentRequestFormData(PaymentRequest paymentRequest, string merchantKey)
        {
            PaymentFormData result = new PaymentFormData();

            result.Ds_SignatureVersion = "HMAC_SHA256_V1";
            result.Ds_MerchantParameters = merchantParamentersManager.GetMerchantParameters(paymentRequest);
            result.Ds_Signature = signatureManager.GetSignature(result.Ds_MerchantParameters, paymentRequest.Ds_Merchant_Order, merchantKey);

            return result;
        }
    }
}
