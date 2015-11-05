using System;

namespace RedsysTPV.Models
{
    public class ProcessedPayment
    {
        public bool IsValidSignature { get; }
        public Maybe<bool> IsPaymentPerformed { get; }
        public PaymentResponse PaymentResponse { get; }
        

        public ProcessedPayment(PaymentResponse paymentResponse, bool isValidSignature)
        {
            IsValidSignature = isValidSignature;
            IsPaymentPerformed = CheckPayment(paymentResponse, IsValidSignature);
            PaymentResponse = paymentResponse;
        }

        private Maybe<bool> CheckPayment(PaymentResponse paymentResponse, bool isValidSignature)
        {
            Maybe<bool> result = new Maybe<bool>();

            if (isValidSignature)
            {
                if (Convert.ToInt32(paymentResponse.Ds_Response) == 0)
                {
                    result = new Maybe<bool>(true);
                }
                else
                {
                    result = new Maybe<bool>(false);
                }
            }

            return result;
        }

    }
}
