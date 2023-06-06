using Autofac;
using Hospital.Training.BusinessObjects;
using Hospital.Training.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagement.Areas.Admin.Models
{
    public class EditEmployeeModel
    {
        public int? Id { get; set; }
        [Required, MaxLength(200, ErrorMessage = "Name should be less than 200 characters")]
        public string Name { get; set; }
        public string Designation { get; set; }

        [Required, Range(5000, 50000)]
        public int? Salary { get; set; }

        private readonly IEmployeeService _employeeService;

        public EditEmployeeModel()
        {
            _employeeService = Startup.AutofacContainer.Resolve<IEmployeeService>();
        }

        public void LoadModelData(int id)
        {
            var employee = _employeeService.GetEmployee(id);
            Id = employee?.Id;
            Name = employee?.Name;
            Designation = employee?.Designation;
            Salary = employee?.Salary;
        }

        internal void Update()
        {
            var employee = new Employee
            {
                Id = Id.HasValue ? Id.Value : 0,
                Salary = Salary.HasValue ? Salary.Value : 0,
                Name = Name,
                Designation = Designation

            };
            _employeeService.UpdateEmployee(employee);
        }
    }
}
