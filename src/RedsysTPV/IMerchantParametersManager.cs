using RedsysTPV.Models;

namespace RedsysTPV
{
    public interface IMerchantParametersManager
    {
        string GetMerchantParameters(PaymentRequest paymentRequest);
        PaymentResponse GetPaymentResponse(string merchantParameters);
    }
}
