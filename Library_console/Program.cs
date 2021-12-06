using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data;
//using System.Data.SqlClient;

namespace Library_console
{
    class Program
    {
        static void Main(string[] args)
        {

            Student s1 = new Student();
            //Use_DataBase ss1 = new Use_DataBase();
            Book b1 = new Book();
            file f1 = new file();
            BookBorrow bb1 = new BookBorrow();
            BookReturn bb2 = new BookReturn();
           
            int choice;


            do
            {
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Clear();
                Console.WriteLine("\n\n\n\t\t\t\t\t\t ------------------------");
                Console.WriteLine("\n\t\t\t\t\t\t |  Welcome to Library  |");
                Console.WriteLine("\n\t\t\t\t\t\t ------------------------");
                Console.WriteLine("\n\n============================================================================================================================");
                Console.WriteLine("\n\n\n\t\t\t\t\t\t 1- For Regester Student :\n\t\t\t\t\t\t 2- For Issuing Book : \n\t\t\t\t\t\t 3- For Borrow Book : \n\t\t\t\t\t\t 4- Return Book : \n\t\t\t\t\t\t 5- Exit");

                Console.WriteLine("\n\n============================================================================================================================");
                choice = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        s1.addstudent();
                        //S1.insertstudent();
                        break;
                    case 2:
                        b1.addbook();
                        break;
                    case 3:
                        bb1.addbookborrow();
                        Console.ReadKey();
                        break;
                    case 4:
                        bb2.retrunbook();
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Wrong Choice");
                        break;
                }

            } while (choice != 5);


        }
    }
}
