using Epam.FinalTask.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FinalTask.DAL.Interfaces
{
    public interface IAccountDao
    {
        Account Add(Account account);
        Account GetAccountByLogin(string login);
        int GetUserIDByLogin(string login);
        void AttachUserToAccount(string login, int userID);
        bool AccountExists(string login);
    }
}
