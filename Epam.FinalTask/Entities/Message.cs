using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FinalTask.Entities
{
    public class Message
    {
        public int ID { get; set; }
        public int ChannelID { get; set; }
        public int UserID { get; set; }
        public string Text { get; set; }
        public DateTime SendingTime { get; set; }   
    }
}
