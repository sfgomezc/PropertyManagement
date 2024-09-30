using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PropertyManagementApi.Models
{
    [Table("Property")]
    public class Property
    {
        [Key]
        public int PropertyID { get; set; }

        [Required]
        [MaxLength(255)]
        public string Address { get; set; }

        [Required]
        [MaxLength(100)]
        public string City { get; set; }

        [Required]
        [MaxLength(100)]
        public string State { get; set; }

        [Required]
        [MaxLength(20)]
        public string ZipCode { get; set; }

        public string Description { get; set; }

        // Navigation Properties
        public ICollection<PropertyForSale> PropertiesForSale { get; set; }
        public ICollection<PropertyImage> PropertyImages { get; set; }
        public ICollection<PropertyTrace> PropertyTraces { get; set; }
    }
}