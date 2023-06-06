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
    public class DoctorService : IDoctorService
    {
        private readonly ITrainingUnitOfWork _trainingUnitOfWork;
        private readonly IDateTimeUtility _dateTimeUtility;
        private readonly IMapper _mapper;
        public DoctorService(ITrainingUnitOfWork trainingUnitOfWork,
            IDateTimeUtility dateTimeUtility,
            IMapper mapper)
        {
            _trainingUnitOfWork = trainingUnitOfWork;
            _dateTimeUtility = dateTimeUtility;
            _mapper = mapper;

        }
        public void AddDoctor(Doctor doctor)
        {
            if (doctor == null)
                throw new invalidPerameterException("Doctor details was not provided");

            _trainingUnitOfWork.Doctors.Add(
            _mapper.Map<Entities.Doctor>(doctor)
        );

            _trainingUnitOfWork.Save();
        }

        public void DeleteDoctor(int id)
        {
            _trainingUnitOfWork.Doctors.Remove(id);
            _trainingUnitOfWork.Save();
        }

        public IList<Doctor> GetAllDoctors()
        {
            var doctorEntities = _trainingUnitOfWork.Doctors.GetAll();
            var doctors = new List<Doctor>();

            foreach(var entity in doctorEntities)
            {
                var doctor = _mapper.Map<Doctor>(entity);
                doctors.Add(doctor);
            }

            return doctors;
        }

        public Doctor GetDoctor(int id)
        {
            var doctor = _trainingUnitOfWork.Doctors.GetById(id);

            if (doctor == null) return null;

            return _mapper.Map<Doctor>(doctor);
        }

        public (IList<Doctor> records, int total, int totalDisplay) GetDoctors(int pageIndex, int pageSize, string searchText, string sortText)
        {
            var doctorData = _trainingUnitOfWork.Doctors.GetDynamic(string.IsNullOrWhiteSpace(searchText) ? null :
               x => x.Name.Contains(searchText), sortText, string.Empty,
                pageIndex, pageSize);

            var resultData = (from doctor in doctorData.data
                              select _mapper.Map<Doctor>(doctor)).ToList();

            return (resultData, doctorData.total, doctorData.totalDisplay);
        }

        public void UpdateDoctor(Doctor doctor)
        {
            if (doctor == null)
                throw new InvalidOperationException("Doctor is missing");


            var doctorEntity = _trainingUnitOfWork.Doctors.GetById(doctor.Id);

            if (doctorEntity != null)
            {
                _mapper.Map(doctor, doctorEntity);

                _trainingUnitOfWork.Save();

            }
            else
                throw new InvalidOperationException("Couldn't find doctor");
        }
    }
}
