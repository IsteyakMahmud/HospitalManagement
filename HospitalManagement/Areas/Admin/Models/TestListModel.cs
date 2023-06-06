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
    public class TestListModel
    {
        private ITestService _testService;
        private IHttpContextAccessor _httpContextAccessor;
        public TestListModel()
        {
            _testService = Startup.AutofacContainer.Resolve<ITestService>();
            _httpContextAccessor = Startup.AutofacContainer.Resolve<IHttpContextAccessor>();
        }

        public TestListModel(ITestService testService, IHttpContextAccessor httpContextAccessor)
        {
            _testService = testService;
            _httpContextAccessor = httpContextAccessor;
        }

        internal object GetTests(DataTablesAjaxRequestModel tableModel)
        {
            var session = _httpContextAccessor.HttpContext.Session;

            var data = _testService.GetTests(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new string[] { "Name", "Fees" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                            record.Name,
                            record.Fees.ToString(),
                            record.Id.ToString()

                        }
                        ).ToArray()

            };
        }

        internal void Delete(int id)
        {
            _testService.DeleteTest(id);
        }
    }
}
