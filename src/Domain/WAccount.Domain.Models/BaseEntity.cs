
using WAccount.Domain.Models.Interfaces;

namespace WAccount.Domain.Models
{
    public class BaseEntity : IEntity
    {
        public int Id { get; set; }
    }
}
