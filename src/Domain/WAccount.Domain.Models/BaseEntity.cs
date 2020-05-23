using System;
using System.ComponentModel.DataAnnotations.Schema;
using WAccount.Domain.Models.Interfaces;

namespace WAccount.Domain.Models
{
    public abstract class BaseEntity : IEntity
    {
        public int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime UpdatedAt { get; set; }
    }
}
