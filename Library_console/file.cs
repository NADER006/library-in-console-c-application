using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Library_console
{
    class file
    {
        public int c;

        public string[,] students = new string[100, 5];
        public string[,] books = new string[100, 5];
        public string[,] bookborrow = new string[100, 4];
//==================================================================================================================================


        public bool checkidstudent(int id, string path)
        {
            c = 0;

            readstudentfile(students, path);
            string studentid = Convert.ToString(id);
            if (id > 0)
            {
                for (int i = 0; i < 100; i++)
                {
                    if (studentid == students[i, 0])
                    {
                        Console.WriteLine("Sorry This ID is  Reserved !!");
                        c++;
                    }
                }
            }
            else
            {
                Console.WriteLine("The ID must be > 0");
                c++;
            }


            if (c == 0)
                return true;

            else
                return false;
        }
        //========================================================================================================================================


        public void writestudentfile(int id, string fn, string ln, string add, int phn, string path)
        {

            StreamWriter write = new StreamWriter(path, true);

            write.WriteLine(id + "," + fn + "," + ln + "," + add + "," + phn);

            write.Close();
        }
        //======================================================================================================================================

        public void readstudentfile(string[,] lines, string path)
        {
            StreamReader read = new StreamReader(path);
            string data;
            int counter = 0;
            int line = 0;

            data = read.ReadToEnd();
            read.Close();

            for (int a = 0; a < 5; a++)//clear
                lines[line, a] = "";
            for (int i = 0; i < data.Length; i++)
            {


                if (data[i] == ',')
                    counter++;
                else if (counter == 0)//id
                    lines[line, 0] += data[i];
                else if (counter == 1)//fn
                    lines[line, 1] += data[i];
                else if (counter == 2)//ln
                    lines[line, 2] += data[i];
                else if (counter == 3)//add
                    lines[line, 3] += data[i];
                else if (counter == 4)//phn
                    lines[line, 4] += data[i];
                if (data[i] == '\n')
                {
                    line++;
                    counter = 0;
                }
                read.Close();
            }

        }

    //===================================================================================================================================

        public void writebook(string path)
        {


            string[] g = File.ReadAllLines(path);
            int length = g.Length;
            File.Delete(path);
            StreamWriter write = new StreamWriter(path);
            for (int i = 0; i <= length - 1; i++)
            {
                write.Write(books[i, 0] + "," + books[i, 1] + "," + books[i, 2] + "," + books[i, 3] + "," + books[i, 4]);
            }


            write.Close();
        }

        public void writebooksimple(int id, string name, string author, int qu, decimal pri, string path)
        {

            StreamWriter write = new StreamWriter(path, true);

            write.WriteLine(id + "," + name + "," + author + "," + qu + "," + pri);

            write.Close();
        }

        //=============================================================================================================================================

        public bool checkidbook(int id, string path)
        {
            c = 0;

            readstudentfile(books, path);
            string bookid = Convert.ToString(id);
            if (id > 0)
            {
                for (int i = 0; i < 100; i++)
                {
                    if (bookid == books[i, 0])
                    {
                        Console.WriteLine("Sorry This ID is  Reserved !!");
                        c++;
                    }
                }
            }
            else
            {
                Console.WriteLine("The ID must be > 0");
                c++;
            }


            if (c == 0)
                return true;

            else
                return false;
        }
        
        //================================================================================================================================================

        public bool checkstudentidexist(int id, string path)
        {
            c = 0;

            readstudentfile(students, path);
            string studentid = Convert.ToString(id);
            if (id > 0)
            {
                for (int i = 0; i < 100; i++)
                {
                    if (studentid == students[i, 0])
                    {
                        c++;
                    }
                }
            }
            else
            {
                Console.WriteLine("The ID must be > 0");
                c++;
            }


            if (c == 0)
                return false;

            else
                return true;
        }

    //==========================================================================================================================================================

        public bool checkbooknameexist(string name, string path)
        {
            c = 0;

            readstudentfile(books, path);

            for (int i = 0; i < 100; i++)
            {
                if (name == books[i, 1])
                {
                    int Quntety = Convert.ToInt32(books[i, 3]);
                    Quntety = Quntety - 1;
                    string newQuntety = Convert.ToString(Quntety);
                    books[i, 3] = newQuntety;
                    c++;
                }
            }
            if (c == 0)
                return false;

            else
                return true;
        }
        //==================================================================================================================================

        public void writebookborrow(int id, string bn, DateTime db, DateTime dr, string path)
        {
            StreamWriter write = new StreamWriter(path, true);

            write.WriteLine(id + "," + bn + "," + db + "," + dr);

            write.Close();
        }
        
        //================================================================================================================================


        public bool checkstudentidexistborrowbook(int id, string path)
        {
            c = 0;

            readbookborrowfile(bookborrow, path);
            string studentid = Convert.ToString(id);
            if (id > 0)
            {
                for (int i = 0; i < 100; i++)
                {
                    if (studentid == bookborrow[i, 0])
                    {
                        c++;
                    }
                }
            }
            else
            {
                Console.WriteLine("The ID must be > 0");
                c++;
            }
            if (c == 0)
                return false;

            else
                return true;
        }

        public bool checkdatereturn(int id, DateTime cr, string path)
        {
            Book b3 = new Book();
            c = 0;
            readstudentfile(books, b3.path);
            string studentid = Convert.ToString(id);
            if (id > 0)
            {
                for (int i = 0; i < 100; i++)
                {
                    if (studentid == bookborrow[i, 0])
                    {
                        int Quntety = Convert.ToInt32(books[i, 3]);
                        Quntety = Quntety + 1;
                        string newQuntety = Convert.ToString(Quntety);
                        books[i, 3] = newQuntety;

                        DateTime datereturn = Convert.ToDateTime(bookborrow[i, 3]);
                        if (cr <= datereturn)
                        {

                            c++;
                        }
                    }

                }
            }
            if (c == 0)
                return false;

            else
                return true;
        }

        public void writebookreturn(int id, DateTime dc, string path)
        {
            StreamWriter write = new StreamWriter(path, true);

            write.WriteLine(id + "," + dc);

            write.Close();
        }

        public void readbookborrowfile(string[,] lines, string path)
        {
            StreamReader read = new StreamReader(path);
            string data;
            int counter = 0;
            int line = 0;

            data = read.ReadToEnd();
            read.Close();

            for (int a = 0; a < 4; a++)//clear
                lines[line, a] = "";
            for (int i = 0; i < data.Length; i++)
            {


                if (data[i] == ',')
                    counter++;
                else if (counter == 0)//id
                    lines[line, 0] += data[i];
                else if (counter == 1)//fn
                    lines[line, 1] += data[i];
                else if (counter == 2)//ln
                    lines[line, 2] += data[i];
                else if (counter == 3)//add
                    lines[line, 3] += data[i];

                if (data[i] == '\n')
                {
                    line++;
                    counter = 0;
                }
                read.Close();
            }


        }
    }
}
