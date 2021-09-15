using System;
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
            Console.WriteLine("Connection with the Database is Successfull");

        }
    }
}
