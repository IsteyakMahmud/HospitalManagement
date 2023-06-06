using Autofac;
using AutoMapper;
using Hospital.Training.BusinessObjects;
using Hospital.Training.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagement.Areas.Admin.Models
{
    public class AddEmployeeModel
    {
        [Required, MaxLength(200, ErrorMessage = "Name should be less than 200 characters")]
        public string Name { get; set; }
        public string Designation { get; set; }

        [Required, Range(5000, 50000)]
        public int Salary { get; set; }

        private readonly IEmployeeService _employeeService;

        private readonly IMapper _mapper;

        public AddEmployeeModel()
        {
            _employeeService = Startup.AutofacContainer.Resolve<IEmployeeService>();
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();

        }

        public AddEmployeeModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        internal void AddEmployee()
        {
            var employee = _mapper.Map<Employee>(this);

            _employeeService.AddEmployee(employee);

        }
    }
}
