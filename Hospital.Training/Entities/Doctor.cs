using Hospital.Data;
using Registration.Training.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Training.Entities
{
    public class Doctor : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialist { get; set; }
        public int Fees { get; set; }
        public List<Appointment> AssignedPatient { get; set; }
    }
}
