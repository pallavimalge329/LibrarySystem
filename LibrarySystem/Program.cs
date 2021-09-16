using System;
using LibraryModel;
using LibraryFunctions;

namespace LibrarySystem
{
    class Program
    {
        static void Main(string[] args)
        {

            Connection.CreateConnection();

            string MemberId;
            string MemberName;
            string MbContact;
            string BookId;
            string BookTitle;
            int Price;
            string Author;
            string Catogory;
            DateTime StartDate;
            DateTime ReturnedDate;

            //Displaying Member Details
            Console.WriteLine("Enter MemberId");
            MemberId = Console.ReadLine();
            Console.WriteLine("Enter MemberName");
            MemberName = Console.ReadLine();
            Console.WriteLine("Enter Member's Contact No");
            MbContact = Console.ReadLine();

            Connection.InsertData(MemberId, MemberName, MbContact);
            Connection.DisplayMemberData();

            //Displaing Book Details
            Console.WriteLine("Enter Your details");
            Console.WriteLine("Enter BookId");
            BookId = Console.ReadLine();
            Console.WriteLine("Enter BookName");
            BookTitle = Console.ReadLine();
            Console.WriteLine("Enter BookPrice");
            Price = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter BookAuthor");
            Author = Console.ReadLine();
            Console.WriteLine("Enter Category of Book");
            Catogory = Console.ReadLine();

            Connection.InsertData(BookId, BookTitle, Price, Author, Catogory);
            Connection.DisplayBookData();

            //Update Opration for Book Details
            Console.WriteLine("*** Enter Values For Update Book***");
            Console.WriteLine("Enter BookId for Refernece");
            BookId = Console.ReadLine();
            Console.WriteLine("Enter Auther Name to Upate");
            Author = Console.ReadLine();
            Console.WriteLine("Enter Book Price to Upate");
            Price = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Book Category to Upate");
            Catogory = Console.ReadLine();

            Connection.UpdateBookData(BookId, Price, Author, Catogory);
            Connection.DisplayUpdatedData();


            //Delete Opration for Book Details
            Console.WriteLine("*** Enter Values For Delete Data From Book***");
            Console.WriteLine("Enter BookId for Refernece");
            BookId = Console.ReadLine();
            

            Connection.DeleteBookData(BookId, BookTitle, Price, Author, Catogory);
            Connection.DisplayDeletdBookData();

            //Update Opration for Member Details
            Console.WriteLine("*** Enter Values For Update Member Details***");
            Console.WriteLine("Enter MemberId for Refernece");
            MemberId = Console.ReadLine();
            Console.WriteLine("Enter MemberName to Update");
            MemberName = Console.ReadLine();
            Console.WriteLine("Enter Member's Contact No to Update");
            MbContact = Console.ReadLine();

            Connection.UpdateMemberData( MemberId,MemberName,MbContact );
            Connection.DisplayUpdatedData();


            //Delete OPeration For Member Details

            Console.WriteLine("*** Enter Values For Delete Member Details***");
            Console.WriteLine("Enter MemberId for Refernece");
            MemberId = Console.ReadLine();
            
            Connection.DeleteMemberData(MemberId, MemberName, MbContact);
            Connection.DisplayDeletedMemberData();


            //Displying Details of Library Register
            Console.WriteLine("Enter Issue Date in yyyy/MM/dd");
            StartDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter Returned Date in yyyy/MM/dd");
            ReturnedDate = Convert.ToDateTime(Console.ReadLine());
            
            Connection.InsertData(BookId,  MemberId, StartDate, ReturnedDate);
            Connection.DisplayData();

            Console.ReadKey();

        }
    }
}
