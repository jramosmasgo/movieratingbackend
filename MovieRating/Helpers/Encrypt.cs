using Microsoft.Extensions.Configuration;
using System;
using System.Text;

namespace MovieRating.Helpers
{
    public static class Encrypt
    {

        public static string Key = "Sistem@s!0";

        public static string EncryptPassword(this string password)
        {
            if (string.IsNullOrEmpty(password)) return "";
            password += Key;
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(passwordBytes);
        }
        
        public static string DecryptPassword(this string passwordEncoded)
        {
            if (string.IsNullOrEmpty(passwordEncoded)) return "";
            var base64Encoded = Convert.FromBase64String(passwordEncoded);
            var result = Encoding.UTF8.GetString(base64Encoded);
            return result.Substring(0, result.Length - Key.Length);
        }
    }
}
