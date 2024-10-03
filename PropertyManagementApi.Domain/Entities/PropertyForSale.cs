using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PropertyManagementApi.Domain.Entities
{
    [Table("PropertyForSale")]
    public class PropertyForSale
    {
        [Key]
        public int SaleID { get; set; }

        [ForeignKey("Property")]
        public int PropertyID { get; set; }

        [ForeignKey("Owner")]
        public int OwnerID { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        public DateTime DateListed { get; set; }

        public bool IsActive { get; set; } = true;

        // Navigation Properties
        public Property Property { get; set; }
        public Owner Owner { get; set; }
    }
}
