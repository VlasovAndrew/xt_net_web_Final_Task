using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.FinalTask.Entities;
using Epam.FinalTask.DAL.Interfaces;

namespace Epam.FinalTask.DAL
{
    public class RAMUserDao : IUserDao
    {
        private Dictionary<int, User> _data;
        public RAMUserDao() 
        {
            _data = new Dictionary<int, User>();
            _data[0] = new User()
            { 
                ID = 0,
                Name = "Andrew",
                Surname = "Vlasov",
                City = "Saratov",
            };
        }
        public User Add(User user)
        {
            int userId = _data.Count == 0 ? 0 : _data.Keys.Max();
            user.ID = userId;
            _data[userId] = user;
            return user;
        }
        public User GetById(int id)
        {
            return _data[id];
        }
        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            return _data.Values;
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
