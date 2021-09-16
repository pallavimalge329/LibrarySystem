﻿using System;
using System.Data.SqlClient;

namespace LibraryFunctions
{
    public class Connection
    {
        public string constr;
        static SqlConnection con;
        static SqlCommand cmd;
        static SqlDataReader dr;

        public static void CreateConnection()
        {
            string constr = "Data Source= DESKTOP-N5QBMVO\\SQLEXPRESS; Initial Catalog=SourceKode; User =sa; Password=Pass@123";

            con = new SqlConnection();
            con.ConnectionString = constr;
            Console.WriteLine("***Connection with the Database is Successfull***\n");

        }

        // Inserting Data into Member
        public static void InsertData(string MemberId, string MemberName, string MbContact)
        {
            con.Open();

            string query = "insert into Member values(@mi,@mn,@co)";

            cmd = new SqlCommand(query, con);

            cmd.Parameters.Add(new SqlParameter("mi", MemberId));
            cmd.Parameters.Add(new SqlParameter("mn", MemberName));
            cmd.Parameters.Add(new SqlParameter("co", MbContact));

            int r = cmd.ExecuteNonQuery();
            Console.WriteLine("{0} of rows affected", r);
            con.Close();

        }
        public static void DisplayMemberData()
        {
            con.Open();
            string query = "Select * from Member";
            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();
            Console.WriteLine("MemberId | MemberName | MbContact ");
            while (dr.Read())
            {
                Console.WriteLine("{0} | {1} | {2} ", dr["MemberId"], dr["MemberName"], dr["MbContact"]);

            }
            dr.Close();



            con.Close();
        }

        //Inserting Data Into Book

        public static void InsertData(string BookId, string BookTitle, int Price, string Author, string Catogory)
        {
            con.Open();

            string query = "insert into Book values(@bi,@bt,@pr,@ath,@ct)";

            cmd = new SqlCommand(query, con);

            cmd.Parameters.Add(new SqlParameter("bi", BookId));
            cmd.Parameters.Add(new SqlParameter("bt", BookTitle));
            cmd.Parameters.Add(new SqlParameter("pr", Price));
            cmd.Parameters.Add(new SqlParameter("ath", Author));
            cmd.Parameters.Add(new SqlParameter("ct", Catogory));

            int r = cmd.ExecuteNonQuery();
            Console.WriteLine("{0} of rows affected", r);
            con.Close();

        }




        //Displaying Data From Book
        public static void DisplayBookData()
        {
            con.Open();
            string query = "Select * from Book";
            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();
            Console.WriteLine("BookId | BookTitle | Price | Author | Catogory");
            while (dr.Read())
            {
                Console.WriteLine("{0} | {1} | {2} | {3} | {4} ", dr["BookId"], dr["BookTitle"], dr["Price"], dr["Author"], dr["Catogory"]);

            }
            dr.Close();




            con.Close();
        }


        //Inserting Data into Library Register

        public static void InsertData(string BookId, string MemberId, DateTime StartDate, DateTime ReturnedDate)
        {
            con.Open();

            string query = "insert into LibraryRegister values(@bi,@mi,@sd,@rd)";

            cmd = new SqlCommand(query, con);

            cmd.Parameters.Add(new SqlParameter("bi", BookId));
            cmd.Parameters.Add(new SqlParameter("mi", MemberId));
            cmd.Parameters.Add(new SqlParameter("sd", StartDate));
            cmd.Parameters.Add(new SqlParameter("rd", ReturnedDate));

            int r = cmd.ExecuteNonQuery();
            Console.WriteLine("{0} of rows affected", r);
            con.Close();

        }

        public static void DisplayData()
        {
            con.Open();

            string query = "Select * from LibraryRegister";
            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();
            Console.WriteLine("BookId | MemberId | StartDate | ReturnDate");
            while (dr.Read())
            {
                Console.WriteLine("{0} | {1} | {2} | {3} ", dr["BookId"], dr["MemberId"], dr["StartDate"], dr["ReturnedDate"]);

            }
            dr.Close();

            con.Close();
        }

