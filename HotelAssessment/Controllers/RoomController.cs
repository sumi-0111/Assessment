using HotelAssessment.Models;
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
        public IEnumerable<Room> Get()
        {
            return r.GetRoom();
        }

        [HttpGet("{id}")]
        public Room GetById(int RoomId)
        {
            return r.GetRoomById(RoomId);
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
