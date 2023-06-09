﻿
using HotelAssessment.Models;
using HotelAssessment.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelAssessment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotel Hotelz;
        public HotelsController(IHotel Hotelz)
        {
            this.Hotelz = Hotelz;
        }
        [HttpGet]
        public IEnumerable<Hotel> Get()
        {
            return Hotelz.GetHotel();
        }

        [HttpGet("{id}")]
        public Hotel GetById(int Id)
        {
            return Hotelz.GetHotelById(Id);
        }

        [HttpPost]
        public Hotel PostHotel(Hotel hotel)
        {
            return Hotelz.PostHotel(hotel);
        }
        [HttpPut("{id}")]
        public Hotel PutHotel(int HotelId, Hotel hotel)
        {
            return Hotelz.PutHotel(HotelId, hotel);
        }
        [HttpDelete("{id}")]
        public Hotel DeleteHotel(int HotelId)
        {
            return Hotelz.DeleteHotel(HotelId);
        }
    }
}
