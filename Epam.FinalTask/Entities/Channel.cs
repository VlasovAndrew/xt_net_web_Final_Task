using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FinalTask.Entities
{
    public class Channel
    {
        public Channel()
        {
            Messages = new List<int>();
        }
        public int ID { get; set; }
        public string Title { get; set; }
        public ICollection<int> Messages { get; private set; }
        public bool Directed { get; set; }
    }
}
