using System.ComponentModel.DataAnnotations;

namespace VillaApi.Models
{
    public class Villa
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int DisplayOrder { get; set; }
    }
}
