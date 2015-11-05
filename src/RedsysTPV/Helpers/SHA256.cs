using System;
using System.Security.Cryptography;
using System.Text;

namespace RedsysTPV.Helpers
{
    public static class SHA256
    {
        public static string HashHMAC(string data, string key)
        {
            key = key ?? "";
            var encoding = Encoding.GetEncoding(1252);
            byte[] keyByte = encoding.GetBytes(key);
            byte[] messageBytes = encoding.GetBytes(data);
            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
                return Convert.ToBase64String(hashmessage);
            }
        }
    }
}
