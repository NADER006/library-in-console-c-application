using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_console
{
    class BookReturn
    {
        file f4 = new file();
        Use_DataBase f5 = new Use_DataBase();
        BookBorrow bb2 = new BookBorrow();
        Book bb = new Book();
        public int studentid;
        public DateTime datecurent;
        public string path = @"C:\Users\نادر محمد\Desktop\تطبيقات c#\Library_console\returnbook.txt";
        public bool check2;

        public void retrunbook()
        {
            bool check;
            Console.WriteLine("Enter Student ID :");
            studentid = Convert.ToInt32(Console.ReadLine());
            datecurent = DateTime.Now;
            //check=f5.checkstudentidexistborrowbook(studentid);
            check = f4.checkstudentidexistborrowbook(studentid, bb2.path);

            if (check == true)
            {

                //check2 = f5.checkdatereturn(studentid, datecurent);
                check2 = f4.checkdatereturn(studentid, datecurent, bb2.path);
                f4.writebook(bb.path);
                if (check2 == true)
                {
                    Console.WriteLine("Thanks For Return the book ");
                    f4.writebookreturn(studentid, datecurent, path);
                    f5.insertbookreturn(studentid, datecurent);

                }
                else
                {
                    Console.WriteLine("You are late ");
                }

            }
            else
                Console.WriteLine("The Student  did not Boroow Any Book ");
        }
    }
}
