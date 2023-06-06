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
    public class EditDoctorModel
    {
        public int? Id { get; set; }
        [Required, MaxLength(200, ErrorMessage = "Name should be less than 200 characters")]
        public string Name { get; set; }
        public string Specialist { get; set; }

        [Required, Range(100, 5000)]
        public int? Fees { get; set; }

        private readonly IDoctorService _doctorService;

        public EditDoctorModel()
        {
            _doctorService = Startup.AutofacContainer.Resolve<IDoctorService>();
        }

        public void LoadModelData(int id)
        {
            var doctor = _doctorService.GetDoctor(id);
            Id = doctor?.Id;
            Name = doctor?.Name;
            Specialist = doctor?.Specialist;
            Fees = doctor?.Fees;
        }

        internal void Update()
        {
            var doctor = new Doctor
            {
                Id = Id.HasValue ? Id.Value : 0,
                Fees = Fees.HasValue ? Fees.Value : 0,
                Name = Name,
                Specialist = Specialist

            };
            _doctorService.UpdateDoctor(doctor);
        }

    }
}
