namespace WAccount.Domain.Services.Interfaces
{
    public interface IUserLoginService
    {
        public bool Login(string email, string password);
    }
}
