using Autofac;
using AutoMapper;
using Hospital.Training.BusinessObjects;
using Hospital.Training.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagement.Areas.Admin.Models
{
    public class AddTestModel
    {
        [Required, MaxLength(200, ErrorMessage = "Name should be less than 200 characters")]
        public string Name { get; set; }

        [Required, Range(100, 15000)]
        public int Fees { get; set; }

        private readonly ITestService _testService;

        private readonly IMapper _mapper;

        public AddTestModel()
        {
            _testService = Startup.AutofacContainer.Resolve<ITestService>();
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();

        }

        public AddTestModel(ITestService testService)
        {
            _testService = testService;
        }

        internal void AddTest()
        {
            var test = _mapper.Map<Test>(this);

            _testService.AddTest(test);

        }
    }
}
