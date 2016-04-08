namespace RedsysTPV.Models
{
    public class PaymentRequest
    {
        public string Ds_Merchant_Amount { get; set; }
        public string Ds_Merchant_Order { get; set; }
        public string Ds_Merchant_MerchantCode { get; set; }
        public string Ds_Merchant_Currency { get; set; }
        public string Ds_Merchant_TransactionType { get; set; }
        public string Ds_Merchant_Terminal { get; set; }
        public string Ds_Merchant_MerchantURL { get; set; }
        public string Ds_Merchant_UrlOK { get; set; }
        public string Ds_Merchant_UrlKO { get; set; }
        public string Ds_Merchant_Paymethods { get; set; }
        public string Ds_Merchant_Identifier { get; set; }
        public string Ds_Merchant_DirectPayment { get; set; }
     
    }
}
