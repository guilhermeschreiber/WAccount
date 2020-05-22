using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WAccount.Domain.Services.Interfaces;
using WAccount.Repositories.Infrastructure;

namespace WAccount.Domain.Services
{
    public class UserLoginService : BaseService, IUserLoginService
    {
        public UserLoginService(DatabaseContext context) : base(context) { }
        public bool Login(string email, string password)
        {
            var v = Context.Users.Where(x => x.Email.Equals(email) && x.Password.Equals(password)).FirstOrDefault();
            return v != null;
        }
    }
}
