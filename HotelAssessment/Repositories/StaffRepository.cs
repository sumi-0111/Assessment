using HotelAssessment.Models;
using HotelAssessment.Repositories;
using Microsoft.EntityFrameworkCore;


namespace HotelManagement.Repositories
{
    public class StaffRepository : IStaff
    {


        private readonly HotelContext _staffContext;
        public StaffRepository(HotelContext con)
        {
            _staffContext = con;
        }



        public IEnumerable<Staff> GetEmployees()
        {
            return _staffContext.Staffs.ToList();
        }
        public Staff GetEmployeesById(int EmployeeId)
        {
            return _staffContext.Staffs.FirstOrDefault(x => x.StaffId == EmployeeId);
        }

        public Staff PostEmployee(Staff employee)
        {

            var emp = _staffContext.Hotels.Find(employee.Hotel.HotelId);
            employee.Hotel = emp;
            _staffContext.Add(employee);
            _staffContext.SaveChanges();
            return employee;
        }

        public Staff PutEmployee(int EmployeeId, Staff employee)
        {
            var emp = _staffContext.Hotels.Find(employee.Hotel.HotelId);
            employee.Hotel = emp;
            _staffContext.Entry(employee).State = EntityState.Modified;
            _staffContext.SaveChangesAsync();
            return employee;
        }

        public Staff DeleteEmployee(int EmployeeId)
        {

            var emp = _staffContext.Staffs.Find(EmployeeId);


            _staffContext.Staffs.Remove(emp);
            _staffContext.SaveChanges();

            return emp;
        }
       




    }
}
