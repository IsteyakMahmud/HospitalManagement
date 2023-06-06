using Hospital.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Training.Entities
{
    public class Employee : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public int Salary { get; set; }
    }
}
