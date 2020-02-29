using Entities;
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
        void DeleteMessage(int channelID, int messageID);
        IEnumerable<int> UserChannels(int userID);
    }
}
