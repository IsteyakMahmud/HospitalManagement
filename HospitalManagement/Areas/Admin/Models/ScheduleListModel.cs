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
    public class ScheduleListModel
    {
        private IScheduleService _scheduleService;
        private IHttpContextAccessor _httpContextAccessor;
        public ScheduleListModel()
        {
            _scheduleService = Startup.AutofacContainer.Resolve<IScheduleService>();
            _httpContextAccessor = Startup.AutofacContainer.Resolve<IHttpContextAccessor>();
        }

        public ScheduleListModel(IScheduleService scheduleService, IHttpContextAccessor httpContextAccessor)
        {
            _scheduleService = scheduleService;
            _httpContextAccessor = httpContextAccessor;
        }

        internal object GetSchedules(DataTablesAjaxRequestModel tableModel)
        {
            var session = _httpContextAccessor.HttpContext.Session;

            var data = _scheduleService.GetSchedules(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new string[] { "PatientName", "PatientMobile", "DoctorName", "TestName", "DateAndTime" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                            record.PatientName,
                            record.PatientMobile,
                            record.DoctorName,
                            record.TestName,
                            record.DateAndTime,
                            record.Id.ToString()

                        }
                        ).ToArray()

            };
        }

        internal void Delete(int id)
        {
            _scheduleService.DeleteSchedule(id);
        }
    }
}
