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
    public class PatientListModel
    {
        private IPatientService _patientService;
        private IHttpContextAccessor _httpContextAccessor;
        public PatientListModel()
        {
            _patientService = Startup.AutofacContainer.Resolve<IPatientService>();
            _httpContextAccessor = Startup.AutofacContainer.Resolve<IHttpContextAccessor>();
        }

        public PatientListModel(IPatientService patientService, IHttpContextAccessor httpContextAccessor)
        {
            _patientService = patientService;
            _httpContextAccessor = httpContextAccessor;
        }

        internal object GetPatients(DataTablesAjaxRequestModel tableModel)
        {
            var session = _httpContextAccessor.HttpContext.Session;

            var data = _patientService.GetPatients(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new string[] { "Name", "Syndrome", "Contact" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                            record.Name,
                            record.Syndrome,
                            record.Contact,
                            record.Id.ToString()

                        }
                        ).ToArray()

            };
        }

        internal void Delete(int id)
        {
            _patientService.DeletePatient(id);
        }
    }
}
