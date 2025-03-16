
using Microsoft.Data.SqlClient;
using MVP_LEARNING.Repositories;
using Rapha_LIS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapha_LIS.Repositories
{
    public class UserRepository : BaseRepository, IUserControlRepository
    {
        public UserRepository(string ConnectionString)
        {
            this.connectionString = ConnectionString;
        }
        /*In switching to code first
         * using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Rapha_LIS.Data;
using Rapha_LIS.Models;

namespace Rapha_LIS.Repositories
{
    public class UserRepository : IUserControlRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddUser(UserModel userModel)
        {
            _context.Users.Add(userModel);
            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public void EditUser(UserModel userModel)
        {
            _context.Users.Update(userModel);
            _context.SaveChanges();
        }

        public IEnumerable<UserModel> GetAll()
        {
            return _context.Users.OrderByDescending(u => u.DateCreated).ToList();
        }

        public IEnumerable<UserModel> GetByName(string value)
        {
            return _context.Users
                .Where(u => u.Id.ToString() == value || u.LastName.StartsWith(value))
                .OrderByDescending(u => u.DateCreated)
                .ToList();
        }
    }
}

         */

        public void AddUser(UserModel userModel)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO Users2 (FirstName, LastName, MiddleInitial, Age, Sex, Birthdate, " +
                        "Address, CivilStatus, Religion, Contact) VALUES (@FirstName, @LastName, @MiddleInitial, @Age, " +
                        "@Sex, @Birthdate, @Address, @CivilStatus, @Religion, @Contact)";

                    command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = userModel.FirstName;
                    command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = userModel.LastName;
                    command.Parameters.Add("@MiddleInitial", SqlDbType.NVarChar).Value = userModel.MiddleInitial;
                    command.Parameters.Add("@Age", SqlDbType.Int).Value = userModel.Age;
                    command.Parameters.Add("@Sex", SqlDbType.NVarChar).Value = userModel.Sex;
                    command.Parameters.Add("@Birthdate", SqlDbType.Date).Value = userModel.Birthdate;
                    command.Parameters.Add("@Address", SqlDbType.NVarChar).Value = userModel.Address;
                    command.Parameters.Add("@CivilStatus", SqlDbType.NVarChar).Value = userModel.CivilStatus;
                    command.Parameters.Add("@Religion", SqlDbType.NVarChar).Value = userModel.Religion;
                    command.Parameters.Add("@Contact", SqlDbType.NVarChar).Value = userModel.Contact;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteUser(int Id)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "DELETE FROM Users2 WHERE Id=@Id";
                command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
                command.ExecuteNonQuery();
            }
        }

        public void EditUser(UserModel userModel)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"
            UPDATE Users2 
            SET FirstName = @FirstName, 
                LastName = @LastName, 
                MiddleInitial = @MiddleInitial,
                Age = @Age,
                Sex = @Sex,
                Birthdate = @Birthdate,
                Address = @Address,
                CivilStatus = @CivilStatus,
                Religion = @Religion,
                Contact = @Contact
            WHERE Id = @Id"
                ;

                command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = userModel.FirstName;
                command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = userModel.LastName;
                command.Parameters.Add("@MiddleInitial", SqlDbType.NVarChar).Value = userModel.MiddleInitial;
                command.Parameters.Add("@Age", SqlDbType.Int).Value = userModel.Age;
                command.Parameters.Add("@Sex", SqlDbType.NVarChar).Value = userModel.Sex;
                command.Parameters.Add("@Birthdate", SqlDbType.Date).Value = userModel.Birthdate;
                command.Parameters.Add("@Address", SqlDbType.NVarChar).Value = userModel.Address;
                command.Parameters.Add("@CivilStatus", SqlDbType.NVarChar).Value = userModel.CivilStatus;
                command.Parameters.Add("@Religion", SqlDbType.NVarChar).Value = userModel.Religion;
                command.Parameters.Add("@Contact", SqlDbType.NVarChar).Value = userModel.Contact;
                command.Parameters.Add("@Id", SqlDbType.Int).Value = userModel.Id;
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<UserModel> GetAll()
        {
            var userList = new List<UserModel>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Users2 ORDER BY DateCreated DESC";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var userModel = new UserModel();

                        //patientModel.Number = Convert.ToInt32(reader["Number"]);
                        userModel.Id = Convert.ToInt32(reader["Id"]);
                        userModel.FirstName = reader["FirstName"].ToString();
                        userModel.LastName = reader["LastName"].ToString();
                        userModel.MiddleInitial = reader["MiddleInitial"].ToString();
                        userModel.Age = Convert.ToInt32(reader["Age"]);
                        userModel.Sex = reader["Sex"].ToString();
                        userModel.Birthdate = Convert.ToDateTime(reader["Birthdate"]);
                        userModel.Address = reader["Address"].ToString();
                        userModel.CivilStatus = reader["CivilStatus"].ToString();
                        userModel.Religion = reader["Religion"].ToString();
                        userModel.Contact = reader["Contact"].ToString();
                        userModel.DateCreated = Convert.ToDateTime(reader["DateCreated"]);
                        userList.Add(userModel);
                    }
                }
            }
            return userList;
        }

        public IEnumerable<UserModel> GetByName(string value)
        {
            var userList = new List<UserModel>();
            string userName = value;
            int Id = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"    
                                        SELECT * FROM Users2
                                        WHERE Id = @Id or LastName LIKE @LastName + '%'
                                        ORDER BY DateCreated DESC";
                command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = userName;
                command.Parameters.Add("@Id", SqlDbType.NVarChar).Value = Id;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var userModel = new UserModel();

                        //patientModel.Number = Convert.ToInt32(reader["Number"]);
                        userModel.Id = Convert.ToInt32(reader["Id"]);
                        userModel.FirstName = reader["FirstName"].ToString();
                        userModel.LastName = reader["LastName"].ToString();
                        userModel.MiddleInitial = reader["MiddleInitial"].ToString();
                        userModel.Age = Convert.ToInt32(reader["Age"]);
                        userModel.Sex = reader["Sex"].ToString();
                        userModel.Birthdate = Convert.ToDateTime(reader["Birthdate"]);
                        userModel.Address = reader["Address"].ToString();
                        userModel.CivilStatus = reader["CivilStatus"].ToString();
                        userModel.Religion = reader["Religion"].ToString();
                        userModel.Contact = reader["Contact"].ToString();
                        userModel.DateCreated = Convert.ToDateTime(reader["DateCreated"]);
                        userList.Add(userModel);
                    }
                }
            }
            return userList;
        }
    }
}
