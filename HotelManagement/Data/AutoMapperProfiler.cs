using AutoMapper;
using HotelManagement.Data.DTO;
using HotelManagement.Data.Model;

namespace HotelManagement.Data
{
    public class AutoMapperProfiler:Profile
    {

        public AutoMapperProfiler()
        {
            CreateMap<Location, LocationDto>().ReverseMap();
            CreateMap<Room, RoomDto>().ReverseMap();
            CreateMap<Hotel, HotelDto>().ReverseMap();
        }




    }
}
