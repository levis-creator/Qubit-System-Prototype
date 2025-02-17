namespace QubitWith.Auth.Data.Persistence.Contracts
{
    public interface IAuthRepository
    {
        Task LogoutAsync();
    }
}
