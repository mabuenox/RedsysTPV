using System.Security.Cryptography;
using System.Text;

namespace RedsysTPV.Helpers
{
    public static class TripleDES
    {
        public static string Encrypt(string textKey, string content)
        {
            byte[] key = Encoding.GetEncoding(1252).GetBytes(textKey);
            byte[] iv = new byte[8];
            byte[] data = Encoding.GetEncoding(1252).GetBytes(content);
            byte[] enc = new byte[0];
            System.Security.Cryptography.TripleDES tdes = System.Security.Cryptography.TripleDES.Create();
            tdes.IV = iv;
            tdes.Key = key;
            tdes.Mode = CipherMode.CBC;
            tdes.Padding = PaddingMode.Zeros;
            ICryptoTransform ict = tdes.CreateEncryptor();
            enc = ict.TransformFinalBlock(data, 0, data.Length);
            return Encoding.GetEncoding(1252).GetString(enc);
        }
    }
}
