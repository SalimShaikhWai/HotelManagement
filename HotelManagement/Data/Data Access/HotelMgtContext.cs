using HotelManagement.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Data.Data_Access
{
    public class HotelMgtContext:DbContext
    {

        public virtual DbSet<Location> Locations { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<Hotel> Hotel { get; set; } = null!;

        public HotelMgtContext()
        {

        }
        public HotelMgtContext(DbContextOptions<HotelMgtContext> options):base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

    }
}
