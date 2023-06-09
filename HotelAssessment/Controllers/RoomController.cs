﻿using HotelAssessment.Models;
using HotelAssessment.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoom r;
        public RoomsController(IRoom r)
        {
            this.r = r;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Hotel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IEnumerable<Room> Get()
        {
            return r.GetRoom();
        }

        [HttpGet("{id}")]
        public Room GetById(int Id)
        {
            return r.GetRoomById(Id);
        }

        [HttpPost]
        public Room PostRoom(Room room)
        {
            return r.PostRoom(room);
        }
        [HttpPut("{id}")]
        public Room PutRoom(int RoomId, Room room)
        {
            return r.PutRoom(RoomId, room);
        }
        [HttpDelete("{id}")]
        public Room DeleteRoom(int RoomId)
        {
            return r.DeleteRoom(RoomId);
        }

    }
}
