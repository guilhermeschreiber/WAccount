using System;
using System.Collections.Generic;
using System.Text;
using WAccount.Domain.Models;
using WAccount.Repositories.Infrastructure.Interfaces;

namespace WAccount.Repositories.Infrastructure
{
    public class UserAccountRepository : Repository<UserAccount>, IUserAccountRepository
    {
        public UserAccountRepository(DatabaseContext context) : base(context) { }
    }
}
