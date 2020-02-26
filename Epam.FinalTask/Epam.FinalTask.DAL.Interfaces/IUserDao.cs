using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.FinalTask.Entities;

namespace Epam.FinalTask.DAL.Interfaces
{
    public interface IUserDao
    {
        User Add(User user);
        User GetById(int id);
        IEnumerable<User> GetAll();
        void DeleteById(int id);
        void Update(User user);
    }
}
