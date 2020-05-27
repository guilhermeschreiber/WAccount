using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WAccount.Domain.Models
{
    public class UserAccount : BaseEntity
    {
        public ICollection<Transaction> Transactions { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public decimal Balance { get; set; }

        public decimal MonthlyIncome { get; set; }
    }
}
