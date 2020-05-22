using WAccount.Domain.Models;

namespace WAccount.Domain.Services.Interfaces
{
    public interface IBankAccountService
    {
        public void UpdateBalance(User user);
    }
}
