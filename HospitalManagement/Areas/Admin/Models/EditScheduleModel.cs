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
    public class EditScheduleModel
    {
        public int? Id { get; set; }
        [Required, MaxLength(200, ErrorMessage = "Name should be less than 200 characters")]
        public string PatientName { get; set; }
        public string PatientMobile { get; set; }

        public string DoctorName { get; set; }

        public string TestName { get; set; }
        public string DateAndTime { get; set; }

        private readonly IScheduleService _scheduleService;

        public EditScheduleModel()
        {
            _scheduleService = Startup.AutofacContainer.Resolve<IScheduleService>();
        }

        public void LoadModelData(int id)
        {
            var schedule = _scheduleService.GetSchedule(id);
            Id = schedule?.Id;
            PatientName = schedule?.PatientName;
            PatientMobile = schedule?.PatientMobile;
            DoctorName = schedule?.DoctorName;
            TestName = schedule?.TestName;
            DateAndTime = schedule?.DateAndTime;

        }

        internal void Update()
        {
            var schedule = new Schedule
            {
                Id = Id.HasValue ? Id.Value : 0,
                PatientName = PatientName,
                PatientMobile = PatientMobile,
                DoctorName = DoctorName,
                TestName = TestName,
                DateAndTime = DateAndTime

            };
            _scheduleService.UpdateSchedule(schedule);
        }
    }
}
