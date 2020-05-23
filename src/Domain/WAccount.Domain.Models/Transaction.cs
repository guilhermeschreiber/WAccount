using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WAccount.Domain.Models.Enumerators;

namespace WAccount.Domain.Models
{
    public class Transaction : BaseEntity
    {
        [Required]
        public int UserId { get; set; }
        public virtual UserAccount User { get; set; }

        [Required]
        public TransactionType Type { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Scheduling { get; set; }

        public TransactionResult Result { get; set; }
    }
}
