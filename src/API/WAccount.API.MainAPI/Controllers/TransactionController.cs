using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WAccount.Domain.Models;
using WAccount.Repositories.Infrastructure.Interfaces;

namespace WAccount.API.MainAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private ITransactionRepository _transactionRepository;

        public TransactionController(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        [Authorize("Bearer")]
        [HttpGet("{userId}")]
        public Transaction GetTransactionByUser(int userId) => _transactionRepository.GetByUser(userId);

        [Authorize("Bearer")]
        [HttpPost("")]
        public void AddTransaction([FromBody] Transaction transaction) => _transactionRepository.Insert(transaction);

        [Authorize("Bearer")]
        [HttpPost("update")]
        public void UpdateTransaction([FromBody] Transaction transaction) => _transactionRepository.Update(transaction);
    }
}
