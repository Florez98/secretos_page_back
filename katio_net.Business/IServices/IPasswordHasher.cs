public interface IPasswordHasher
{
    string hash(string password);
    bool verify(string passwordhash ,string password);
}