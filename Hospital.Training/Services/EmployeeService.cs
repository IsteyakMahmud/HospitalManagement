using AutoMapper;
using Hospital.Common.Utilities;
using Hospital.Training.BusinessObjects;
using Hospital.Training.Exceptions;
using Hospital.Training.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Training.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ITrainingUnitOfWork _trainingUnitOfWork;
        private readonly IDateTimeUtility _dateTimeUtility;
        private readonly IMapper _mapper; 
        public EmployeeService(ITrainingUnitOfWork trainingUnitOfWork,
            IDateTimeUtility dateTimeUtility,
            IMapper mapper)
        {
            _trainingUnitOfWork = trainingUnitOfWork;
            _dateTimeUtility = dateTimeUtility;
            _mapper = mapper;

        }
        public void AddEmployee(Employee employee)
        {
            if (employee == null)
                throw new invalidPerameterException("Employee details was not provided");

            _trainingUnitOfWork.Employees.Add(
            _mapper.Map<Entities.Employee>(employee)
        );

            _trainingUnitOfWork.Save();
        }


        public void DeleteEmployee(int id)
        {
            _trainingUnitOfWork.Employees.Remove(id);
            _trainingUnitOfWork.Save();
        }

        public IList<Employee> GetAllEmployees()
        {
            var employeeEntities = _trainingUnitOfWork.Employees.GetAll();
            var employees = new List<Employee>();

            foreach (var entity in employeeEntities)
            {
                var employee = _mapper.Map<Employee>(entity);
                employees.Add(employee);
            }

            return employees;
        }

        public Employee GetEmployee(int id)
        {
            var employee = _trainingUnitOfWork.Employees.GetById(id);

            if (employee == null) return null;

            return _mapper.Map<Employee>(employee);
        }

        public (IList<Employee> records, int total, int totalDisplay) GetEmployees(int pageIndex, int pageSize, string searchText, string sortText)
        {
            var employeeData = _trainingUnitOfWork.Employees.GetDynamic(string.IsNullOrWhiteSpace(searchText) ? null :
               x => x.Name.Contains(searchText), sortText, string.Empty,
                pageIndex, pageSize);

            var resultData = (from employee in employeeData.data
                              select _mapper.Map<Employee>(employee)).ToList();

            return (resultData, employeeData.total, employeeData.totalDisplay);
        }

        public void UpdateEmployee(Employee employee)
        {
            if (employee == null)
                throw new InvalidOperationException("Employee is missing");


            var employeeEntity = _trainingUnitOfWork.Employees.GetById(employee.Id);

            if (employeeEntity != null)
            {
                _mapper.Map(employee, employeeEntity);

                _trainingUnitOfWork.Save();

            }
            else
                throw new InvalidOperationException("Couldn't find employees");
        }

    }
}
