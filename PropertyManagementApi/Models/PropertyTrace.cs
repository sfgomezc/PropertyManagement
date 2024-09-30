using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PropertyManagementApi.Models
{
    [Table("PropertyTrace")]
    public class PropertyTrace
    {
        [Key]
        public int TraceID { get; set; }

        [ForeignKey("Property")]
        public int PropertyID { get; set; }

        [ForeignKey("PropertyForSale")]
        public int SaleID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Status { get; set; } // e.g., "Listed", "Sold"

        [Required]
        public DateTime ChangeDate { get; set; }

        public string Remarks { get; set; }

        // Navigation Properties
        public Property Property { get; set; }
        public PropertyForSale PropertyForSale { get; set; }
    }
}
