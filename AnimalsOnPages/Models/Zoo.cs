using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimalsOnPages.Models
{
    public class Zoo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [ForeignKey("Address")]
        public int AddressId { get; set; }
        [Required]
        public Address Address { get; set; }
        public ICollection<Animal>? Animals { get; set; }
    }
}
