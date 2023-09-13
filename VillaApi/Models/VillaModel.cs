using System.ComponentModel.DataAnnotations;

namespace VillaApi.Models
{
    public class VillaModel
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
    }
}
