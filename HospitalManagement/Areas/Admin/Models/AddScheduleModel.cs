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
    public class AddScheduleModel
    {
        [Required, MaxLength(200, ErrorMessage = "Name should be less than 200 characters")]
        public string PatientName { get; set; }
        public string PatientMobile { get; set; }

        public string DoctorName { get; set; }

        public string TestName { get; set; }
        public string DateAndTime { get; set; }

        private readonly IScheduleService _scheduleService;

        private readonly IMapper _mapper;

        public AddScheduleModel()
        {
            _scheduleService = Startup.AutofacContainer.Resolve<IScheduleService>();
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
        }

        public AddScheduleModel(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        internal void AddSchedule()
        {
            var schedule = _mapper.Map<Schedule>(this);

            _scheduleService.AddSchedule(schedule);

        }
    }
}
