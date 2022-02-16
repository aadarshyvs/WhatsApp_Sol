using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsApp_sol
{
    [Serializable]
    class Message_Log
    {
        public client s;
        public client r;
        public string msg;
        public string d;
        public string t;

        public Message_Log(client sender, client reciver, string message, string date, string time)
        {
            s = sender;
            r = reciver;
            msg = message;
            d = date;
            t = time;

        }
    }


}
