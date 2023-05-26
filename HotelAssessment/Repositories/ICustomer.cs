using HotelAssessment.Models;

namespace HotelAssessment.Repositories
{        public interface ICustomer
        {
            public IEnumerable<Customer> GetCustomer();
            public Customer GetCustomerById(int CustomerId);
            public Customer PostCustomer(Customer customer);
            public Customer PutCustomer(int CustomerId, Customer customer);
            public Customer DeleteCustomer(int CustomerId);
            public IEnumerable<Hotel> FilterHotels(string location);


            int GetAvailableRoomCountByHotelName(string hotelName);
    }
}

