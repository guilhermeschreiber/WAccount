using WAccount.Domain.Models;

namespace WAccount.Domain.Services.Interfaces
{
    public interface IBankAccountService
    {
        public bool UpdateBalanceDaily();
    }
}
