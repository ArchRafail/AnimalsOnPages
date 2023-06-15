using System.ComponentModel.DataAnnotations;

namespace AnimalsOnPages.Models
{
    public class ZooAnimal
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ZooId { get; set; }
        [Required]
        public Zoo Zoo { get; set; }
        [Required]
        public int AnimalId { get; set; }
        [Required]
        public Animal Animal { get; set; }
    }
}
