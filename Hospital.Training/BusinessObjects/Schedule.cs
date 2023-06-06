using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Training.BusinessObjects
{
    public class Schedule
    {
        public int Id { get; set; }

        public string PatientName { get; set; }

        public string PatientMobile { get; set; }

        public string DoctorName { get; set; }

        public string TestName { get; set; }

        public string DateAndTime { get; set; }
    }
}
