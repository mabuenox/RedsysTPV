namespace RedsysTPV.Models
{
    public class PaymentFormData
    {
        public string Ds_SignatureVersion { get; set; }
        public string Ds_MerchantParameters { get; set; }
        public string Ds_Signature { get; set; }
    }
}
