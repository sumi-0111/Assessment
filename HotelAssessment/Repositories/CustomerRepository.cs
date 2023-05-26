using HotelAssessment.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace HotelAssessment.Repositories
{
          public class CustomerRepository/* : ICustomer*/
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
                var location_query = customerContext.Hotels.Include(x => x.Rooms).AsQueryable();

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
        //Filtering amenities
        public IEnumerable<Hotel> FilterAmenities(string amenities)
        {
            try
            {
                var amenities_query = customerContext.Hotels.Include(x => x.Rooms).AsQueryable();

                if (!string.IsNullOrEmpty(amenities))
                {
                    amenities_query = amenities_query.Where(h => h.Amenities.Contains(amenities));
                }
                return amenities_query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while filtering the amenties.", ex);
            }
        }
        // Filtering price range
        //public IEnumerable<Hotel> FilterPriceRange(decimal minPrice, decimal maxPrice)
        //{
        //    try
        //    {
        //        var Pricequery = customerContext.Hotels.Include(x => x.Rooms).AsQueryable();
        //        if (minPrice.HasValue)
        //        {
        //            Pricequery = Pricequery.Where(h => h.Rooms.Any(r => r.RoomPrice >= minPrice.Value));
        //        }
        //        if (maxPrice.HasValue)
        //        {
        //            Pricequery = Pricequery.Where(h => h.Rooms.Any(r => r.RoomPrice <= maxPrice.Value));
        //        }


        //        return Pricequery.ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("An error occurred while filtering the price range.", ex);
        //    }
        //}
        //Check room availability
        //public int GetAvailableRoomCount(int hotel_Id)
        //{
        //    try
        //    {
        //        return customerContext.Rooms.Count(r => r.Hotel.HotelId == hotel_Id && r.Room_Status == "available");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("An error occurred while retrieving the count of available rooms.", ex);
        //    }
        //}



    }
}
