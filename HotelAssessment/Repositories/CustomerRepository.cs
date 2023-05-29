using HotelAssessment.Models;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
        public IEnumerable<Hotel> FilterLocation(string location)
        {
            try
            {
                var location_query = customerContext.Hotels.AsQueryable();

                if (!string.IsNullOrEmpty(location))
                {
                    location_query = location_query.Where(h => h.HotelLocation.Contains(location));
                }
                return location_query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while filtering the location.", ex);
            }
        }

        //Filtering price range
        public IEnumerable<Hotel> FilterPriceRange(decimal minPrice, decimal maxPrice)
        {
            try
            {
                var priceQuery = customerContext.Hotels.Include(x => x.Rooms).Where(r => r.RoomPrice >= minPrice && r.RoomPrice <= maxPrice);
                return priceQuery.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while filtering hotels based on price range.", ex);
            }
        }

        //Check room availability
        public int GettingRoom(int hotel_Id)
        {
            try
            {
                return customerContext.Rooms.Count(r => r.Hotel.HotelId == hotel_Id && r.RoomStatus == "available");
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the count of available rooms.", ex);
            }
        }

       

       
        public IEnumerable<Hotel> FilterHotels(string amenities)
        {
            var filteredHotels = customerContext.Hotels.AsQueryable();

            // Apply filters based on the provided criteria
            if (!string.IsNullOrEmpty(amenities))
            {
                filteredHotels = filteredHotels.Where(h => h.HotelLocation.Contains(amenities));
            }



            return filteredHotels.ToList();

        }


    }
}
