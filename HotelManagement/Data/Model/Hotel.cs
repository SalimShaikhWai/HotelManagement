using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement.Data.Model
{
    [Table("hotel")]
    public class Hotel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(name: "name", TypeName = "varchar")]
        public string Name { get; set; } = null!;
        [Required]
        [Column(name:"city",TypeName ="varchar")]
        public string City { get; set; } = null!;

        [Required,Column(name:"location",TypeName ="varchar")]
        public string Location { get; set; } = null!;
    }
}
