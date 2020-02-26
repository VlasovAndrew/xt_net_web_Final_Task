using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FinalTask.Entities
{
    public class User : AbstractUser
    {
        public User() {
            Friends = new HashSet<int>();
        }
        public IEnumerable<int> Friends { get; set; }
        public string ImagePath { get; set; }
    }
}
