using System.Linq;
using WAccount.Domain.Models;
using WAccount.Domain.Services.Interfaces;
using WAccount.Repositories.Infrastructure.Interfaces;
using WAccount.Shared;

namespace WAccount.Domain.Services
{
    public class UserLoginService : IUserLoginService
    {
        private readonly IUserAccountRepository _userAccountRepository;

        public UserLoginService(IUserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
        }

        public UserAccount Login(string email, string password)
        {
            return _userAccountRepository
                .GetWhere(x => x.Email == email && x.Password == MD5Hash.GetHash(password))
                .FirstOrDefault();
        }
    }
}
