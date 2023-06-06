using System.ComponentModel.DataAnnotations;

namespace AnimalsOnPages.Dtos
{
    public class AnimalDto
    {
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string? Sex { get; set; }
        public string? Rank { get; set; }
        [Required]
        public string Sound { get; set; }
        public string? CoverColor { get; set; }
    }
}
