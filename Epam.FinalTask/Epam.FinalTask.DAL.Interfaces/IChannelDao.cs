using Epam.FinalTask.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FinalTask.DAL.Interfaces
{
    public interface IChannelDao
    {
        Channel Add(Channel channel);
        Message SendMessage(int ChannelID, Message message);
        Channel GetChannelById(int channelID);
        void AttachUserToChannel(int channelID, int userID);
        IEnumerable<int> UserChannels(int userID);
        IEnumerable<int> ChannelUsers(int channelID);
    }
}
