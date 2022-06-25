using AutoMapper;
using Demo63Assignment.Models.Interface;
using HotelManagement.Data.Data_Access;
using HotelManagement.Data.DTO;
using HotelManagement.Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Web.Http;

namespace HotelManagement.Data.Services
{
    public class RoomService : ICrudService<RoomDto>
    {
        private readonly HotelMgtContext _hotelMgtContext;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        public RoomService(HotelMgtContext hotelMgtContext, ILogger logger,IMapper mapper)
        {
            _hotelMgtContext = hotelMgtContext;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task CreateAsync(RoomDto entity)
        {
            try
            {
                var roomDto=_mapper.Map<Room>(entity);
                _hotelMgtContext.Rooms.Add(roomDto);
                await _hotelMgtContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {                         
                var room = _hotelMgtContext.Rooms.SingleOrDefault(r => r.Id == id);
                if(room == null)
                    throw new HttpResponseException(HttpStatusCode.NotFound);

                _hotelMgtContext.Rooms.Remove(room);
                await _hotelMgtContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        public async Task<List<RoomDto>> GetAllAsync()
        {
            List<RoomDto> roomsDtos = new();    
            try
            {
                roomsDtos = await _mapper.ProjectTo<RoomDto>(_hotelMgtContext.Rooms).ToListAsync();              
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw new HttpResponseException(HttpStatusCode.Conflict);
            }
            return roomsDtos;
        }

        public async Task<RoomDto> GetByIdAsync(int id)
        { RoomDto roomDto=new RoomDto();
            try
            {
                roomDto = await _mapper.ProjectTo<RoomDto>(_hotelMgtContext.Rooms).SingleOrDefaultAsync(r => r.Id == id);                
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.ToString());
                throw new HttpResponseException(HttpStatusCode.Conflict);
            }
            return roomDto;
        }

        public async Task Update(RoomDto entity)
        {
            try
            {
                if(entity == null)
                {
                    throw new  HttpResponseException(HttpStatusCode.NotFound);
                }

                var room =  _mapper.Map<Room>(entity);
                _hotelMgtContext.Rooms.Update(room);
                await _hotelMgtContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError(message: ex.ToString());
                throw new HttpResponseException(HttpStatusCode.Conflict);
            }
        }
    }
}
