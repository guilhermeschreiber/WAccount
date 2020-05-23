using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WAccount.Domain.Models;
using WAccount.Domain.Services.Interfaces;
using WAccount.Repositories.Infrastructure;
using WAccount.Repositories.Infrastructure.Interfaces;

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
                .GetWhere(x => x.Email == email && x.Password == password)
                .FirstOrDefault();
        }
    }
}
