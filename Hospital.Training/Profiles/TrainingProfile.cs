using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EO = Hospital.Training.Entities;
using BO = Hospital.Training.BusinessObjects;


namespace Hospital.Training.Profiles
{
    public class TrainingProfile : Profile
    {
        public TrainingProfile()
        {
            CreateMap<EO.Doctor, BO.Doctor>().ReverseMap();
            CreateMap<EO.Employee, BO.Employee>().ReverseMap();
            CreateMap<EO.Test, BO.Test>().ReverseMap();
            CreateMap<EO.Patient, BO.Patient>().ReverseMap();
            CreateMap<EO.Schedule, BO.Schedule>().ReverseMap();
        }
    }
}
