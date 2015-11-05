using RedsysTPV.Helpers;

namespace RedsysTPV
{
    public class SignatureManager : ISignatureManager
    {
        public string GetSignature(string merchantParameters, string merchantOrder, string merchantKey)
        {
            // Se genera una clave específica por operación. Para obtener la clave derivada a utilizar en una operación se debe realizar un cifrado 3DES entre la clave del comercio y el valor del número de pedido de la operación (Ds_Merchant_Order).
            var key = Base64.DecodeFrom64(merchantKey);
            var operationKey = TripleDES.Encrypt(key, merchantOrder);

            // Se calcula el HMAC SHA256 del valor del parámetro Ds_MerchantParameters y la clave obtenida en el paso anterior.
            var hash = SHA256.HashHMAC(merchantParameters, operationKey);
            return hash;
        }
    }
}
