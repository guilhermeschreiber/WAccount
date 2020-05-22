using WAccount.Repositories.Infrastructure;

namespace WAccount.Domain.Services
{
    public abstract class BaseService
    {
        public DatabaseContext Context { get; set; }

        public BaseService (DatabaseContext context)
        {
            Context = context;
        }
    }
}
