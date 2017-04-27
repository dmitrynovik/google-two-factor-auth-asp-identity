using System;

namespace AspNetGoogleAuth
{
    internal static class Base32Encoder
    {
        internal static string Encode(byte[] secretKey)
        {
            return Convert.ToBase64String(secretKey);
        }

        public static byte[] Decode(string encodedKey)
        {
            return Convert.FromBase64String(encodedKey);
        }
    }
}