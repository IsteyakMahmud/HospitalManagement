using AutoMapper;
using Hospital.Training.BusinessObjects;
using HospitalManagement.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagement.Profiles
{
    public class WebProfile : Profile
    {
        public WebProfile()
        {
            CreateMap<AddDoctorModel, Doctor>().ReverseMap();
            CreateMap<AddTestModel, Test>().ReverseMap();
            CreateMap<AddEmployeeModel, Employee>().ReverseMap();
            CreateMap<AddPatientModel, Patient>().ReverseMap();
            CreateMap<AddScheduleModel, Schedule>().ReverseMap();

        }
    }
}
  