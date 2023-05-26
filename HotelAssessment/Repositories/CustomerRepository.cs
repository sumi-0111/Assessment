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
        }
    }
