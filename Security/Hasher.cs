using System.Security.Cryptography;
using System.Text;

namespace Common.Security;

public static class Hasher
{
    public static string GetHash(string input)
    {
        using var sha256 = SHA256.Create();

        byte[] encoding = Encoding.UTF8.GetBytes(input);
        byte[] hash = sha256.ComputeHash(encoding);

        StringBuilder output = new StringBuilder();

        for (int i = 0; i < hash.Length; i++)
        {
            output.Append(hash[i].ToString("x2"));
        }

        return output.ToString();
    }

    public static string GetHash(string input, string salt)
    {
        input = string.Concat(input, salt);

        return GetHash(input);
    }
}