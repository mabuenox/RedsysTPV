using RedsysTPV.Models;
using Newtonsoft.Json;
using RedsysTPV.Helpers;

namespace RedsysTPV
{
    public class MerchantParametersManager : IMerchantParametersManager
    {
        public string GetMerchantParameters(PaymentRequest paymentRequest)
        {
            var json = JsonConvert.SerializeObject(paymentRequest,Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            return Base64.EncodeTo64(json);
        }

        public PaymentResponse GetPaymentResponse(string merchantParameters)
        {
            var json = Base64.DecodeFrom64(merchantParameters);
            return JsonConvert.DeserializeObject<PaymentResponse>(json);
        }
    }
}
