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
    public class DoctorListModel
    {
        private IDoctorService _doctorService;
        private IHttpContextAccessor _httpContextAccessor;
        public DoctorListModel()
        {
            _doctorService = Startup.AutofacContainer.Resolve<IDoctorService>();
            _httpContextAccessor = Startup.AutofacContainer.Resolve<IHttpContextAccessor>();
        }

        public DoctorListModel(IDoctorService doctorService, IHttpContextAccessor httpContextAccessor)
        {
            _doctorService = doctorService;
            _httpContextAccessor = httpContextAccessor;
        }

        internal object GetDoctors(DataTablesAjaxRequestModel tableModel)
        {
            var session = _httpContextAccessor.HttpContext.Session;

            var data = _doctorService.GetDoctors(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new string[] { "Name", "Specialist", "Fees" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                            record.Name,
                            record.Specialist,
                            record.Fees.ToString(),
                            record.Id.ToString()

                        }
                        ).ToArray()

            };
        }

        internal void Delete(int id)
        {
            _doctorService.DeleteDoctor(id);
        }


    }
}