        //Updating Data In BooK Table
        public static void UpdateBookData(string BookId, int Price, string Author, string Catogory)
        {
            con.Open();
            SqlCommand updateCommand = new SqlCommand("Update Book set Author=@ath,Price=@pr, Catogory=@ct where BookId=@bi", con);
            updateCommand.Parameters.Add(new SqlParameter("bi", BookId));
            updateCommand.Parameters.Add(new SqlParameter("ath", Author));
            updateCommand.Parameters.Add(new SqlParameter("pr", Price));
            updateCommand.Parameters.Add(new SqlParameter("ct", Catogory));
            Console.WriteLine("Commands executed! Total rows affected are " + updateCommand.ExecuteNonQuery());
            Console.WriteLine("Done! Press enter to move to the next step");
            Console.ReadLine();
            Console.Clear();
            con.Close();

        }

        public static void DisplayUpdatedData()
        {
            con.Open();
            string query = "Select * from Book";
            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();
            Console.WriteLine("BookId | Price | Author | Catogory");
            while (dr.Read())
            {
                Console.WriteLine("{0} | {1} | {2} | {3} ", dr["BookId"], dr["Price"], dr["Author"], dr["Catogory"]);

            }
            dr.Close();
            con.Close();
        }

        //Update Operation For Member Details
        public static void UpdateMemberData(string MemberId, string MemberName, string MbContact)
        {
            con.Open();
            SqlCommand updateCommand = new SqlCommand("Update Book set MemberName=@mn, MbContact=@c0 where MemberId=@mi", con);
            updateCommand.Parameters.Add(new SqlParameter("mi", MemberId));
            updateCommand.Parameters.Add(new SqlParameter("mn", MemberName));
            updateCommand.Parameters.Add(new SqlParameter("co", MbContact));
            Console.WriteLine("Commands executed! Total rows affected are " + updateCommand.ExecuteNonQuery());
            Console.WriteLine("***Done! Press enter to move to the next step***");
            Console.ReadLine();
            Console.Clear();
            con.Close();

        }

        public static void DisplayUpdatedMemberData()
        {
            con.Open();
            string query = "Select * from Member";
            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();
            Console.WriteLine("MemberId | MemberName | MbContact");
            while (dr.Read())
            {
                Console.WriteLine("{0} | {1} | {2}  ", dr["MemberId"], dr["MemberName"], dr["MbContact"]);

            }
            dr.Close();
            con.Close();
        }

        //Deleting Data From Member Table
        public static void DeleteMemberData(string MemberId, string MemberName, string MbContact)
        {
            con.Open();
            SqlCommand deleteCommand = new SqlCommand("Delete from Member where MemberId=@mi", con);
            deleteCommand.Parameters.Add(new SqlParameter("mi", MemberId));
            Console.WriteLine("Commands executed! Total rows affected are " + deleteCommand.ExecuteNonQuery());
            Console.WriteLine("***Done! Press enter to move to the next step***");
            Console.ReadLine();
            Console.Clear();
            con.Close();
        }

        public static void DisplayDeletedMemberData()
        {
            con.Open();
            string query = "Select * from Member";
            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();
            Console.WriteLine("MemberId | MemberName | MbContact");
            while (dr.Read())
            {
                Console.WriteLine("{0} | {1} | {2}  ", dr["MemberId"], dr["MemberName"], dr["MbContact"]);

            }
            dr.Close();
            con.Close();
        }

        //Deleting Data From BookTable

        public static void DeleteBookData(string BookId, string BookTitle, int Price, string Author, string Catogory)
        {
            con.Open();
            SqlCommand deleteCommand = new SqlCommand("Delete from Member where BookId=@bi", con);
            deleteCommand.Parameters.Add(new SqlParameter("bi", BookId));
            Console.WriteLine("Commands executed! Total rows affected are " + deleteCommand.ExecuteNonQuery());
            Console.WriteLine("***Done! Press enter to move to the next step***");
            Console.ReadLine();
            Console.Clear();
            con.Close();
        }

        public static void DisplayDeletdBookData()
        {
            con.Open();
            string query = "Select * from Book";
            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();
            Console.WriteLine("BookId | BookTitle | Price | Author | Catogory");
            while (dr.Read())
            {
                Console.WriteLine("{0} | {1} | {2} | {3} | {4} ", dr["BookId"], dr["BookTitle"], dr["Price"], dr["Author"], dr["Catogory"]);

            }
            dr.Close();


        }

    }
}