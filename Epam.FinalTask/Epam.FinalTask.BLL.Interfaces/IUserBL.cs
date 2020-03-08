using Epam.FinalTask.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FinalTask.BLL.Interfaces
{
    public interface IUserBL
    {
        UserDTO GetById(int id);
        IEnumerable<UserDTO> GetAll();
        UserDTO Add(UserDTO userDTO);
        void AddFriend(int userID, int friendID);
        void RemoveFriend(int userID, int friendID);
        IEnumerable<UserDTO> Search(Dictionary<string, string> searchParams);
        void Update(UserDTO user);
        void Delete(int userID);
    }
}
