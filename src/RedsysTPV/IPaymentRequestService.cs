using RedsysTPV.Models;

namespace RedsysTPV
{
    public interface IPaymentRequestService
    {
        PaymentFormData GetPaymentRequestFormData(PaymentRequest paymentRequest, string merchantKey);
    }
}
