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
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [Required]
        public TransactionType Type { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public int Amount { get; set; }

        public DateTime Scheduling { get; set; }
        
        public DateTime LastChange { get; set; }
        public TransactionResult Result { get; set; }
    }
}
