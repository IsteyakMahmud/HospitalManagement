using Hospital.Data;
using Registration.Training.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Training.Entities
{
    public class Patient : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Syndrome { get; set; }
        public string Contact { get; set; }
        public List<Appointment> AssignedDoctors { get; set; }
    }
}
