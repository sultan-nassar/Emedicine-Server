using System.Security.Cryptography;
using System.Text;

namespace emedicine_api.Helpers
{
    public static class HashPassword
    {
        public static string HashedPassword(string password)
        {
            // Create a SHA256 object
            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute the hash of the password
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert the byte array to a hexadecimal string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
