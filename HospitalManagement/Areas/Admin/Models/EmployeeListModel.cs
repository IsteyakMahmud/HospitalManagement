using Autofac;
using Hospital.Common.Utilities;
using Hospital.Training.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagement.Areas.Admin.Models
{
    public class EmployeeListModel
    {
        private IEmployeeService _employeeService;
        private IHttpContextAccessor _httpContextAccessor;
        public EmployeeListModel()
        {
            _employeeService = Startup.AutofacContainer.Resolve<IEmployeeService>();
            _httpContextAccessor = Startup.AutofacContainer.Resolve<IHttpContextAccessor>();
        }

        public EmployeeListModel(IEmployeeService employeeService, IHttpContextAccessor httpContextAccessor)
        {
            _employeeService = employeeService;
            _httpContextAccessor = httpContextAccessor;
        }

        internal object GetEmployees(DataTablesAjaxRequestModel tableModel)
        {
            var session = _httpContextAccessor.HttpContext.Session;

            var data = _employeeService.GetEmployees(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new string[] { "Name", "Designation", "Salary" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                            record.Name,
                            record.Designation,
                            record.Salary.ToString(),
                            record.Id.ToString()

                        }
                        ).ToArray()

            };
        }

        internal void Delete(int id)
        {
            _employeeService.DeleteEmployee(id);
        }
    }
}
