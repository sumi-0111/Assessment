using HotelAssessment.Models;

namespace HotelAssessment.Repositories
    {
        public interface IStaff
        {
            public IEnumerable<Staff> GetEmployees();
            public Staff GetEmployeesById(int StaffId);
            public Staff PostEmployee(Staff Staff);
            public Staff PutEmployee(int StaffId, Staff staff);
            public Staff DeleteEmployee(int StaffId);
  

        }
    }
  
