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
    public class PatientService : IPatientService
    {
        private readonly ITrainingUnitOfWork _trainingUnitOfWork;
        private readonly IDateTimeUtility _dateTimeUtility;
        private readonly IMapper _mapper;
        public PatientService(ITrainingUnitOfWork trainingUnitOfWork,
            IDateTimeUtility dateTimeUtility,
            IMapper mapper)
        {
            _trainingUnitOfWork = trainingUnitOfWork;
            _dateTimeUtility = dateTimeUtility;
            _mapper = mapper;

        }
        public void AddPatient(Patient patient)
        {
            if (patient == null)
                throw new invalidPerameterException("Patient details was not provided");

            _trainingUnitOfWork.Patients.Add(
            _mapper.Map<Entities.Patient>(patient)
        );

            _trainingUnitOfWork.Save();
        }

        public void DeletePatient(int id)
        {
            _trainingUnitOfWork.Patients.Remove(id);
            _trainingUnitOfWork.Save();
        }


        public IList<Patient> GetAllPatients()
        {
            var patientEntities = _trainingUnitOfWork.Patients.GetAll();
            var patients = new List<Patient>();

            foreach (var entity in patientEntities)
            {
                var patient = _mapper.Map<Patient>(entity);
                patients.Add(patient);
            }

            return patients;
        }

        public Patient GetPatient(int id)
        {
            var patient = _trainingUnitOfWork.Patients.GetById(id);

            if (patient == null) return null;

            return _mapper.Map<Patient>(patient);
        }

        public (IList<Patient> records, int total, int totalDisplay) GetPatients(int pageIndex, int pageSize, string searchText, string sortText)
        {
            var patientData = _trainingUnitOfWork.Patients.GetDynamic(string.IsNullOrWhiteSpace(searchText) ? null :
               x => x.Name.Contains(searchText), sortText, string.Empty,
                pageIndex, pageSize);

            var resultData = (from patient in patientData.data
                              select _mapper.Map<Patient>(patient)).ToList();

            return (resultData, patientData.total, patientData.totalDisplay);
        }

        public void UpdatePatient(Patient patient)
        {
            if (patient == null)
                throw new InvalidOperationException("Patient is missing");


            var patientEntity = _trainingUnitOfWork.Patients.GetById(patient.Id);

            if (patientEntity != null)
            {
                _mapper.Map(patient, patientEntity);

                _trainingUnitOfWork.Save();

            }
            else
                throw new InvalidOperationException("Couldn't find Patient");
        }
    }
}
