using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement.Data.Model
{

    [Table("room")]
    public class Room
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column("type_ref_id")]
        public string TypeRefId { get; set; } = null!;
        [Required]
        [Column("rent")]
        public float Rent { get; set; }
        [Required,Column("status")]
        public bool Status { get; set; }

    }
}
