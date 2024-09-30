using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PropertyManagementApi.Models
{
    [Table("PropertyImage")]
    public class PropertyImage
    {
        [Key]
        public int ImageID { get; set; }

        [ForeignKey("Property")]
        public int PropertyID { get; set; }

        [Required]
        public byte[] ImageData { get; set; } // Base64 string

        [MaxLength(255)]
        public string Description { get; set; }

        // Navigation Properties
        public Property Property { get; set; }
    }
}
