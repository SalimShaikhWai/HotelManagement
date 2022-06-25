namespace HotelManagement.Data.DTO
{
    public class RoomDto
    {
        public int Id { get; set; }
       
        public string TypeRefId { get; set; } = null!;
      
        public float Rent { get; set; }
      
        public bool Status { get; set; }


    }
}
