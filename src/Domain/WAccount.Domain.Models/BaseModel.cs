
using WAccount.Domain.Models.Interfaces;

namespace WAccount.Domain.Models
{
    public abstract class BaseModel : IEntity
    {
        public int Id { get; set; }
    }
}
