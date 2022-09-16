using System.ComponentModel.DataAnnotations;

namespace CoiNYC.Core.Data
{
    public abstract class Entity : IUniqueable
    {
        [Key]
        public virtual int Id { get; set; }

    }
}
