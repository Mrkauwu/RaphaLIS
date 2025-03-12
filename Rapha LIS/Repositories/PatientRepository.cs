using Microsoft.Data.SqlClient;
using MVP_LEARNING.Repositories;
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
    public class PatientRepository : BaseRepository, IPatientControlRepository //IAnalyticsRepository
    {
        public PatientRepository(string ConnectionString)
        {
            this.connectionString = ConnectionString;
        }

        public void AddPatient(PatientModel patientModel)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO Patients (FirstName, LastName, MiddleInitial, Age, Sex, Birthdate, " +
                        "Address, CivilStatus, Religion, Contact, Test) VALUES (@FirstName, @LastName, @MiddleInitial, @Age, " +
                        "@Sex, @Birthdate, @Address, @CivilStatus, @Religion, @Contact, @Test)"; 

                    command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = patientModel.FirstName;
                    command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = patientModel.LastName;
                    command.Parameters.Add("@MiddleInitial", SqlDbType.NVarChar).Value = patientModel.MiddleInitial;
                    command.Parameters.Add("@Age", SqlDbType.Int).Value = patientModel.Age;
                    command.Parameters.Add("@Sex", SqlDbType.NVarChar).Value = patientModel.Sex;
                    command.Parameters.Add("@Birthdate", SqlDbType.Date).Value = patientModel.Birthdate;
                    command.Parameters.Add("@Address", SqlDbType.NVarChar).Value = patientModel.Address;
                    command.Parameters.Add("@CivilStatus", SqlDbType.NVarChar).Value = patientModel.CivilStatus;
                    command.Parameters.Add("@Religion", SqlDbType.NVarChar).Value = patientModel.Religion;
                    command.Parameters.Add("@Contact", SqlDbType.NVarChar).Value = patientModel.Contact;
                    command.Parameters.Add("@Test", SqlDbType.NVarChar).Value = patientModel.Test;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeletePatient(int Id)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "delete from Patients where Id=@Id";
                command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
                command.ExecuteNonQuery();
            }

        }

        public void EditPatient(PatientModel patient)
        {
            using (var connection = new SqlConnection(connectionString))    
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"
            UPDATE Patients 
            SET FirstName = @FirstName, 
                LastName = @LastName, 
                MiddleInitial = @MiddleInitial,
                Age = @Age,
                Sex = @Sex,
                Birthdate = @Birthdate,
                Address = @Address,
                CivilStatus = @CivilStatus,
                Religion = @Religion,
                Contact = @Contact,
                Test = @Test
            WHERE Id = @Id";

                command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = patient.FirstName;
                command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = patient.LastName;
                command.Parameters.Add("@MiddleInitial", SqlDbType.NVarChar).Value = patient.MiddleInitial;
                command.Parameters.Add("@Age", SqlDbType.Int).Value = patient.Age;
                command.Parameters.Add("@Sex", SqlDbType.NVarChar).Value = patient.Sex;
                command.Parameters.Add("@Birthdate", SqlDbType.Date).Value = patient.Birthdate;
                command.Parameters.Add("@Address", SqlDbType.NVarChar).Value = patient.Address;
                command.Parameters.Add("@CivilStatus", SqlDbType.NVarChar).Value = patient.CivilStatus;
                command.Parameters.Add("@Religion", SqlDbType.NVarChar).Value = patient.Religion;
                command.Parameters.Add("@Contact", SqlDbType.NVarChar).Value = patient.Contact;
                command.Parameters.Add("@Test", SqlDbType.NVarChar).Value = patient.Test;
                command.Parameters.Add("@Id", SqlDbType.Int).Value = patient.Id;
                command.ExecuteNonQuery();

               
                
            }
        }

        public IEnumerable<PatientModel> GetAll()
        {
            var patientList = new List<PatientModel>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Patients ORDER BY DateCreated desc";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                            var patientModel = new PatientModel();

                            //patientModel.Number = Convert.ToInt32(reader["Number"]);
                            patientModel.Id = Convert.ToInt32(reader["Id"]);
                            patientModel.FirstName = reader["FirstName"].ToString();
                            patientModel.LastName = reader["LastName"].ToString();
                            patientModel.MiddleInitial = reader["MiddleInitial"].ToString();
                            patientModel.Age = Convert.ToInt32(reader["Age"]);
                            patientModel.Sex = reader["Sex"].ToString();
                            patientModel.Birthdate = Convert.ToDateTime(reader["Birthdate"]);
                            patientModel.Address = reader["Address"].ToString();
                            patientModel.CivilStatus = reader["CivilStatus"].ToString();
                            patientModel.Religion = reader["Religion"].ToString();
                            patientModel.Contact = reader["Contact"].ToString();
                            patientModel.DateCreated = Convert.ToDateTime(reader["DateCreated"]);
                            patientModel.Test = reader["Test"].ToString();
                            patientModel.TestDescription = reader["TestDescription"].ToString();
                            patientList.Add(patientModel);
                    }
                }
            }
            return patientList;
        }

        public IEnumerable<PatientModel> GetByName(string value)
        {
            var patientList = new List<PatientModel>();
            string patientName = value;
            int Id = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"    
                                        SELECT * FROM Patients
                                        WHERE Id = @Id or LastName LIKE @LastName + '%'
                                        ORDER BY DateCreated DESC";
                command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = patientName;
                command.Parameters.Add("@Id", SqlDbType.NVarChar).Value = Id;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var patientModel = new PatientModel();

                        //patientModel.Number = Convert.ToInt32(reader["Number"]);
                        patientModel.Id = Convert.ToInt32(reader["Id"]);
                        patientModel.FirstName = reader["FirstName"].ToString();
                        patientModel.LastName = reader["LastName"].ToString();
                        patientModel.MiddleInitial = reader["MiddleInitial"].ToString();
                        patientModel.Age = Convert.ToInt32(reader["Age"]);
                        patientModel.Sex = reader["Sex"].ToString();
                        patientModel.Birthdate = Convert.ToDateTime(reader["Birthdate"]);
                        patientModel.Address = reader["Address"].ToString();
                        patientModel.CivilStatus = reader["CivilStatus"].ToString();
                        patientModel.Religion = reader["Religion"].ToString();
                        patientModel.Contact = reader["Contact"].ToString();
                        patientModel.DateCreated = Convert.ToDateTime(reader["DateCreated"]);
                        patientModel.Test = reader["Test"].ToString();
                        patientModel.TestDescription = reader["TestDescription"].ToString();
                        patientList.Add(patientModel);
                    }
                }
            }
            return patientList;
        }
    }
}
