using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace WhatsApp_sol
{
    [Serializable]
    class server
    {
        public List<client> users = new List<client>();
        public List<Message_Log> m = new List<Message_Log>();
        public  server()
        {
            FileStream stream = new FileStream("User.txt", FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();

            try
            {
               
                
                while (stream.Position < stream.Length)
                {
                    users.Add((client)formatter.Deserialize(stream));
                }
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                stream.Close();

            }
            FileStream stream2 = new FileStream("Message_Log.txt", FileMode.Open);
            BinaryFormatter formatter2 = new BinaryFormatter();
            try
            {

               
                //Message_Log msgTxt = (Message_Log)formatter2.Deserialize(stream2);
                while (stream2.Position < stream2.Length)
                {
                    m.Add((Message_Log)formatter.Deserialize(stream2));
                }
            }  
               
            
            catch (Exception ex)
            {

            }
            finally
            {
                stream2.Close();
                
            }

        }
        public void show_User(long phone)
        {

            foreach (var item in users)
                if (item.phone == phone)
                {
                    Console.WriteLine($"Name: {item.name}            Phone: {item.phone}");
                }
        }
        public bool IsUserPresent(long phone)
        {
            Boolean b = false;
            foreach (var item in users)
            {
                if (item.phone == phone)
                {
                    b = true;
                }
            }
            return b;

        }
        public client WasUserPresent(long phone)
        {
            client c = null;
            foreach (var item in users)
            {
                if (item.phone == phone)
                {
                    c = item;
                }
            }
            return c;

        }
        public void EditDetails(long phone)
        {
            if (IsUserPresent(phone))
            {
                foreach (var item in users)
                {
                    if (item.phone == phone)
                    {
                        string old_name = item.name;
                        Console.WriteLine("Enter Name To Change");
                        item.name = Console.ReadLine();
                        Console.WriteLine($"\n\n Your Name Is Changed From {old_name} To {item.name}");

                    }
                }
            }
        }
        private void All_Messages_Log()
        {
            foreach (var i in m)
            {
                Console.WriteLine($"{i.s.phone}   {i.r.phone}   {i.msg}     {i.t}");
            }
        }
        public void Contact_Messages_Log(long number)
        {
            Console.WriteLine("\n\n");
            Console.WriteLine(" Sender\t\t\tReciver\t\t\tMessage\t\t\tDate\t\t\t\tTime");
            foreach (var i in m)
            {
                if (i.s.phone == number || i.r.phone == number)
                {
                    Console.WriteLine(i.s.phone + "\t\t" + i.r.phone + "\t\t" + i.msg + "\t\t" + i.d + "\t" + i.t);
                }
            }
        }
        ~server()
        {
            //try
            //{
            FileStream stream = new FileStream("User.txt", mode: FileMode.OpenOrCreate);
            BinaryFormatter formatter = new BinaryFormatter();
            foreach (client i in users)
            {
                formatter.Serialize(stream, i);
            }
            stream.Close();
            
                FileStream stream2 = new FileStream("Message_Log.txt", mode: FileMode.OpenOrCreate);
                BinaryFormatter formatter2 = new BinaryFormatter();
                foreach (Message_Log i in m)
                {
                    formatter.Serialize(stream, i);
                }
                stream.Close();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //}
        }

    }
}
