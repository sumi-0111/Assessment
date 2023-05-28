﻿using HotelAssessment.Models;
using HotelAssessment.Repositories;

using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Repositories
{
    public class RoomRepository : IRoom
    {
        private readonly HotelContext _roomContext;
        public RoomRepository(HotelContext con)
        {
            _roomContext = con;
        }



        public IEnumerable<Room> GetRoom()
        {
            return _roomContext.Rooms.ToList();
        }
        public Room GetRoomById(int RoomNo)
        {
            return _roomContext.Rooms.FirstOrDefault(x => x.RoomNo == RoomNo);
        }

        public Room PostRoom(Room room)
        {

            var r = _roomContext.Hotels.Find(room.Hotel.HotelId);
            room.Hotel = r;
            _roomContext.Add(room);
            _roomContext.SaveChanges();
            return room;
        }

        public Room PutRoom(int RoomId, Room room)
        {
            var r = _roomContext.Hotels.Find(room.Hotel.HotelId);
            room.Hotel = r;
            _roomContext.Entry(room).State = EntityState.Modified;
            _roomContext.SaveChangesAsync();
            return room;
        }

        public Room DeleteRoom(int RoomId)
        {

            var r = _roomContext.Rooms.Find(RoomId);


            _roomContext.Rooms.Remove(r);
            _roomContext.SaveChanges();

            return r;
        }
    }
}
