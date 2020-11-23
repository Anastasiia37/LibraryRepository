using System.ComponentModel.DataAnnotations;

namespace Library.DAL.Entities
{
    public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}
