using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using HotelAssessment.Models;
using HotelAssessment.Repositories;

namespace HotelManagement.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        private readonly ICustomer cus;
        public CustomersController(ICustomer cus)
        {
            this.cus = cus;
        }
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return cus.GetCustomer();
        }

        [HttpGet("{id}")]
        public Customer GetById(int CustomerId)
        {
            return cus.GetCustomerById(CustomerId);
        }

        [HttpPost]
        public Customer PostCustomer(Customer customer)
        {
            return cus.PostCustomer(customer);
        }
        [HttpPut("{id}")]
        public Customer PutCustomer(int CustomerId, Customer customer)
        {
            return cus.PutCustomer(CustomerId, customer);
        }
        [HttpDelete("{id}")]
        public Customer DeleteCustomer(int CustomerId)
        {
            return cus.DeleteCustomer(CustomerId);
        }
        [HttpGet("filter")]
        public IEnumerable<Hotel> FilterHotels(string location)
        {
            return cus.FilterHotels(location);
        }


        [HttpGet("hotels/roomcount")]
        public int GettingRoom(int hotelId)
        {
            
            return cus.GettingRoom(hotelId) ;
        }

    }
}

