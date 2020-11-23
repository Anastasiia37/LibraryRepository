using System.ComponentModel.DataAnnotations;

namespace Library.ViewModels.RequestViewModels
{
    public class CountryRequestViewModel
    {
        public int Id { get; set; }

        [MaxLength(255)]
        [Required]
        public string Name { get; set; }
    }
}
