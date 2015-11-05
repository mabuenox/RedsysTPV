namespace RedsysTPV
{
    public class SignatureComparer : ISignatureComparer
    {
        public bool ValidateResponseSignature(string expectedSignature, string providedSignature)
        {
            providedSignature = providedSignature
               .Replace("_", "/")
               .Replace("-", "+");

            var isValidSignature = (providedSignature.Equals(expectedSignature));

            return isValidSignature;
        }
    }
}
