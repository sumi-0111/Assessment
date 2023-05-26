using HotelAssessment.Models;
using HotelAssessment.Repositories;

using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Repositories
{
    public class HotelRepository : IHotel
    {
        private readonly HotelContext hotelContext;
        public HotelRepository(HotelContext con)
        {
            hotelContext = con;
        }
        public IEnumerable<Hotel> GetHotel()
        {
            return hotelContext.Hotels.Include(x => x.Rooms).ToList();
        }
        public Hotel GetHotelById(int HotelId)
        {
            return hotelContext.Hotels.FirstOrDefault(x => x.HotelId == HotelId);
        }

        public Hotel PostHotel(Hotel hotel)
        {


            hotelContext.Hotels.Add(hotel);
            hotelContext.SaveChanges();
            return hotel;
        }

        public Hotel PutHotel(int HotelId, Hotel hotel)
        {

            hotelContext.Entry(hotel).State = EntityState.Modified;
            hotelContext.SaveChangesAsync();
            return hotel;
        }

        public Hotel DeleteHotel(int HotelId)
        {

            var hot = hotelContext.Hotels.Find(HotelId);


            hotelContext.Hotels.Remove(hot);
            hotelContext.SaveChanges();

            return hot;
        }

    }
}
