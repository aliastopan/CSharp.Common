namespace Common.Security;

public sealed class SaltGenerator
{
    private const string ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXY";
    private const string NUMERIC = "0123456789";
    private static Random _rng = new Random();

    public static string Generate(int length)
    {
        var salt = new char[length];

        for (int i = 0; i < length; i++)
        {
            if(_rng.Next(100) < 50)
            {
                salt[i] = ALPHABET[_rng.Next(ALPHABET.Length - 1)];
                salt[i] = _rng.Next(100) < 50
                    ? salt[i] = Char.ToLower(salt[i])
                    : salt[i];
            }
            else
            {
                salt[i] = NUMERIC[_rng.Next(NUMERIC.Length - 1)];
            }
        }

        return new string(salt);
    }
}