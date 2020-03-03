using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FinalTask.Entities
{
    public class Account
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public byte[] Password { get; set; }
        public int UserID { get; set; }
    }
}
