using Epam.FinalTask.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Epam.FinalTask.Ioc;
using System.Web.Security;

namespace Epam.FinalTask.WebPL.Helpers
{
    public static class LoginRequests
    {
        public static string SignIn(string login, string password)
        {
            IAccountBL accountBL = DependencyResolver.AccountBL;
            if (!accountBL.AccountExists(login))
            {
                return "Неверный логин";
            }

            bool result = accountBL.CheckPassword(login, password);
            if (!result)
            {
                return "Неверный пароль";
            }
            else {
                FormsAuthentication.SetAuthCookie(login, true);
                return null;
            }
        }
    }
}