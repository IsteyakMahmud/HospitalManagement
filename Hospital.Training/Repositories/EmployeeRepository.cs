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
    public class EmployeeRepository : Repository<Employee, int>
        , IEmployeeRepository
    {
        public EmployeeRepository(ITrainingContext context)
            : base((DbContext)context)
        {

        }
    }
}
