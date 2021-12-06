using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_console
{
    class BookBorrow
    {
        file f3 = new file();
        Student s2 = new Student();
        Book b2 = new Book();
        Use_DataBase f4 = new Use_DataBase();

        public int studentid;
        public string bookname;
        public DateTime dateborrow;
        public DateTime datereturn;
        public bool check;
        public bool check2;
        public string path = @"C:\Users\نادر محمد\Desktop\تطبيقات c#\Library_console\bookborrow.txt";
        public void addbookborrow()
        {

            Console.WriteLine("Enter Student ID : ");
            studentid = Convert.ToInt32(Console.ReadLine());

            //  شرط التحقق عن وجود رقم الطالب باستخدام القراءة من قاعدة البيانات
            check = f4.checkstudentidexist(studentid);
            //  شرط التحقق عن وجود رقم الطالب باستخدام القراءة من  الملفات
           // check = f3.checkstudentidexist(studentid, s2.path);

            if (check == true)
            {
                Console.WriteLine("Enter Book Name : ");
                bookname = Console.ReadLine();
                //  شرط التحقق عن وجود  اسم الكتاب باستخدام القراءة من  قاعدة البيانات
                check2 = f4.checkbooknameexist(bookname);
                //  شرط التحقق عن وجود  اسم الكتاب باستخدام القراءة من  الملفات
                //check2 = f3.checkbooknameexist(bookname, b2.path);
                f3.writebook(b2.path);
                if (check2 == true)
                {
                    dateborrow = DateTime.Now;
                    datereturn = dateborrow.AddDays(3);
                    Console.WriteLine("You Must Return The Book in {0}", datereturn);
                    f3.writebookborrow(studentid, bookname, dateborrow, datereturn, path);
                    f4.insertbookborrow(studentid, bookname, dateborrow, datereturn);
                }
                else
                {
                    Console.WriteLine("The Book Not Found !!");
                }
            }
            else
            {
                Console.WriteLine("The student is not found Register in our library !!");
            }
        }
    }
}
