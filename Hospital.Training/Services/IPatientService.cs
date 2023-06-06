using Hospital.Training.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Training.Services
{
    public interface IPatientService
    {
        IList<Patient> GetAllPatients();

        void AddPatient(Patient patient);

        (IList<Patient> records, int total, int totalDisplay) GetPatients(int pageIndex,
            int pageSize, string searchText, string sortText);

        Patient GetPatient(int id);
        void UpdatePatient(Patient patient);
        void DeletePatient(int id);
    }
}
