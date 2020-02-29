using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FinalTask.Entities
{
    public abstract class AbstractUser
    {
        public AbstractUser() {
            Friends = new HashSet<int>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public int ApartmentNumber { get; set; } = 0;
        public ICollection<int> Friends { get; set; }
    }
}
