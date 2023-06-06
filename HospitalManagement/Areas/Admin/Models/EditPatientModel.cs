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
    public class EditPatientModel
    {
        public int? Id { get; set; }
        [Required, MaxLength(200, ErrorMessage = "Name should be less than 200 characters")]
        public string Name { get; set; }
        public string Syndrome { get; set; }
        public string Contact { get; set; }

        private readonly IPatientService _patientService;

        public EditPatientModel()
        {
            _patientService = Startup.AutofacContainer.Resolve<IPatientService>();
        }

        public void LoadModelData(int id)
        {
            var patient = _patientService.GetPatient(id);
            Id = patient?.Id;
            Name = patient?.Name;
            Syndrome = patient?.Syndrome;
            Contact = patient?.Contact;
        }

        internal void Update()
        {
            var patient = new Patient
            {
                Id = Id.HasValue ? Id.Value : 0,
                Name = Name,
                Syndrome = Syndrome,
                Contact = Contact

            };
            _patientService.UpdatePatient(patient);
        }
    }
}
