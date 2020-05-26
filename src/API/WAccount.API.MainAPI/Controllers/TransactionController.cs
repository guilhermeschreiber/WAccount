using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WAccount.Domain.Models;
using WAccount.Repositories.Infrastructure.Interfaces;

namespace WAccount.API.MainAPI.Controllers
{
    [Authorize("Bearer")]
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private ITransactionRepository _transactionRepository;

        public TransactionController(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        [HttpGet("{userId}")]
        [Produces(MediaTypeNames.Application.Json)]
        public IEnumerable<Transaction> GetTransactionByUser(int userId) => _transactionRepository.GetByUser(userId);

        [HttpPost("")]
        public void AddTransaction([FromBody] Transaction transaction) => _transactionRepository.Insert(transaction);
    }
}
