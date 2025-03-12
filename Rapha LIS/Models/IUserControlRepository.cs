using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapha_LIS.Models
{
    public interface IUserControlRepository
    {
        void AddUser(UserModel userModel);
        void EditUser(UserModel userModel);
        void DeleteUser(int Id);
        IEnumerable<UserModel> GetAll();
        IEnumerable<UserModel> GetByName(string value);
    }
}
