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
        public static IMessageDao MessageDao { get; }
        public static IChannelDao ChannelDao { get; }
        
        public static IChannelBL ChannelBL { get; }
        static DependencyResolver()
        {
            UserDao = new SQLUserDao();
            UserBL = new UserBL(UserDao);
            MessageDao = new SQLMessageDao();
            ChannelDao = new SQLChannelDao();
            ChannelBL = new ChannelBL(ChannelDao, MessageDao);
        }
    }
}
