namespace RedsysTPV.Models
{
    public class PaymentRequest
    {
        public string Ds_Merchant_Amount { get; }
        public string Ds_Merchant_Order { get; }
        public string Ds_Merchant_MerchantCode { get; }
        public string Ds_Merchant_Currency { get; }
        public string Ds_Merchant_TransactionType { get; }
        public string Ds_Merchant_Terminal { get; }
        public string Ds_Merchant_MerchantURL { get; }
        public string Ds_Merchant_UrlOK { get; }
        public string Ds_Merchant_UrlKO { get; }

        public PaymentRequest(
            string Ds_Merchant_MerchantCode,
            string Ds_Merchant_Terminal,
            string Ds_Merchant_TransactionType,
            string Ds_Merchant_Amount,
            string Ds_Merchant_Currency,
            string Ds_Merchant_Order,
            string Ds_Merchant_MerchantURL,
            string Ds_Merchant_UrlOK,
            string Ds_Merchant_UrlKO)
        {
            this.Ds_Merchant_MerchantCode = Ds_Merchant_MerchantCode;
            this.Ds_Merchant_Terminal = Ds_Merchant_Terminal;
            this.Ds_Merchant_TransactionType = Ds_Merchant_TransactionType;
            this.Ds_Merchant_Amount = Ds_Merchant_Amount;
            this.Ds_Merchant_Currency = Ds_Merchant_Currency;
            this.Ds_Merchant_Order = Ds_Merchant_Order;
            this.Ds_Merchant_MerchantURL = Ds_Merchant_MerchantURL;
            this.Ds_Merchant_UrlOK = Ds_Merchant_UrlOK;
            this.Ds_Merchant_UrlKO = Ds_Merchant_UrlKO;
        }
    }
}
