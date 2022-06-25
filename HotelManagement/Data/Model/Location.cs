using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement.Data.Model
{
    [Table("location")]
    public class Location
    {
        [Key]
        public int Id { get; set; }
        [Required, Column("state")]
        public string State { get; set; } = null!;
        [Column("district")]
        public string? District { get; set; }
        [Required, Column("city")]
        public string City { get; set; } = null!;
        [Required, Column("pincode")]
        public string? Pincode { get; set; }

    }
}
