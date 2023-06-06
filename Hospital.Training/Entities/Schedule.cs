using Hospital.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Training.Entities
{
    public class Schedule : IEntity<int>
    {
        public int Id { get; set; }

        public string PatientName { get; set; }

        public string PatientMobile { get; set; }

        public string DoctorName { get; set; }

        public string TestName { get; set; }

        public string DateAndTime { get; set; }
    }
}
