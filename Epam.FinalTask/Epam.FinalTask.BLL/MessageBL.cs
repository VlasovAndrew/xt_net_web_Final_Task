using Epam.FinalTask.DAL.Interfaces;
using Epam.FinalTask.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.FinalTask.BLL.Interfaces;

namespace Epam.FinalTask.BLL
{
    public class MessageBL : IMessageBL
    {
        private IMessageDao _messageDao;
        public MessageBL(IMessageDao messageDao)
        {
            _messageDao = messageDao;
        }

        public void Delete(int messageID)
        {
            _messageDao.Delete(messageID);
        }

        public Message GetById(int messageID)
        {
            return _messageDao.GetById(messageID);
        }

        public void Update(Message message)
        {
            _messageDao.Edit(message);
        }
    }
}
