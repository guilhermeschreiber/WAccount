using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WAccount.Domain.Models;
using WAccount.Repositories.Infrastructure.Interfaces;

namespace WAccount.API.MainAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IRepository<User> _userRepository;

        public UserController(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
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
    }
}
