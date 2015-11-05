namespace RedsysTPV
{
    public interface ISignatureComparer
    {
        bool ValidateResponseSignature(string expectedSignature, string providedSignature);
    }
}
