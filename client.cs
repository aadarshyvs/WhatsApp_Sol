using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsApp_sol
{

    [Serializable]
    class client
    {
        public string name;
        public long phone;
        public server server;


        public client(string name, long phone, server S)
        {
            this.name = name;
            this.phone = phone;
            server = S;

        }
        public Dictionary<String, long> Contants_List = new Dictionary<String, long>();

    }
}