using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WAccount.Domain.Models;
using WAccount.Domain.Services.Interfaces;
using WAccount.Repositories.Infrastructure.Interfaces;

namespace WAccount.API.MainAPI.Controllers
{
    [Authorize("Bearer")]
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserAccountRepository _userAccountRepository;

        public UserController(IUserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
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

        [HttpPost]
        [Route("update")]
        public void UpdateUser([FromBody] UserAccount user) => _userAccountRepository.Update(user);

        [HttpDelete]
        [Route("{userId}")]
        public void DeleteUser(int userId) => _userAccountRepository.Delete(userId);
    }
}
