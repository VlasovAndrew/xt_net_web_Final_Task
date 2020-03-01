using Epam.FinalTask.Entities;
using Epam.FinalTask.BLL.Interfaces;
using Epam.FinalTask.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FinalTask.BLL
{
    public class ChannelBL : IChannelBL
    {
        private IMessageDao _messageDao;
        private IChannelDao _channelDao;

        public ChannelBL(IChannelDao channelDao, IMessageDao messageDao)
        {
            _messageDao = messageDao;
            _channelDao = channelDao;
        }
        public Channel GetChannel(int channelID)
        {
            return _channelDao.GetChannelById(channelID);
        }
        public void AttachUserToChannel(int userID, int channelID)
        {
            _channelDao.AttachUserToChannel(userID, channelID);   
        }
        public IEnumerable<Channel> GetUserChannels(int userID)
        {
            IEnumerable<int> channelsID = _channelDao.UserChannels(userID);
            List<Channel> channels = new List<Channel>();
            foreach (var channelID in channelsID)
            {
                channels.Add(GetChannel(channelID));
            }
            return channels;
        }
        public Channel CreateDirectedChannel(string title, int fromUserID, int toUserID)
        {
            IEnumerable<int> fromUserDirectedChannels = GetDirectedChannels(fromUserID);
            IEnumerable<int> toUserDirectedChannels = GetDirectedChannels(toUserID);
            IEnumerable<int> intersection = fromUserDirectedChannels.Intersect(toUserDirectedChannels);
            if (intersection.Count() == 0)
            {
                Channel channel = _channelDao.Add(new Channel()
                {
                    Title = title,
                });

                _channelDao.AttachUserToChannel(channel.ID, fromUserID);
                _channelDao.AttachUserToChannel(channel.ID, toUserID);
                return channel;
            }
            else
            {
                return _channelDao.GetChannelById(intersection.First());
            }
        }
        private IEnumerable<int> GetDirectedChannels(int userID)
        {
            List<int> directedChannels = new List<int>();
            foreach (var channelID in _channelDao.UserChannels(userID))
            {
                Channel channel = _channelDao.GetChannelById(channelID);
                if (channel.Directed)
                {
                    directedChannels.Add(channel.ID);
                }
            }
            return directedChannels;
        }
    }
}
