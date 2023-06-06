using Hospital.Training.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Training.Services
{
    public interface ITestService
    {
        IList<Test> GetAllTests();

        void AddTest(Test test);

        (IList<Test> records, int total, int totalDisplay) GetTests(int pageIndex,
            int pageSize, string searchText, string sortText);

        Test GetTest(int id);
        void UpdateTest(Test test);
        void DeleteTest(int id);
    }
}
