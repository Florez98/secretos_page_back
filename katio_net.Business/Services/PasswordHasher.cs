using System.Collections;
using System.Security.Cryptography;


namespace katio.Business.Services;

public class PasswordHasher : IPasswordHasher
{
    private const int SaltSize = 128 / 8;
    private const int KeySize = 256 / 8;

    private const int Iterations = 1000;
    private const char Delimitador = ';';

    private static readonly HashAlgorithmName _hashAlgorithmName = HashAlgorithmName.SHA256; 
    public string hash(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(SaltSize);
        var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, _hashAlgorithmName, KeySize);

        return string.Join(Delimitador, Convert.ToBase64String(salt),Convert.ToBase64String(hash));
    }

    public bool verify(string passwordhash, string inputPassword)
    {
        var elements = passwordhash.Split(Delimitador);
        var salt = Convert.FromBase64String(elements[0]);
        var hash = Convert.FromBase64String(elements[1]);

        var hashInput = Rfc2898DeriveBytes.Pbkdf2(inputPassword, salt, Iterations, _hashAlgorithmName, KeySize);
        return StructuralComparisons.StructuralEqualityComparer.Equals(hash, hashInput);
        
    }
}