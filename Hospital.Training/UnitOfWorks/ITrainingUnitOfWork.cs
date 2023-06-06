using Hospital.Data;
using Hospital.Training.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Training.UnitOfWorks
{
    public interface ITrainingUnitOfWork : IUnitOfWork
    {
        IDoctorRepository Doctors { get; }
        ITestRepository Tests { get; }

        IEmployeeRepository Employees { get; }

        IPatientRepository Patients { get; }

        IScheduleRepository Schedules { get; }
    }
}
