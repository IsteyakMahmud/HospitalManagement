using Hospital.Training.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Training.Services
{
    public interface IDoctorService
    {
        IList<Doctor> GetAllDoctors();

        void AddDoctor(Doctor doctor);

        (IList<Doctor> records, int total, int totalDisplay) GetDoctors(int pageIndex,
            int pageSize, string searchText, string sortText);

        Doctor GetDoctor(int id);
        void UpdateDoctor(Doctor doctor);
        void DeleteDoctor(int id);


    }
}
