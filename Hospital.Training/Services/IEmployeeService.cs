using Hospital.Training.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Training.Services
{
    public interface IEmployeeService
    {
        IList<Employee> GetAllEmployees();

        void AddEmployee(Employee employee);

        (IList<Employee> records, int total, int totalDisplay) GetEmployees(int pageIndex,
            int pageSize, string searchText, string sortText);

        Employee GetEmployee(int id);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(int id);
    }
}
