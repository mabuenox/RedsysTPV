namespace RedsysTPV
{
    public interface ISignatureManager
    {
        string GetSignature(string merchantParameters, string merchantOrder, string merchantKey);
    }
}
