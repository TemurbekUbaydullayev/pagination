using System.Security.Cryptography;
using System.Text;

namespace ForUserApi.Common.Security;

public class PasswordHasher
{
    private static readonly string _key = "d9b4f349-17a5-4125-aa1b-197cbc542090";

    public static string GetHash(string password, out string salt)
    {
        salt = GenerateSalt();

        var pass = password + salt + _key;

        return GeneratedHash(pass);
    }

    public static bool IsEqual(string registerPassword, string loginPassword, string salt)
    {
        var password = loginPassword + salt + _key;

        return registerPassword == GeneratedHash(password);
    }

    private static string GeneratedHash(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = Encoding.UTF8.GetBytes(password);

            byte[] hash = sha256.ComputeHash(bytes);

            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                stringBuilder.Append(hash[i].ToString("x2"));
            }

            return stringBuilder.ToString();
        }
    }

    private static string GenerateSalt()
        => Guid.NewGuid().ToString();
}
