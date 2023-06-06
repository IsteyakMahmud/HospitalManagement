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
    public class ScheduleService : IScheduleService
    {
        private readonly ITrainingUnitOfWork _trainingUnitOfWork;
        private readonly IDateTimeUtility _dateTimeUtility;
        private readonly IMapper _mapper;
        public ScheduleService(ITrainingUnitOfWork trainingUnitOfWork,
            IDateTimeUtility dateTimeUtility,
            IMapper mapper)
        {
            _trainingUnitOfWork = trainingUnitOfWork;
            _dateTimeUtility = dateTimeUtility;
            _mapper = mapper;

        }
        public void AddSchedule(Schedule schedule)
        {
            if (schedule == null)
                throw new invalidPerameterException("Schedule details was not provided");

            _trainingUnitOfWork.Schedules.Add(
            _mapper.Map<Entities.Schedule>(schedule)
        );

            _trainingUnitOfWork.Save();
        }

        public void DeleteSchedule(int id)
        {
            _trainingUnitOfWork.Schedules.Remove(id);
            _trainingUnitOfWork.Save();
        }

        public IList<Schedule> GetAllSchedules()
        {
            var scheduleEntities = _trainingUnitOfWork.Schedules.GetAll();
            var schedules = new List<Schedule>();

            foreach (var entity in scheduleEntities)
            {
                var schedule = _mapper.Map<Schedule>(entity);
                schedules.Add(schedule);
            }

            return schedules;
        }

        public Schedule GetSchedule(int id)
        {
            var schedule = _trainingUnitOfWork.Schedules.GetById(id);

            if (schedule == null) return null;

            return _mapper.Map<Schedule>(schedule);
        }

        public (IList<Schedule> records, int total, int totalDisplay) GetSchedules(int pageIndex, int pageSize, string searchText, string sortText)
        {
            var scheduleData = _trainingUnitOfWork.Schedules.GetDynamic(string.IsNullOrWhiteSpace(searchText) ? null :
               x => x.PatientName.Contains(searchText), sortText, string.Empty,
                pageIndex, pageSize);

            var resultData = (from schedule in scheduleData.data
                              select _mapper.Map<Schedule>(schedule)).ToList();

            return (resultData, scheduleData.total, scheduleData.totalDisplay);
        }

        public void UpdateSchedule(Schedule schedule)
        {
            if (schedule == null)
                throw new InvalidOperationException("Schedule is missing");


            var scheduleEntity = _trainingUnitOfWork.Schedules.GetById(schedule.Id);

            if (scheduleEntity != null)
            {
                _mapper.Map(schedule, scheduleEntity);

                _trainingUnitOfWork.Save();

            }
            else
                throw new InvalidOperationException("Couldn't find schedule");
        }
    }
}
