using HotelAssessment.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelAssessment.Repositories
{
          public class CustomerRepository : ICustomer
           {
            private readonly HotelContext customerContext;
            public CustomerRepository(HotelContext con)
            {
                customerContext = con;
            }



            public IEnumerable<Customer> GetCustomer()
            {
                return customerContext.Customers.ToList();
            }
            public Customer GetCustomerById(int CustomerId)
            {
                return customerContext.Customers.FirstOrDefault(x => x.CustomerId == CustomerId);
            }

            public Customer PostCustomer(Customer customer)
            {

                var cus = customerContext.Hotels.Find(customer.Hotel.HotelId);
                customer.Hotel = cus;
                customerContext.Add(customer);
                customerContext.SaveChanges();
                return customer;
            }

            public Customer PutCustomer(int CustomerId, Customer customer)
            {
                var cus = customerContext.Hotels.Find(customer.Hotel.HotelId);
                customer.Hotel = cus; ;
                customerContext.Entry(customer).State = EntityState.Modified;
                customerContext.SaveChangesAsync();
                return customer;
            }

            public Customer DeleteCustomer(int CustomerId)
            {

                var cus = customerContext.Customers.Find(CustomerId);


                customerContext.Customers.Remove(cus);
                customerContext.SaveChanges();

                return cus;
            }
        public IEnumerable<Hotel> FilterHotels(HotelFilterDTO filter)
        {
            try
            {
                var hotels = customerContext.Hotels.Include(h => h.Rooms).AsQueryable();

                if (!string.IsNullOrEmpty(filter.Location))
                {
                    hotels = hotels.Where(h => h.Location.Contains(filter.Location));
                }

                if (filter.MinPrice.HasValue)
                {
                    hotels = hotels.Where(h => h.Rooms.Any(r => r.RoomPrice >= filter.MinPrice.Value));
                }

                if (filter.MaxPrice.HasValue)
                {
                    hotels = hotels.Where(h => h.Rooms.Any(r => r.RoomPrice <= filter.MaxPrice.Value));
                }

                if (filter.Amenities != null && filter.Amenities.Any())
                {
                    hotels = hotels.Where(h => filter.Amenities.All(a => h.Amenities.Contains(a)));
                }

                return hotels.ToList();
            }
            catch (Exception ex)
            {
                
                throw new Exception("An error occurred while filtering hotels.", ex);
            }
        }
        public IEnumerable<Hotel> FilterHotels(string location)
        {
            var filteredHotels = customerContext.Hotels.AsQueryable();

            // Apply filters based on the provided criteria
            if (!string.IsNullOrEmpty(location))
            {
                filteredHotels = filteredHotels.Where(h => h.HotelLocation.Contains(location));
            }



            return filteredHotels.ToList();
        }
        public int GetAvailableRoomCountByHotelName(string hotelName)
        {
            var hotel = customerContext.Hotels
                .Include(h => h.Rooms)
                .FirstOrDefault(h => h.HotelName == hotelName);

            if (hotel == null)
            {
                // Handle hotel not found scenario
                return 0;
            }

            int availableRoomCount = hotel.Rooms.Count(r => r.IsAvailable);
            return availableRoomCount;
        }




    }
}
