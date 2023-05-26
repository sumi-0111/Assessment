using HotelAssessment.Models;
using HotelAssessment.Repositories;
using Microsoft.EntityFrameworkCore;


namespace HotelManagement.Repositories
{
    public class StaffRepository /*: IStaff*/
    {


        private readonly HotelContext _employeeContext;
        public StaffRepository(HotelContext con)
        {
            _employeeContext = con;
        }



        public IEnumerable<Staff> GetEmployees()
        {
            return _employeeContext.Staffs.ToList();
        }
        public Staff GetEmployeesById(int EmployeeId)
        {
            return _employeeContext.Staffs.FirstOrDefault(x => x.StaffId == EmployeeId);
        }

        public Staff PostEmployee(Staff employee)
        {

            var emp = _employeeContext.Hotels.Find(employee.Hotel.HotelId);
            employee.Hotel = emp;
            _employeeContext.Add(employee);
            _employeeContext.SaveChanges();
            return employee;
        }

        public Staff PutEmployee(int EmployeeId, Staff employee)
        {
            var emp = _employeeContext.Hotels.Find(employee.Hotel.HotelId);
            employee.Hotel = emp;
            _employeeContext.Entry(employee).State = EntityState.Modified;
            _employeeContext.SaveChangesAsync();
            return employee;
        }

        public Staff DeleteEmployee(int EmployeeId)
        {

            var emp = _employeeContext.Staffs.Find(EmployeeId);


            _employeeContext.Staffs.Remove(emp);
            _employeeContext.SaveChanges();

            return emp;
        }
        //public int GetRoomCountByRoomIdAndHotelId(int RoomId, int HotelId)
        //{
        //    var count = (from Room in _employeeContext.Rooms
        //                 join hotel in _employeeContext.Hotels on Room.Hotel.HotelId equals hotel.HotelId
        //                 where Room.RoomNo == RoomId && hotel.HotelId == HotelId
        //                 select Room.RoomCount).FirstOrDefault();

        //    return count;
        //}




    }
}
