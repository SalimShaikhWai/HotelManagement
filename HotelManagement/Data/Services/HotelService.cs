using AutoMapper;
using Demo63Assignment.Models.Interface;
using HotelManagement.Data.Data_Access;
using HotelManagement.Data.DTO;
using HotelManagement.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Web.Http;

namespace HotelManagement.Data.Services
{
    public class HotelService : ICrudService<HotelDto>
    {
        private readonly HotelMgtContext _hotelMgtContext;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        
        public HotelService(HotelMgtContext hotelMgtContext, ILogger logger, IMapper mapper)
        {
            _hotelMgtContext = hotelMgtContext;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task CreateAsync(HotelDto entity)
        {
            try
            {
                var hotel=_mapper.Map<Hotel>(entity);
                _hotelMgtContext.Hotel.Add(hotel);
                await _hotelMgtContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Not Conflict Occured");
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {

                var hotel = _hotelMgtContext.Hotel.SingleOrDefault(r => r.Id == id);
                if (hotel == null)
                    throw new HttpResponseException(HttpStatusCode.NotFound);

                _hotelMgtContext.Hotel.Remove(hotel);
                await _hotelMgtContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Not Able To Delete");
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        public async Task<List<HotelDto>> GetAllAsync()
        {
            List<HotelDto> hotelsDto = new();
            try
            {
                hotelsDto = await _mapper.ProjectTo<HotelDto>(_hotelMgtContext.Hotel).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Not Able To Fetch Information");
                throw new HttpResponseException(HttpStatusCode.Conflict);
            }
            return hotelsDto;
        }

        public async Task<HotelDto> GetByIdAsync(int id)
        {
            HotelDto hotel = new();
            try
            {
                hotel =await _mapper.ProjectTo<HotelDto> (_hotelMgtContext.Hotel).SingleOrDefaultAsync(r => r.Id == id);
          
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.ToString());
                throw new HttpResponseException(HttpStatusCode.Conflict);
            }
            return hotel;
        }

        public async Task Update(HotelDto entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                var hotel =  _mapper.Map<Hotel>(entity);
                _hotelMgtContext.Hotel.Update(hotel);
                await _hotelMgtContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Not Able To Updated");
                throw new HttpResponseException(HttpStatusCode.Conflict);
            }
        }
    }
}
