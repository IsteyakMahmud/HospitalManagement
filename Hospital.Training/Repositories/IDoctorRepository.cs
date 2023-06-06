using Hospital.Data;
using Hospital.Training.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Training.Repositories
{
    public interface IDoctorRepository : IRepository<Doctor, int>
    {
    }
}
