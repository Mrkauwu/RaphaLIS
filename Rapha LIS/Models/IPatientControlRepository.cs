using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapha_LIS.Models
{
    public interface IPatientControlRepository
    {
        void AddPatient(PatientModel patientModel);
        void EditPatient(PatientModel patientModel);
        void DeletePatient(int Id);
        void EditResult(PatientModel patientModel);
        IEnumerable<PatientModel> GetAll();
        IEnumerable<PatientModel> GetByName(string value);
    }
}
