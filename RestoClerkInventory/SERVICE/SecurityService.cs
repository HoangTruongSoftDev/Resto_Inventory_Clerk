using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography; // need this library to encrypt
namespace RestoClerkInventory.SERVICE
{
    public static class SecurityService
    {

        private const int SALT_SIZE = 16; // 128-bit cryptographic salt
        private const int KEY_SIZE = 32; // 256-bit cryptographic key
        private const int CRYPT_ITERATIONS = 100000; // iterations of key stretching
        private const char SEGMENT_DELIMITER = ':'; // separator of generated sections - DO NOT CHANGE (otherwise invalidated existing hashes)
        private static readonly HashAlgorithmName CRYPT_ALGORITHM = HashAlgorithmName.SHA256; // basic algorithm

        public static string HashPassword(string clearPassword)
        {
            // Check if the input password is null or empty
            if (string.IsNullOrEmpty(clearPassword))
            {
                return null;
            }

            // Generate a random salt
            byte[] salt = new byte[SALT_SIZE];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            // Create an instance of Rfc2898DeriveBytes with the clear password and salt
            var pbkdf2 = new Rfc2898DeriveBytes(clearPassword, salt, CRYPT_ITERATIONS, CRYPT_ALGORITHM);

            // Derive the key from the password and salt
            byte[] key = pbkdf2.GetBytes(KEY_SIZE);

            // Convert the key and salt bytes to hexadecimal strings
            string keyHex = BitConverter.ToString(key).Replace("-", "");
            string saltHex = BitConverter.ToString(salt).Replace("-", "");

            // Return the result as a concatenated string with delimiters
            return $"{keyHex}{SEGMENT_DELIMITER}{saltHex}{SEGMENT_DELIMITER}{CRYPT_ITERATIONS}{SEGMENT_DELIMITER}{CRYPT_ALGORITHM}";
        }

        public static byte[] FromHexString(string hex)
        {
            if (hex.Length % 2 != 0)
            {
                throw new ArgumentException("The input string must have an even number of characters.");
            }

            byte[] bytes = new byte[hex.Length / 2];
            for (int i = 0; i < hex.Length; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }

            return bytes;
        }
        public static bool VerifyPassword(string clearPassword, string hash)
        {
            string[] segments = hash.Split(SEGMENT_DELIMITER);

            if (segments.Length < 4)
            {
                // Invalid hash format
                return false;
            }

            byte[] key = FromHexString(segments[0]);
            byte[] salt = FromHexString(segments[1]);
            int iterations;
            if (!int.TryParse(segments[2], out iterations))
            {
                // Invalid iterations value
                return false;
            }

            string algorithmName = segments[3];
            HashAlgorithmName algorithm = new HashAlgorithmName(algorithmName);

            if (algorithm.Name != algorithmName)
            {
                // Invalid hash algorithm
                return false;
            }

            byte[] inputSecretKey = new Rfc2898DeriveBytes(clearPassword, salt, iterations, algorithm).GetBytes(key.Length);
            return key.SequenceEqual(inputSecretKey);
           
        }


    }
}