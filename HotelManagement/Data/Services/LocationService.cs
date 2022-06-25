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
    public class LocationService : ICrudService<LocationDto>
    {


        private readonly HotelMgtContext _hotelMgtContext;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public LocationService(HotelMgtContext hotelMgtContext, ILogger logger, IMapper mapper)
        {
            _hotelMgtContext = hotelMgtContext;
            _logger = logger;
            _mapper = mapper;
            
        }


        public async Task CreateAsync(LocationDto entity)
        {
            try
            {
                var location=_mapper.Map<Location>(entity);
                _hotelMgtContext.Locations.Add(location);
                await _hotelMgtContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some Conflic Occured");
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var location = _hotelMgtContext.Locations.SingleOrDefault(r => r.Id == id);
                if (location == null)
                    throw new HttpResponseException(HttpStatusCode.NotFound);

                _hotelMgtContext.Locations.Remove(location);
                await _hotelMgtContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some Conflict Occured");
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        public async Task<List<LocationDto>> GetAllAsync()
        {
            List<LocationDto> locationsDto = new();
            try
            {
                var locations = await _hotelMgtContext.Locations.ToListAsync();
                locationsDto = await  _mapper.ProjectTo<LocationDto>(_hotelMgtContext.Locations).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some Conflic Occure");
                throw new HttpResponseException(HttpStatusCode.Conflict);
            }
            return locationsDto;
        }

        public async Task<LocationDto> GetByIdAsync(int id)
        {
            LocationDto location = new();
            try
            {
                location = await _mapper.ProjectTo<LocationDto>(_hotelMgtContext.Locations).SingleAsync(l => l.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some Conflic Occure");
                throw new HttpResponseException(HttpStatusCode.Conflict);
            }
            return location;
        }

        public async Task Update(LocationDto entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                var location =  _mapper.Map<Location>(entity);
                _hotelMgtContext.Locations.Update(location);
                await _hotelMgtContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.ToString());
                throw new HttpResponseException(HttpStatusCode.Conflict);
            }
        }
    }
}
