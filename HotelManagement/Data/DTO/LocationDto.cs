namespace HotelManagement.Data.DTO
{
    public class LocationDto
    {
        public int Id { get; set; }
        public string State { get; set; } = null!;      
        public string? District { get; set; }     
        public string City { get; set; } = null!;
        public string? Pincode { get; set; }

    }
}
