using System.ComponentModel.DataAnnotations;

namespace Library.DAL.Entities
{
    public class Country : EntityBase
    {
        [StringLength(255)]
        [Required]
        public string Name { get; set; }
    }
}
