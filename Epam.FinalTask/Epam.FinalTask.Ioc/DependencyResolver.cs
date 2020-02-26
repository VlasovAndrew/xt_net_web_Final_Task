using Epam.FinalTask.BLL;
using Epam.FinalTask.BLL.Interfaces;
using Epam.FinalTask.DAL;
using Epam.FinalTask.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FinalTask.Ioc
{
    public static class DependencyResolver
    {
        public static IUserDao UserDao { get; }
        public static IUserBL UserBL { get; }
        static DependencyResolver()
        {
            UserDao = new RAMUserDao();
            UserBL = new UserBL(UserDao);
        }
    }
}
