using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FinalTask.DAL.Interfaces
{
    public interface IRoleDao
    {
        void AddRoleToAccount(string login, string role);
        void RemoveRoleFromAccount(string login, string role);
        IEnumerable<string> GetAllRoles(string login);
    }
}
