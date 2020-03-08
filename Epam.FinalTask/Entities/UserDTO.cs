using Epam.FinalTask.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace Epam.FinalTask.Entities
{
    public class UserDTO : AbstractUser
    {
        public UserDTO() {
            Avatar = new byte[] { };
        }
        public byte[] Avatar { get; set; }
    }
}
