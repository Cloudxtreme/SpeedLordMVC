
namespace SpeedLord.Interfaces.Repositories
{
    public interface IAccountRepository
    {
        bool LoginUser(string userName, string password);
        bool RegisterUser(string userName, string password, string matchPassword);
        bool ChangePassword(string userName, string password, string matchPassword);
    }
}
