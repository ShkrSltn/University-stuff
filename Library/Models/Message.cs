using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Message
    {
        public string str_message;
        public bool error;

        public Message(string message, bool error)
        {
            this.str_message = message;
            this.error = error;
        }

        public Message()
        {
            this.str_message = "";
            this.error = false;
        }

        public void setMessage(string message, bool error)
        {
            this.str_message = message;
            this.error = error;
        }
    }
}
