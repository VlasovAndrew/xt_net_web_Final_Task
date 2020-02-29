﻿using Epam.FinalTask.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FinalTask.BLL.Interfaces
{
    public interface IUserBL
    {
        UserDTO GetById(int id);
        IEnumerable<UserDTO> GetAll();
        UserDTO Add(UserDTO userDTO); 
    }
}