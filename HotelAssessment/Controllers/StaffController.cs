using HotelAssessment.Models;
using HotelAssessment.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaff emp;
        public StaffController(IStaff emp)
        {
            this.emp = emp;
        }
        [HttpGet]
        public IEnumerable<Staff> Get()
        {
            return emp.GetEmployees();
        }

        [HttpGet("{id}")]
        public Staff GetById(int id)
        {
            return emp.GetEmployeesById(id);
        }

        [HttpPost]
        public Staff PostEmployee(Staff employee)
        {
            return emp.PostEmployee(employee);
        }
        [HttpPut("{id}")]
        public Staff PutEmployee(int id, Staff employee)
        {
            return emp.PutEmployee(id, employee);
        }
        [HttpDelete("{id}")]
        public Staff DeleteEmployee(int id)
        {
            return emp.DeleteEmployee(id);
        }
        [HttpGet("roomcount")]
        public int GetRoomCountByRoomIdAndHotelId(int RoomId, int HotelId)
        {

            return emp.GetRoomCountByRoomIdAndHotelId(RoomId, HotelId);


        }


    }
}
