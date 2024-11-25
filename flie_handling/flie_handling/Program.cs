using System.Security.Cryptography.X509Certificates;

class Program
{
    public static void Main(string[] args)
    {

        Console.Write("Enter your username : ");
        string name=Console.ReadLine();
        string uname, upass;
        int choice;
        string path = "C:\\Users\\admin\\Desktop\\login detail";
        string fullpath=path+"\\"+name+".txt";

        do
        {
            Console.WriteLine("\n1.registration \n2.login \n3.exit \n4.forgot password \n5.delete account");
            Console.Write("Enter your choice :");
            choice = int.Parse(Console.ReadLine());
            
       
            switch (choice)
            {
                case 1:
                    Console.WriteLine("\n********REGISTRATION FORM**********\n");
                    Console.Write("Enter username = "+name);
                    //uname = Console.ReadLine();
                    uname = name;
                    Console.Write("\nEnter Password = ");
                    upass = Console.ReadLine();
                    FileStream f1 = new FileStream(fullpath, FileMode.Create);

                    using (StreamWriter sw = new StreamWriter(f1))
                    {
                        sw.WriteLine(uname);
                        sw.WriteLine(upass);

                    }
                    Console.WriteLine("\n**********REGISTRATION SUCCESS************\n");
                    break;

                case 2:

                    Console.WriteLine("\n********LOGIN FORM************\n");
                    Console.Write("Enter username = ");
                    uname = Console.ReadLine();
                    Console.Write("Enter Password = ");
                    upass = Console.ReadLine();
                    try
                    {
                        FileStream f2 = new FileStream(fullpath, FileMode.Open);
                        using (StreamReader sr = new StreamReader(f2))
                        {
                            if (uname.Equals(sr.ReadLine()))
                            {
                                if (upass.Equals(sr.ReadLine()))
                                {
                                    Console.WriteLine("\n***********LOGIN SUCCESS************\n");
                                }
                                else
                                {
                                    Console.WriteLine("unmatch password");
                                }
                            }
                            else
                            {
                                Console.WriteLine("unmatch username");
                            }

                        }
                           


                    }
                    catch (FileNotFoundException e)
                    {
                        Console.WriteLine("file not found");
                    }
                   


                    break;

                case 3:

                    Console.WriteLine("thank you");
                    break;

                case 4:
                    Console.WriteLine("\n**********PASSWORD FORGOT************\n");
                    Console.Write("Enter your old password = ");
                    string oldpass = Console.ReadLine();
                    Console.Write("Enter your new password = ");
                    string newpass = Console.ReadLine();
                    string value1, value2;

                    FileStream f3 = new FileStream(fullpath, FileMode.Open);
                    using(StreamReader sr1 = new StreamReader(f3))
                    {
                        value1 = sr1.ReadLine();
                        value2 = sr1.ReadLine();

                    }

                    if (oldpass.Equals(value2))
                    {
                        FileStream f4=new FileStream(fullpath, FileMode.Create);
                        using(StreamWriter sr = new StreamWriter(f4))
                        {
                            sr.WriteLine(value1);
                            sr.WriteLine(newpass);
                        }
                        Console.WriteLine("Password forgot successfully");
                    }
                    else
                    {
                        Console.WriteLine("Old password wrong!!");
                        Console.WriteLine("Try again . . .");
                    }




                   

                    break;

                case 5:

                    Console.Write("are you sure for delete your account . if yes then enter yes = ");
                    string yes= Console.ReadLine();
                    Console.Write("Enter username = ");
                    string username= Console.ReadLine();

                    string deletepath = path + "\\" + username + ".txt";

                    if (yes.Equals("yes"))
                    {
                        File.Delete(deletepath);
                        Console.WriteLine("account delete successfully");
                        choice = 3;
                    }
                    else
                    {
                        Console.WriteLine("account not delete");
                    }

                    break;

                default:

                    Console.WriteLine("Invalid choice");

                    break;
            }



        } while (choice != 3);
    }
}