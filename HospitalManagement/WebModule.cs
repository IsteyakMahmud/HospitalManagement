using Autofac;
using HospitalManagement.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagement
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<DoctorListModel>().AsSelf();

            builder.RegisterType<TestListModel>().AsSelf(); 
            
            builder.RegisterType<EmployeeListModel>().AsSelf();

            builder.RegisterType<PatientListModel>().AsSelf();

            builder.RegisterType<ScheduleListModel>().AsSelf();

            base.Load(builder);
        }
    }
}
