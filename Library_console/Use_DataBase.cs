using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Library_console
{
   public class Use_DataBase
    {


       public int c;
       int studentidisexist;
       int bookidisexist;
       string bookidisexistname;
       int studentidisexistborrow;

        //the conncted string with database ====================================================================================================================================================================

       SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\نادر محمد\Desktop\تطبيقات c#\Library_console\Library_console\LibraryData.mdf;Integrated Security=True");
       
       // function to chicked student===========================================================================================================================================================================

       public bool checkidstudent( int id)
        {
            c = 0;

            readstudentfile(id);
            int studentid =id;
            if (id > 0)
            {
                
                    if (studentid == studentidisexist)
                    {
                        Console.WriteLine("Sorry This ID is  Reserved !!");
                        c++;
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

       //function to raed the student from the table student=======================================================================================================

       public void readstudentfile(int id)
       {
           
           con.Open();
           SqlCommand cmd = new SqlCommand("select * from Student where Id =" + id + " ", con);
           SqlDataReader re = cmd.ExecuteReader();
           if (re.Read())
           {
               studentidisexist=id;

              
           }
           con.Close();

       }
       //function to insert data into student table================================================================================================================
       public void insertstudent(int id , string fn, string ln, string add, int phn)
        {
            con.Open();
            string query = "INSERT INTO Student (Id,firstname,lastname,address,phonenumber)VALUES(" + id + ",'" + fn + "','" + ln + "','" + add + "'," + phn + ")";
            //string query = "INSERT INTO Student (Id,firstname,lastname,address,phonenumber)VALUES( ids , 'fn' ,'ln' , 'add' ,phn )";

            SqlCommand cammand = new SqlCommand(query, con);
           cammand.ExecuteNonQuery();
           con.Close();
            
        }

       // function to chicked  book ===============================================================================================================================================================================

       public bool checkidbook(int id)
       {
           c = 0;

           readbooktfile(id);
           int bookid = id;
           if (id > 0)
           {

               if (bookid == bookidisexist)
               {
                   Console.WriteLine("Sorry This ID is  Reserved !!");
                   c++;
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

       //function to raed the book from the table book=======================================================================================================

       public void readbooktfile(int id)
       {

           con.Open();
           SqlCommand cmd = new SqlCommand("select * from Book where Id =" + id + " ", con);
           SqlDataReader re = cmd.ExecuteReader();
           if (re.Read())
           {
               bookidisexist = id;


           }
           con.Close();

       }

       //function to insert data into book table================================================================================================================
       public void insertbook(int id, string name, string author, int qu, decimal pri)
       {
           con.Open();
           string query = "INSERT INTO Book (Id,bookname,author,quintity,sellingprice)VALUES(" + id + ",'" + name + "','" + author + "'," + qu + "," + pri + ")";
           
           SqlCommand cammand = new SqlCommand(query, con);
           cammand.ExecuteNonQuery();
           con.Close();

       }

       // function to to checked student to existed==================================================================================================================

       public bool checkstudentidexist(int id)
       {

         
            c = 0;

            readstudentfile(id);
            int studentid =id;
            if (id > 0)
            {
                
                    if (studentid == studentidisexist)
                    {
                        c++;
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
                return true ;
 
       }

       //function to raed the book from the table book=======================================================================================================

       public void readbookname(string name)
       {

           con.Open();
           SqlCommand cmd = new SqlCommand("select * from Book where bookname ='"+ name+ "' ", con);
           SqlDataReader re = cmd.ExecuteReader();
           if (re.Read())
           {
         
               bookidisexistname = name;


           }
           con.Close();

       }

       //function to update the book  quintity from the table book a=======================================================================================================

       public void readbooknameandipdatequintity (string name)
       {
           
               con.Open();
               SqlCommand cmd = new SqlCommand("update Book set quintity=quintity-1  where bookname ='" + name + "' ", con);
               //SqlDataReader re = cmd.ExecuteReader();
               //if (re.Read())
               //{

               //    bookidisexistname = name;

               //}
               con.Close();
           

       }
       // function to to checked book name to existed==================================================================================================================

       public bool checkbooknameexist(string name)
       {

           c = 0;
           readbookname(name);
           if (name == bookidisexistname)
           {
               readbooknameandipdatequintity(name);
               c++;
           }
          
           
           if (c == 0)
               return false;

           else
               return true;
       }

       //function to insert data into bookborrow table================================================================================================================
       public void insertbookborrow(int id, string bn, DateTime db, DateTime dr)
       {
           con.Open();
           string query = "INSERT INTO BookBorrow (Id,bookname,dateborrow,datereturn)VALUES(" + id + ",'" + bn + "','" + db + "','" + dr + "')";

           SqlCommand cammand = new SqlCommand(query, con);
           cammand.ExecuteNonQuery();
           con.Close();

       }











       //functio to checks for student id exist in the table bookborrow============================================================================================

       public bool checkstudentidexistborrowbook(int id)
       {
           c = 0;

           readbookborrowfile(id);
           int studentid = id ;
           if (id > 0)
           {

               if (studentid == studentidisexistborrow)
                   {
                       c++;
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



       //function to update the book  quintity from the table book by id the book  =======================================================================================================

       public void readbookidupdatequintity(int id)
       {

           con.Open();
           SqlCommand cmd = new SqlCommand("update Book set quintity=quintity+1  where Id =" + 1d + " ", con);
           SqlDataReader re = cmd.ExecuteReader();
           //if (re.Read())
           //{

           //    bookidisexistname = name;

           //}
           con.Close();


       }



       //==================================================================================================================================================================================
       public bool checkdatereturn(int id, DateTime cr)
       {
           
           c = 0;
           readbooktfile(id);
           int studentid = id;
           if (id > 0)
           {

               if (studentid == bookidisexist)
                   {
                       readbookidupdatequintity(id);

                       DateTime datereturn = Convert.ToDateTime(studentidisexist); 

                       if (cr <= datereturn)
                       {

                           c++;
                       }
                   }

               
           }
           if (c == 0)
               return false;

           else
               return true;
       }







       //finction to read data from the table bookborrow==========================================================================================================

       public void readbookborrowfile(int id)
       {
           con.Open();
           SqlCommand cmd = new SqlCommand("select * from BookBorrow where Id =" + id + " ", con);
           SqlDataReader re = cmd.ExecuteReader();
           if (re.Read())
           {
               studentidisexistborrow = id;


           }
           con.Close();
           
       }

       //function to insert data into bookreturn table================================================================================================================
       public void insertbookreturn(int id, DateTime dc)
       {
           con.Open();
           string query = "INSERT INTO BookReturn (Id,datecurent)VALUES(" + id + ",'" + dc + "')";

           SqlCommand cammand = new SqlCommand(query, con);
           cammand.ExecuteNonQuery();
           con.Close();

       }

       
    
    }
}
