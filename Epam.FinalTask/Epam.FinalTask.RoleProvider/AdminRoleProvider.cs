using Epam.FinalTask.DAL.Interfaces;
using Epam.FinalTask.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace Epam.FinalTask.RoleProviders
{
    public class AdminRoleProvider : RoleProvider
    {
        private IRoleDao _roleDao;
        public AdminRoleProvider() {
            _roleDao = DependencyResolver.RoleDao;
        }
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            foreach (var user in usernames)
            {
                foreach (var roleName in roleNames)
                {
                    _roleDao.AddRoleToAccount(user, roleName);
                }
            }
        }
        public override bool IsUserInRole(string username, string roleName)
        {
            return _roleDao.GetAllRoles(username).Contains(roleName);
        }
        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            foreach (var user in usernames)
            {
                foreach (var role in roleNames)
                {
                    _roleDao.RemoveRoleFromAccount(user, role);
                }
            }
        }
#region NOT_IMPLEMENTED
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
    #endregion
}
