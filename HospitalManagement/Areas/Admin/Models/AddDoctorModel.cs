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
    public class AddDoctorModel
    {
        [Required, MaxLength(200, ErrorMessage = "Name should be less than 200 characters")]
        public string Name { get; set; }
        public string Specialist { get; set; }

        [Required, Range(100, 5000)]
        public int Fees { get; set; }

        private readonly IDoctorService _doctorService;

        private readonly IMapper _mapper;

        public AddDoctorModel()
        {
            _doctorService = Startup.AutofacContainer.Resolve<IDoctorService>();
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
        }

        public AddDoctorModel(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        internal void AddDoctor()
        {
            var doctor = _mapper.Map<Doctor>(this);

            _doctorService.AddDoctor(doctor);
            
        }
    }
}
