using System;
using LibraryModel;
using LibraryFunctions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem
{
    class Program
    {
        static void Main(string[] args)
        {

            Connection.CreateConnection();

            char reply = 'Y';
            do
            {

            
            Console.WriteLine("***Welcome To Library System Management***");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("1.Insert");
            Console.WriteLine("2.Update");
            Console.WriteLine("3.Remove");
            Console.WriteLine("4.Search");
            Console.WriteLine("5.Exit");
            Console.Write("Enter Choice(1-5):");
            int ch = Int32.Parse(Console.ReadLine());

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

            // Switch Case For CURD Operations
            switch (ch)
            {
                case 1:


                    Console.WriteLine("Displying Record");
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("1.Insert for Member");
                    Console.WriteLine("2.Insert for Book");
                    Console.WriteLine("3.Insert for Library Register");
                    Console.Write("Enter Choice(1-3):");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    if (choice == 1)
                    //Displaying Member Details
                    {
                        Console.WriteLine("Enter MemberId");
                        MemberId = Console.ReadLine();
                        Console.WriteLine("Enter MemberName");
                        MemberName = Console.ReadLine();
                            while (string.IsNullOrEmpty(MemberName)) 
                            {
                                Console.WriteLine("You Can Not enter blank Name");
                                Console.WriteLine("enter the name again");
                                MemberName = Console.ReadLine();
                            }
                        Console.WriteLine("Enter Member's Contact No");
                        MbContact = Console.ReadLine();

                        Connection.InsertData(MemberId, MemberName, MbContact);
                        Connection.DisplayMemberData();
                    }

                    else if (choice == 2)
                    //Displaing Book Details
                    {
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
                    }

                    else if (choice == 3)
                    //Displying Details of Library Register

                    {
                        Console.WriteLine("Enter Memberid an bookid");
                        BookId = Console.ReadLine();
                        MemberId = Console.ReadLine();

                        Connection.InsertData(BookId, MemberId);
                        Connection.DisplayData();
                    }
                    else
                    {
                        Console.WriteLine("Entered Choice Invalid Choice ");
                    }

                    break;
                case 2:

                    //Update Opration for Member Details
                    Console.WriteLine("*** Enter Values For Update Member Details***");
                    Console.WriteLine("Enter MemberId for Refernece");
                    MemberId = Console.ReadLine();
                    Console.WriteLine("Enter MemberName to Update");
                    MemberName = Console.ReadLine();
                    Console.WriteLine("Enter Member's Contact No to Update");
                    MbContact = Console.ReadLine();

                    Connection.UpdateMemberData(MemberId, MemberName, MbContact);
                    Connection.DisplayUpdatedMemberData();

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
                    Connection.DisplayBookUpdatedData();

                    break;
                case 3:
                    //Delete Opration for Book Details
                    Console.WriteLine("*** Enter Values For Delete Data From Book***");
                    Console.WriteLine("Enter BookId for Refernece");
                    BookId = Console.ReadLine();


                    Connection.DeleteBookData(BookId);
                    Connection.DisplayDeletdBookData();




                    //Delete OPeration For Member Details

                    Console.WriteLine("*** Enter Values For Delete Member Details***");
                    Console.WriteLine("Enter MemberId for Refernece");
                    MemberId = Console.ReadLine();

                    Connection.DeleteMemberData(MemberId);
                    Connection.DisplayDeletedMemberData();
                    break;

                //Searching Operation On Book Data 
                case 4:

                    Console.WriteLine("Searching Operation");
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("1.BookTitle");
                    Console.WriteLine("2.Author");
                    Console.WriteLine("3.Category");
                    Console.Write("Enter Choice(1-3):");
                    int ch1 = Int32.Parse(Console.ReadLine());

                    switch (ch1)
                    {
                        case 1:
                            Console.WriteLine("***Enter BookTitle For Searching Data***");
                            Console.WriteLine("Enter BookName");
                            BookTitle = Console.ReadLine();
                            Connection.SelectBookTitleData(BookTitle);
                            Connection.DisplayselectedBookTitleData();
                            break;

                        case 2:
                            Console.WriteLine("***Enter Author For Searching Data***");
                            Console.WriteLine("Enter AuthorName");
                            Author = Console.ReadLine();
                            Connection.SelectBookAuthorData(Author);
                           Connection.DisplayselectedBookAuthorData();

                            break;

                        case 3:
                            Console.WriteLine("***Enter Category For Searching Data***");
                            Console.WriteLine("Enter Category Name");
                            Catogory = Console.ReadLine();
                            Connection.SelectBookCategoryData(Catogory);
                            Connection.DisplayselectedBookCategoryData();
                            break;
                    }

                    break;

                    case 5:
                        Console.WriteLine("Exiting From The Application");
                        Console.ReadLine();
                        Environment.Exit(0);
                            break;
            }

            Console.WriteLine("Do You Wish to continue:");
            reply = Convert.ToChar(Console.ReadLine());
        } while(reply=='Y');

        

            Console.ReadKey();

        }
    }
}
