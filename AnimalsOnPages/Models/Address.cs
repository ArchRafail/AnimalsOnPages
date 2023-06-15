using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimalsOnPages.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public int? PostalCode { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public int Building { get; set; }
        public Zoo Zoo { get; set; }
    }
}
