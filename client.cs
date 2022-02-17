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
        public string pwd;


        public client(string name, long phone,string pwd, server S)
        {
            this.name = name;
            this.phone = phone;
            server = S;
            this.pwd = pwd;

        }
        public Dictionary<String, long> Contants_List = new Dictionary<String, long>();

    }
}