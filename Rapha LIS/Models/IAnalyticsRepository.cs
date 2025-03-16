using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapha_LIS.Models
{
    public interface IAnalyticsRepository
    {
        PatientModel? GetPatientByHRI(int patientId);
        void AddPatientAnalytics(PatientModel patientModel);
        void EditPatientAnalytics(PatientModel patientModel);
        List<PatientModel> GetPatientHRI();
    }
}
