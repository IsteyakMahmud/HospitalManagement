using AutoMapper;
using Hospital.Common.Utilities;
using Hospital.Training.BusinessObjects;
using Hospital.Training.Exceptions;
using Hospital.Training.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Training.Services
{
    public class TestService : ITestService
    {
        private readonly ITrainingUnitOfWork _trainingUnitOfWork;
        private readonly IDateTimeUtility _dateTimeUtility;
        private readonly IMapper _mapper;
        public TestService(ITrainingUnitOfWork trainingUnitOfWork,
            IDateTimeUtility dateTimeUtility,
            IMapper mapper)
        {
            _trainingUnitOfWork = trainingUnitOfWork;
            _dateTimeUtility = dateTimeUtility;
            _mapper = mapper;

        }
        public void AddTest(Test test)
        {
            if (test == null)
                throw new invalidPerameterException("Test details was not provided");

            _trainingUnitOfWork.Tests.Add(
            _mapper.Map<Entities.Test>(test)
        );

            _trainingUnitOfWork.Save();
        }


        public void DeleteTest(int id)
        {
            _trainingUnitOfWork.Tests.Remove(id);
            _trainingUnitOfWork.Save();
        }

        public IList<Test> GetAllTests()
        {
            var testEntities = _trainingUnitOfWork.Tests.GetAll();
            var tests = new List<Test>();

            foreach (var entity in testEntities)
            {
                var test = _mapper.Map<Test>(entity);
                tests.Add(test);
            }

            return tests;
        }

        public Test GetTest(int id)
        {
            var test = _trainingUnitOfWork.Tests.GetById(id);

            if (test == null) return null;

            return _mapper.Map<Test>(test);
        }

        public (IList<Test> records, int total, int totalDisplay) GetTests(int pageIndex, int pageSize, string searchText, string sortText)
        {
            var testData = _trainingUnitOfWork.Tests.GetDynamic(string.IsNullOrWhiteSpace(searchText) ? null :
               x => x.Name.Contains(searchText), sortText, string.Empty,
                pageIndex, pageSize);

            var resultData = (from test in testData.data
                              select _mapper.Map<Test>(test)).ToList();
            return (resultData, testData.total, testData.totalDisplay);
        }

        public void UpdateTest(Test test)
        {
            if (test == null)
                throw new InvalidOperationException("Test is missing");


            var testEntity = _trainingUnitOfWork.Tests.GetById(test.Id);

            if (testEntity != null)
            {
                _mapper.Map(test, testEntity);
                _trainingUnitOfWork.Save();

            }
            else
                throw new InvalidOperationException("Couldn't find tests");
        }
    }
}
