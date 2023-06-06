using Autofac;
using Hospital.Training.BusinessObjects;
using Hospital.Training.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagement.Areas.Admin.Models
{
    public class EditTestModel
    {
        public int? Id { get; set; }
        [Required, MaxLength(200, ErrorMessage = "Name should be less than 200 characters")]
        public string Name { get; set; }

        [Required, Range(100,15000)]
        public int? Fees { get; set; }

        private readonly ITestService _testService;

        public EditTestModel()
        {
            _testService = Startup.AutofacContainer.Resolve<ITestService>();
        }

        public void LoadModelData(int id)
        {
            var test = _testService.GetTest(id);
            Id = test?.Id;
            Name = test?.Name;
            Fees = test?.Fees;
        }

        internal void Update()
        {
            var test = new Test
            {
                Id = Id.HasValue ? Id.Value : 0,
                Fees = Fees.HasValue ? Fees.Value : 0,
                Name = Name

            };
            _testService.UpdateTest(test);
        }
    }
}
