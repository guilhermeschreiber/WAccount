using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
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

        public UserController(IUserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
        }

        [Authorize("Bearer")]
        [HttpGet]
        [Route("")]
        public IEnumerable<UserAccount> GetAllUsers() => _userAccountRepository.GetAll();

        [Authorize("Bearer")]
        [HttpGet]
        [Route("{userId}")]
        public UserAccount GetUserById(int userId) => _userAccountRepository.GetById(userId);

        [Authorize("Bearer")]
        [HttpPost]
        [Route("")]
        public void AddUser([FromBody] UserAccount user) => _userAccountRepository.Insert(user);

        [Authorize("Bearer")]
        [HttpPost]
        [Route("update")]
        public void UpdateUser([FromBody] UserAccount user) => _userAccountRepository.Update(user);

        [Authorize("Bearer")]
        [HttpDelete]
        [Route("{userId}")]
        public void DeleteUser(int userId) => _userAccountRepository.Delete(userId);
    }
}
