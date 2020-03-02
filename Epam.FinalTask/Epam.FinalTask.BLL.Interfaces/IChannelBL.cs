using Epam.FinalTask.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FinalTask.BLL.Interfaces
{
    public interface IChannelBL
    {
        Channel GetById(int channelID);
        IEnumerable<Channel> GetUserChannels(int userID);
        Channel CreateDirectedChannel(string title, int fromUserID, int toUserID);
        IEnumerable<Message> GetMessagesFromChannel(int channelID);
        IEnumerable<UserDTO> GetChannelUsers(int channelID);
        Message SendMessageToChannel(int channelD, Message message);
    }
}
