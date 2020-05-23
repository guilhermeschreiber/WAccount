using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WAccount.Domain.Models;
using WAccount.Domain.Services.Interfaces;
using WAccount.Repositories.Infrastructure.Interfaces;

namespace WAccount.API.MainAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserAccountRepository _userAccountRepository;
        private readonly IUserLoginService _userLoginService;

        public UserController(IUserAccountRepository userAccountRepository, IUserLoginService userLoginService)
        {
            _userAccountRepository = userAccountRepository;
            _userLoginService = userLoginService;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<UserAccount> GetAllUsers() => _userAccountRepository.GetAll();

        [HttpGet]
        [Route("{userId}")]
        public UserAccount GetUserById(int userId) => _userAccountRepository.GetById(userId);

        [HttpPost]
        [Route("")]
        public void AddUser([FromBody] UserAccount user) => _userAccountRepository.Insert(user);

        [HttpDelete]
        [Route("{userId}")]
        public void DeleteUser(int userId) => _userAccountRepository.Delete(userId);

        [HttpGet]
        [Route("Login")]
        public UserAccount Login(string email, string password) => _userLoginService.Login(email, password);
    }
}
