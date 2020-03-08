using Epam.FinalTask.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FinalTask.DAL.Interfaces
{
    public interface IMessageDao
    {
        Message GetById(int id);
        void Delete(int Id);
        void Edit(Message message);
    }
}
