
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using MVP_LEARNING.Repositories;
using Rapha_LIS.Data;
using Rapha_LIS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapha_LIS.Repositories
{
    public class PatientRepository : BaseRepository, IPatientControlRepository, IAnalyticsRepository, IPatientResultRepository
    {
        private readonly AppDbContext _context;
        public PatientRepository(AppDbContext context)
        {
            _context = context;
        }

        //Analytics

        public PatientModel? GetPatientByHRI(int patientId)
        {
            return _context.Patients.FirstOrDefault(p => p.Id == patientId);
        }

        public List<PatientModel> GetPatientHRI()
        {
            return _context.Patients
            .Where(p => p.Result != "Pending") // Filtering condition
            .OrderByDescending(p => p.DateCreated)
            .AsNoTracking() // Optimizes read-only queries
            .ToList();
        }



        public void AddPatientAnalytics(PatientModel patientModel)
        {
            var analyticsPatient = new AnalyticsPatientModel
            {
                Id = patientModel.Id,
                FirstName = patientModel.FirstName,
                LastName = patientModel.LastName,
                MiddleInitial = patientModel.MiddleInitial,
                Age = patientModel.Age,
                Birthdate = patientModel.Birthdate,
                Address = patientModel.Address,
                CivilStatus = patientModel.CivilStatus,
                Religion = patientModel.Religion,
                Contact = patientModel.Contact,
                DateCreated = patientModel.DateCreated,
                Test = patientModel.Test,
                TestDescription = patientModel.TestDescription,
                Result = patientModel.Result
            };

            var existingPatient = _context.AnalyticsPatients
                .FirstOrDefault(p => p.Id == analyticsPatient.Id);

            if (existingPatient == null)
            {
                _context.AnalyticsPatients.Add(analyticsPatient);
            }
            else
            {
                _context.Entry(existingPatient).CurrentValues.SetValues(analyticsPatient);
            }

            _context.SaveChanges();
        }

        // ✅ New method to retrieve saved analytics data
        public AnalyticsPatientModel? GetSavedAnalyticsPatient(int patientId)
        {
            return _context.AnalyticsPatients.FirstOrDefault(p => p.Id == patientId);
        }


        public void EditPatientAnalytics(AnalyticsPatientModel patientModel)
        {
            var existingPatient = _context.AnalyticsPatients
        .AsNoTracking()
        .FirstOrDefault(p => p.Id == patientModel.Id);

            if (existingPatient != null)
            {
                // Convert PatientModel to AnalyticsPatientModel
                var updatedPatient = new AnalyticsPatientModel
                {
                    Id = patientModel.Id,
                    FirstName = patientModel.FirstName,
                    LastName = patientModel.LastName,
                    MiddleInitial = patientModel.MiddleInitial,
                    Age = patientModel.Age,
                    Birthdate = patientModel.Birthdate,
                    Address = patientModel.Address,
                    CivilStatus = patientModel.CivilStatus,
                    Religion = patientModel.Religion,
                    Contact = patientModel.Contact,
                    DateCreated = patientModel.DateCreated,
                    Test = patientModel.Test,
                    Result = patientModel.Result
                };
                _context.AnalyticsPatients.Update(updatedPatient);
                _context.SaveChanges();
            }
        }


        public void AddPatient(PatientModel patientModel)
        {
            _context.Patients.Add(patientModel);
            _context.SaveChanges(); // Saves changes to the database
        }


        public void DeletePatient(int Id)
        {
            var patient = _context.Patients.Find(Id);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
                _context.SaveChanges();
            }
        }

        public void EditPatient(PatientModel patient)
        {
            var existingPatient = _context.Patients.Find(patient.Id);
            if (existingPatient != null)
            {
                existingPatient.FirstName = patient.FirstName;
                existingPatient.LastName = patient.LastName;
                existingPatient.MiddleInitial = patient.MiddleInitial;
                existingPatient.Age = patient.Age;
                existingPatient.Sex = patient.Sex;
                existingPatient.Birthdate = patient.Birthdate;
                existingPatient.Address = patient.Address;
                existingPatient.CivilStatus = patient.CivilStatus;
                existingPatient.Religion = patient.Religion;
                existingPatient.Contact = patient.Contact;
                existingPatient.Test = patient.Test;

                _context.SaveChanges();
            }
        }


        public void EditResult(PatientModel patientModel)
        {
            var patient = _context.Patients.Find(patientModel.Id);
            if (patient != null)
            {
                patient.Result = patientModel.Result;
                _context.SaveChanges();
            }
        }

        public IEnumerable<PatientModel> GetAll()
        {
            return _context.Patients
                .OrderByDescending(p => p.DateCreated) // Order by DateCreated (descending)
                .AsNoTracking() // Improves performance for read-only queries
                .ToList();
        }


        public IEnumerable<PatientModel> GetByName(string value)
        {
            return _context.Patients
                .AsNoTracking()
                .Where(p => EF.Functions.Like(p.LastName, $"%{value}%"))
                .OrderByDescending(p => p.DateCreated)
                .ToList();
        }

        //Result

        public IEnumerable<PatientModel> GetPatientResultByName(string value)
        {
            return _context.Patients
                .AsNoTracking()
                .Where(p => EF.Functions.Like(p.LastName, $"%{value}%"))
                .OrderByDescending(p => p.DateCreated)
                .AsNoTracking() // Improves performance for read-only queries
                .ToList();

        }

        public IEnumerable<PatientModel> GetAllPatientResult()
        {
            return _context.Patients
                .Where(p => p.Result != "Pending") // Filtering condition
                .OrderByDescending(p => p.DateCreated)
                .AsNoTracking() // Optimizes read-only queries
                .ToList();
        }

    }
}

