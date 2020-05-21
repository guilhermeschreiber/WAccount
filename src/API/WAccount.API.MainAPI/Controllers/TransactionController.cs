﻿using System.Collections.Generic;
using System.Threading.Tasks;
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

        [HttpGet("")]
        public IEnumerable<Transaction> GetAllTransactions() => _transactionRepository.GetAll();

        [HttpGet("{userId}")]
        public Task<Transaction> GetTransactionByUser(int userId) => _transactionRepository.GetByUser(userId);

        [HttpPost("")]
        public void AddTransaction([FromBody] Transaction transaction) => _transactionRepository.Insert(transaction);
    }
}
