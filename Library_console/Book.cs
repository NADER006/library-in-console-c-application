using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_console
{
    class Book
    {
        file f2 = new file();
        Use_DataBase f3 = new Use_DataBase();
        public int bookid;
        public string bookname;
        public string author;
        public decimal sellingprice;
        public int quintity;
        public string path = @"C:\Users\نادر محمد\Desktop\تطبيقات c#\Library_console\book.txt";

        public void addbook()
        {

            bool check;
        l: Console.WriteLine("Enter Book ID : ");
            bookid = Convert.ToInt32(Console.ReadLine());
            // شرط التحقق عن وجود رقم الكتاب باستخدام القراءة من قاعدة البيانات
            //check = f3.checkidbook(bookid);

            //شرط التحقق عن وجود رقم الكتاب  باستخدام القراءة من الملفات 
            check = f2.checkidbook(bookid, path);
            if (check == true)
            {
                Console.WriteLine("Enter Book Name : ");
                bookname = Console.ReadLine();
                Console.WriteLine("Enter Author Name : ");
                author = Console.ReadLine();
                Console.WriteLine("Enter Quintity Number : ");
                quintity = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Selling Price : ");
                sellingprice = Convert.ToDecimal(Console.ReadLine());

                //إدخال البيانات الى الملفات
                f2.writebooksimple(bookid, bookname, author, quintity, sellingprice, path);
                //إدخال البيانات الى قاعدة البيانات 
                f3.insertbook(bookid, bookname, author, quintity, sellingprice);
            }
            else
            {
                Console.WriteLine("Sory Enter Another ID");
                goto l;
            }

        }
    }
}
