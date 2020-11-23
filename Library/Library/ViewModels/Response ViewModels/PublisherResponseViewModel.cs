using System.ComponentModel.DataAnnotations;

namespace Library.ViewModels.ResponseViewModels
{
    public class PublisherResponseViewModel
    {
        public int Id { get; set; }

        [MaxLength(255)]
        [Required]
        public string Name { get; set; }
    }
}
