using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace Tami.Pago.Core
{
    public static class CryptoHelper
    {
        public static string GetPagoHash(string input)
        {
            using SHA256 sha256 = SHA256.Create();
            byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
            string sha256Base64 = Convert.ToBase64String(hash);
            return sha256Base64;
        }

        #region SECURITY_HASH_V2
        public static string GenerateJWKSignature(long merchantNumber, long terminalNumber, string secretKey, string input, string fixedKidValue, string fixedKValue)
        {
            var jwkResource = GetJWKResource(merchantNumber, terminalNumber, secretKey, fixedKidValue, fixedKValue);

            var header = new Dictionary<string, object>
            {
                { "kid", jwkResource.Kid },
                { "typ", "JWT" },
                { "alg", "HS512" }
            };

            var headerBytes = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(header));
            var headerBase64 = Base64UrlEncoder.Encode(headerBytes);

            var payloadBase64 = Base64UrlEncoder.Encode(Encoding.UTF8.GetBytes(input));

            var dataToSign = $"{headerBase64}.{payloadBase64}";
            var signature = ComputeHmacSha512(
                Convert.FromBase64String(jwkResource.K),
                Encoding.UTF8.GetBytes(dataToSign)
            );
            var signatureBase64 = Base64UrlEncoder.Encode(signature);

            return $"{headerBase64}.{payloadBase64}.{signatureBase64}";
        }

        private static string GenerateKidValue(string secretKey, string fixedKidValue)
        {
            using SHA512 sha512 = SHA512.Create();
            string input = secretKey + fixedKidValue;
            byte[] hash = sha512.ComputeHash(Encoding.UTF8.GetBytes(input));
            return Convert.ToBase64String(hash);
        }

        private static string GenerateKValue(long merchantNumber, long terminalNumber, string secretKey, string fixedKValue)
        {
            using SHA512 sha512 = SHA512.Create();
            var input = secretKey + fixedKValue + merchantNumber + terminalNumber;
            byte[] hash = sha512.ComputeHash(Encoding.UTF8.GetBytes(input));
            return Convert.ToBase64String(hash);
        }

        private static JWKResource GetJWKResource(long merchantNumber, long terminalNumber, string secretKey, string fixedKidValue, string fixedKValue)
        {
            return new JWKResource
            {
                Kid = GenerateKidValue(secretKey, fixedKidValue),
                K = GenerateKValue(merchantNumber, terminalNumber, secretKey, fixedKValue)
            };
        }

        private static byte[] ComputeHmacSha512(byte[] key, byte[] data)
        {
            using var hmac = new HMACSHA512(key);
            return hmac.ComputeHash(data);
        }
        #endregion
    }

}
