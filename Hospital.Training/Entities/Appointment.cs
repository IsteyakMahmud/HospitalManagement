using Hospital.Training.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Training.Entities
{
    public class Appointment
    {
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int TestId { get; set; }
        public Test Test { get; set; }

        public DateTime AppointmentDate { get; set; }



    }
}
