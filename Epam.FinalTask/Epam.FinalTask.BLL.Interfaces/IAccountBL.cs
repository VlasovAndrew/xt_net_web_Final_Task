using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FinalTask.BLL.Interfaces
{
    public interface IAccountBL
    {
        bool AddAccount(string login, string password, int userID = 0);
        bool CheckPassword(string login, string password);
        void AttachUserToAccount(string login, int userID);
    }
}
