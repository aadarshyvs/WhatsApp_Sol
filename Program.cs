using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsApp_sol
{
    class Program
    {
        static server s = new server();

        public static string password()
        {
            string pwd = null;
            while (true)
            {
                var key = Console.ReadKey(true);
                
                if (key.Key == ConsoleKey.Enter)
                    break;
                else
                   Console.Write("*");
                pwd += key.KeyChar;
            }
            Console.WriteLine();
            return pwd;
        }
        static void Main(string[] args)
        {

            int i = -1;
            while (i < 0)
            {
                switch (Menu())
                {
                    case 0:
                        i = 0;
                        Environment.Exit(0);
                        break;
                    case 1:
                        add();
                        break;
                    case 2:
                        edit();
                        break;
                    case 3:
                        show();
                        break;
                    case 4:
                        //ADD PASSWORD FROM HEAR ONWORDS
                        contact_add();
                        break;
                    case 5:
                        contact_view();
                        break;
                    case 6:
                        sendmsg();
                        break;
                    case 7:
                        Allmsg_Contact();
                        break;

                }
                Console.WriteLine("\n\nPress Any Key.........");
                Console.ReadKey();

            }

            Console.ReadKey();

        }

        public static void add()
        {
            Console.WriteLine("Enter The  Name : ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter The Phone Number : ");
            long phone = Convert.ToInt64(Console.ReadLine());
 
                if (s.IsUserPresent(phone))
                {
                    Console.WriteLine("\n" + phone + " Aldeary exists , ");
                }
                else
                {
                Console.WriteLine("Enter Your Password : ");
                string pwd = password();
                Console.WriteLine();
                Console.WriteLine("Enter Your Password Again To Confirm  : ");
                string pwdchk = password();
                if (pwd != pwdchk)
                {
                    Console.WriteLine("Password Miss Match ");
                }
                else
                {
                    client c = new client(name, phone, pwd, s);
                    s.users.Add(c);
                }
                }
            
        }
        public static void edit()
        {
            Console.WriteLine("Enter The Phone Number : ");
            long phone = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter Your Password : ");
            string pwd = password();
            if (s.Check_Password(phone, pwd))
            {
                s.EditDetails(phone);
            }
            else
            {
                Console.WriteLine("Wrong Password ");
            }

        }
        public static void contact_add()
        {
            Console.WriteLine("Enter The Your Phone Number : ");
            long u_phone = Convert.ToInt64(Console.ReadLine());
            {
                client cResult = s.WasUserPresent(u_phone);
                if (cResult != null)
                {
                    Console.WriteLine("Enter Your Password : ");
                    string pwd = password();
                    if (s.Check_Password(u_phone, pwd))
                    {


                        Console.WriteLine("Enter The Contact Name : ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter The Phone Contact Number : ");
                        long phone = Convert.ToInt64(Console.ReadLine());
                        if (s.IsUserPresent(phone))
                        {
                            if (u_phone != phone)
                            {
                                cResult.Contants_List.Add(name, phone);
                                Console.WriteLine($"Hello {cResult.name} , {phone} Is Added With Name :{name}");
                            }
                            else
                            {
                                Console.WriteLine("You Cannot Add Your Phone Number To Your Contact List");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"{phone} Does Not Exists");
                        }
                    }
                
                else
                {
                    Console.WriteLine("Wrong Password ");
                }

            }
                else
                {
                    Console.WriteLine("The Number Your Have Entered Does Not Exists ");
                }
            }

        }
        public static void show()
        {
            Console.WriteLine("Enter Your Phone To Show details : ");
            long phone = Convert.ToInt64(Console.ReadLine());

            if (s.IsUserPresent(phone))
            {
                Console.WriteLine("Enter Your Password : ");
                string pwd = password();
                if (s.Check_Password(phone, pwd))
                {
                    s.show_User(phone);
                }
                else
                {
                    Console.WriteLine("Wrong Password ");
                }
               
            }
            else
            {
                Console.WriteLine($"The Number : {phone} is in valid");
            }

        }
        
        public static void contact_view()
        {
            Console.WriteLine("Enter The  Phone Number : ");
            long u_phone = Convert.ToInt64(Console.ReadLine());
            client cResult = s.WasUserPresent(u_phone);
            if (cResult != null)
            {
                Console.WriteLine("Enter Your Password : ");
                string pwd = password();
                if (s.Check_Password(u_phone, pwd))
                {
                
                foreach (var item in cResult.Contants_List)
                {
                    Console.WriteLine($"Name: {item.Key}            Phone: {item.Value}");
                }
                }
                else
                {
                    Console.WriteLine("Wrong Password ");
                }

            }
            else
            {
                Console.WriteLine($"The Number : {u_phone} is in valid");
            }

        }
        public static void sendmsg()
        {
            Console.WriteLine("Enter Your  Phone Number : ");
            long s_phone = Convert.ToInt64(Console.ReadLine());
            client sender = s.WasUserPresent(s_phone);
            if (sender != null)
            {
                Console.WriteLine("Enter Your Password : ");
                string pwd = password();
                if (s.Check_Password(s_phone, pwd))
                {

                    Console.WriteLine("Enter The  Phone Number To Send Message : ");
                    long r_phone = Convert.ToInt64(Console.ReadLine());
                    client reciver = s.WasUserPresent(r_phone);
                    if (sender != null)
                    {
                        Console.Write("Enter The Message : ");
                        string message = Console.ReadLine();
                        Message_Log msg = new Message_Log(sender, reciver, message, DateTime.Now.ToString("dd MMMM yyyy"), DateTime.Now.ToString("HH: mm:ss"));
                        s.m.Add(msg);
                    }
                    else
                    {
                        Console.WriteLine($"The Number : {r_phone} is in valid");
                    }

                }
                else
                {
                    Console.WriteLine("Wrong Password ");
                }
            }
            else
            {
                Console.WriteLine($"The Number : {s_phone} is in valid");
            }


        }
        public static void Allmsg_Contact()
        {
            Console.WriteLine("Enter Your  Phone Number : ");
            long phone = Convert.ToInt64(Console.ReadLine());
            client validate = s.WasUserPresent(phone);
            if (validate != null)
            {
                Console.WriteLine("Enter Your Password : ");
                string pwd = password();
                if (s.Check_Password(phone, pwd))
                {
                  s.Contact_Messages_Log(phone);
                }
                else
                {
                    Console.WriteLine("Wrong Password ");
                }
            }
            else
            {
                Console.WriteLine($"The Number : {phone} is in valid");
            }


        }
        public static int Menu()
        {
            Console.Clear();
            Console.WriteLine(@"
1)Create A New Account
2)Edit Your Details
3)Display Your Details
4)Add Contacts
5)Show My Contact List
6)Send Message
7)View Messages

Press 0 to Exit

Enter Any Option
               ");


            int nu = Convert.ToInt32(Console.ReadLine());
            return nu;

        }


    }


}


