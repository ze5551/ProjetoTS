using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTS
{
    internal class Message
    {
        public string message { get; set; }
        public string sender { get; set; }
        public string receiver { get; set; }
        public DateTime date { get; set; }
        public Message(string messages, string sender, string receiver)
        {
            
            date = DateTime.Now;
        }
    }
}
