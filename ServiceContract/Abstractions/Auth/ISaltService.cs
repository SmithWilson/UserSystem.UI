namespace ServiceContract.Abstractions.Auth
{
    public interface ISaltService
    {
        string Generate();

        string Hash(string password, string salt);
    }
}
