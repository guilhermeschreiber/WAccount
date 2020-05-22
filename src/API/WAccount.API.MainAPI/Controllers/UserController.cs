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
        private IRepository<User> _userRepository;
        private readonly IUserLoginService _userLoginService;

        public UserController(IRepository<User> userRepository, IUserLoginService userLoginService)
        {
            _userRepository = userRepository;
            _userLoginService = userLoginService;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<User> GetAllUsers() => _userRepository.GetAll();

        [HttpGet]
        [Route("{userId}")]
        public User GetUserById(int userId) => _userRepository.GetById(userId);

        [HttpPost]
        [Route("")]
        public void AddUser([FromBody] User user) => _userRepository.Insert(user);

        [HttpDelete]
        [Route("{userId}")]
        public void DeleteUser(int userId) => _userRepository.Delete(userId);

        [HttpGet]
        [Route("Login")]
        public ActionResult Login(string email, string password)
        {
            if (_userLoginService.Login(email, password) == false)
            {
                return Unauthorized();
            }
            return Ok();
        }
    }
}
