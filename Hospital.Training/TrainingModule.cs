using Autofac;
using Hospital.Training.Context;
using Hospital.Training.Repositories;
using Hospital.Training.Services;
using Hospital.Training.UnitOfWorks;
using System;

namespace Hospital.Training
{
    public class TrainingModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;
        public TrainingModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TrainingContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();
            builder.RegisterType<TrainingContext>().As<ITrainingContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<DoctorRepository>().As<IDoctorRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<TrainingUnitOfWork>().As<ITrainingUnitOfWork>()
                .InstancePerLifetimeScope();
            builder.RegisterType<DoctorService>().As<IDoctorService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<TestRepository>().As<ITestRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<TestService>().As<ITestService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>()
               .InstancePerLifetimeScope();
            builder.RegisterType<EmployeeService>().As<IEmployeeService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<PatientRepository>().As<IPatientRepository>()
               .InstancePerLifetimeScope();
            builder.RegisterType<PatientService>().As<IPatientService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ScheduleRepository>().As<IScheduleRepository>()
               .InstancePerLifetimeScope();
            builder.RegisterType<ScheduleService>().As<IScheduleService>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
