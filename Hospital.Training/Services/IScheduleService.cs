using Hospital.Training.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Training.Services
{
    public interface IScheduleService
    {
        IList<Schedule> GetAllSchedules();

        void AddSchedule(Schedule schedule);

        (IList<Schedule> records, int total, int totalDisplay) GetSchedules(int pageIndex,
            int pageSize, string searchText, string sortText);

        Schedule GetSchedule(int id);
        void UpdateSchedule(Schedule schedule);
        void DeleteSchedule(int id);
    }
}
