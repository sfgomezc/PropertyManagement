using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PropertyManagementApi.Models
{
    [Table("Owner")]
    public class Owner
    {
        [Key]
        public int OwnerID { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [MaxLength(20)]
        public string ContactNumber { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        // Navigation Properties
        public ICollection<PropertyForSale> PropertiesForSale { get; set; }
    }
}
