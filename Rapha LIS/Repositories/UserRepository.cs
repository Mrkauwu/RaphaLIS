
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MVP_LEARNING.Repositories;
using Rapha_LIS.Data;
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
            var existingUser = _context.Users.Find(userModel.Id);
            if (existingUser != null)
            {
                existingUser.FirstName = userModel.FirstName;
                existingUser.LastName = userModel.LastName;
                existingUser.MiddleInitial = userModel.MiddleInitial;
                existingUser.Age = userModel.Age;
                existingUser.Sex = userModel.Sex;
                existingUser.Birthdate = userModel.Birthdate;
                existingUser.Address = userModel.Address;
                existingUser.CivilStatus = userModel.CivilStatus;
                existingUser.Religion = userModel.Religion;
                existingUser.Contact = userModel.Contact;
                _context.SaveChanges();
            }
        }

        public IEnumerable<UserModel> GetAll()
        {
            return _context.Users.OrderByDescending(u => u.DateCreated).ToList();
        }

        public IEnumerable<UserModel> GetByName(string value)
        {
            return _context.Users
                .AsNoTracking()
                .Where(u => EF.Functions.Like(u.LastName, $"%{value}%"))
                .OrderByDescending(u => u.DateCreated)
                .ToList();
        }
    }
}

