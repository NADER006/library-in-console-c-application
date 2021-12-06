using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_console
{
    class Student
    {
        file f2 = new file();
        Use_DataBase ss1 = new Use_DataBase();
        public int studentid;
        public string fristname;
        public string lastname;
        public string address;
        public int phonenumber;

        public string path = @"C:\Users\نادر محمد\Desktop\تطبيقات c#\Library_console\student.txt";

        public void addstudent()
        {

            bool check;
        l: Console.WriteLine("Enter Student ID : ");
            studentid = Convert.ToInt32(Console.ReadLine());


            // شرط التحقق عن وجود رقم الطالب باستخدام القراءة من قاعدة البيانات
            //check = ss1.checkidstudent(studentid);

            //شرط التحقق عن وجود رقم الطالب باستخدام القراءة من الملفات   
            check = f2.checkidstudent(studentid, path);


            if (check == true)
            {
                Console.WriteLine("Enter First Name : ");
                fristname = Console.ReadLine();
                Console.WriteLine("Enter Last Name : ");
                lastname = Console.ReadLine();
                Console.WriteLine("Enter The Address : ");
                address = Console.ReadLine();
                Console.WriteLine("Enter Phone Number : ");
                phonenumber = Convert.ToInt32(Console.ReadLine());

                //إدخال البيانات الى الملفات 
                f2.writestudentfile(studentid, fristname, lastname, address, phonenumber, path);
                //إدخال البيانات الى قاعدة البيانات
                ss1.insertstudent(studentid, fristname, lastname, address, phonenumber);
                
            }
            else
            {
                Console.WriteLine("Sory Enter Another ID");
                goto l;
            }

        }
    }
}
