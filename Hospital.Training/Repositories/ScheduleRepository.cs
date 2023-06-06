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
    public class ScheduleRepository : Repository<Schedule, int>,
        IScheduleRepository
    {
        public ScheduleRepository(ITrainingContext context)
            : base((DbContext)context)
        {

        }
    }
    
}
