using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FinalTask.DAL.Interfaces
{
    public interface IMessageDao
    {
        Message Add(Message message);
        Message GetById(int id);
        void Delete(int Id);
        Message Edit(Message message);
    }
}
