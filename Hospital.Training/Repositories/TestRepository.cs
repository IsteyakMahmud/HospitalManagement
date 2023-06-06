using Hospital.Data;
using Hospital.Training.Context;
using Hospital.Training.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Training.Repositories
{
    public class TestRepository : Repository<Test, int>,
        ITestRepository
    {
        public TestRepository(ITrainingContext context)
            : base((DbContext)context)
        {

        }
    }
}
