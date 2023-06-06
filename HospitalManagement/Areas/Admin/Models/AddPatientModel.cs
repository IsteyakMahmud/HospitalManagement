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
    public class AddPatientModel
    {
        [Required, MaxLength(200, ErrorMessage = "Name should be less than 200 characters")]
        public string Name { get; set; }
        public string Syndrome { get; set; }
        public int Contact { get; set; }

        private readonly IPatientService _patientService;

        private readonly IMapper _mapper;

        public AddPatientModel()
        {
            _patientService = Startup.AutofacContainer.Resolve<IPatientService>();
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
        }

        public AddPatientModel(IPatientService patientService)
        {
            _patientService = patientService;
        }

        internal void AddPatient()
        {
            var patient = _mapper.Map<Patient>(this);

            _patientService.AddPatient(patient);

        }
    }
}
