using Epam.FinalTask.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FinalTask.BLL.Interfaces
{
    public interface IAccountBL
    {
        Account СreateAccount(string login, string password, int userID = 0);
        Account Add(Account account); 
        bool CheckPassword(string login, string password);
        void AttachUserToAccount(string login, int userID);
        bool AccountExists(string login);
        int GetUserIDByLogin(string login);
    }
}
