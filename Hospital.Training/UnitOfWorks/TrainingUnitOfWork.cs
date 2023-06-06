using Hospital.Data;
using Hospital.Training.Context;
using Hospital.Training.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Training.UnitOfWorks
{
    public class TrainingUnitOfWork : UnitOfWork, ITrainingUnitOfWork
    {
        public IDoctorRepository Doctors { get; private set; }

        public ITestRepository Tests { get; private set; }

        public IEmployeeRepository Employees { get; private set; }

        public IPatientRepository Patients { get; private set; }

        public IScheduleRepository Schedules { get; private set; }

        public TrainingUnitOfWork(ITrainingContext context,
            IDoctorRepository doctors,
            ITestRepository tests,
            IEmployeeRepository employees,
            IPatientRepository patients,
            IScheduleRepository schedules
            ) : base((DbContext)context)
        {
            Doctors = doctors;
            Tests = tests;
            Employees = employees;
            Patients = patients;
            Schedules = schedules;
        }


    }
}
