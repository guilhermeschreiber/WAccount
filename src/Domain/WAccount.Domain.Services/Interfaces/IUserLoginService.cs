using WAccount.Domain.Models;

namespace WAccount.Domain.Services.Interfaces
{
    public interface IUserLoginService
    {
        public UserAccount Login(string email, string password);
    }
}
