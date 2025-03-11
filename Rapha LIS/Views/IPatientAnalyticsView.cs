using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapha_LIS.Views
{
     public interface IPatientAnalyticsView
    {
        string SearchQueryById { get; set; }

        event EventHandler? SearchRequestedById;

        void BindPatientAnalyticsList(BindingSource patientAnalyticsList);
        void Show();
    }
}
