using RedsysTPV.Models;

namespace RedsysTPV
{
    public interface IPaymentResponseService
    {
        ProcessedPayment GetProcessedPayment(string merchantParameters, string merchantKey, string platformSignature);
    }
}
