﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.FinalTask.Entities;

namespace Epam.FinalTask.BLL.Interfaces
{
    public interface IMessageBL
    {
        Message GetById(int messageID);
        void Delete(int messageID);
        void Update(Message message);
    }
}
