using System;
using LibraryFunctions;
using System.Text.RegularExpressions;

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
            Console.WriteLine("5.Display");
            Console.WriteLine("6.Exit");
            Console.Write("Enter Choice(1-6):");
            int ch = Int32.Parse(Console.ReadLine());

            string MemberId;
            string MemberName;
            string MbContact;
            string BookId;
            string BookTitle;
            int Price;
            string Author;
            string Catogory;
         // DateTime StartDate;
         //DateTime ReturnedDate;
        // DateTime DueDate;

            // Switch Case For CRUD Operations
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

                    //validation for Mob No.        
                            while (true)
                            {
                                Console.WriteLine("Enter Contact No");
                                MbContact = Console.ReadLine();
                                bool check = isValidMobileNumber(MbContact);


                                if (check == true)
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Length of Phone number must be 10!!!");
                                    continue;
                                }

                            }
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
                            while (string.IsNullOrEmpty(BookTitle))
                            {
                                Console.WriteLine("You Can Not enter blank Name");
                                Console.WriteLine("enter the name again");
                                BookTitle = Console.ReadLine();
                            }
                        Console.WriteLine("Enter BookPrice");
                        Price = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter BookAuthor");
                        Author = Console.ReadLine();
                            while (string.IsNullOrEmpty(Author))
                            {
                                Console.WriteLine("It Can Not enter blank ");
                                Console.WriteLine("enter the Author name again");
                                Author = Console.ReadLine();
                            }
                            Console.WriteLine("Enter Category of Book");
                        Catogory = Console.ReadLine();
                            while (string.IsNullOrEmpty(Catogory))
                            {
                                Console.WriteLine("It Can Not enter blank ");
                                Console.WriteLine("enter the Book name again");
                                Catogory = Console.ReadLine();
                            }

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

                    Console.WriteLine("1.update for Member");
                    Console.WriteLine("2.update for Book");
                    Console.Write("Enter Choice(1-2):");
                    int choice1 = Convert.ToInt32(Console.ReadLine());

                        if (choice1 == 1)
                        {
                            Console.WriteLine("*** Enter Values For Update Member Details***");
                            Console.WriteLine("Enter MemberId for Refernece");
                            MemberId = Console.ReadLine();
                            Console.WriteLine("Enter MemberName to Update");
                            MemberName = Console.ReadLine();
                            Console.WriteLine("Enter Member's Contact No to Update");
                            MbContact = Console.ReadLine();

                            Connection.UpdateMemberData(MemberId, MemberName, MbContact);
                            Connection.DisplayUpdatedMemberData();
                        }
                        else if (choice1 == 2)
                        {
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
                        }
                        else
                        {
                            Console.WriteLine("Invalid Choice");
                        }
                    break;
                case 3:

                    Console.WriteLine("1.Delete from Book");
                    Console.WriteLine("2.Delete From Member");
                    Console.Write("Enter Choice(1-2):");
                    int choice2 = Convert.ToInt32(Console.ReadLine());
                        if (choice2 == 1)
                        {
                            //Delete Opration for Book Details
                            Console.WriteLine("*** Enter Values For Delete Data From Book***");
                            Console.WriteLine("Enter BookId for Refernece");
                            BookId = Console.ReadLine();
                            Connection.DeleteBookData(BookId);
                            Connection.DisplayDeletdBookData();

                         }
                        else if(choice2==2)

                        //Delete OPeration For Member Details
                        { 
                            Console.WriteLine("*** Enter Values For Delete Member Details***");
                            Console.WriteLine("Enter MemberId for Refernece");
                            MemberId = Console.ReadLine();

                            Connection.DeleteMemberData(MemberId);
                            Connection.DisplayDeletedMemberData();
                        }
                        else
                        {
                            Console.WriteLine("Invalid Choice");
                        }
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
                            Console.WriteLine("Enter Book Title");
                            BookTitle = Console.ReadLine();
                            Connection.SelectAsTitleCatAuthor(BookTitle);
                           
                            break;

                        case 2:
                            Console.WriteLine("***Enter Author For Searching Data***");
                            Console.WriteLine("Enter AuthorName");
                            Author = Console.ReadLine();
                            Connection.SelectAsTitleCatAuthor(Author);
                          

                            break;

                        case 3:
                            Console.WriteLine("***Enter Category For Searching Data***");
                            Console.WriteLine("Enter Category Name");
                            Catogory = Console.ReadLine();
                            Connection.SelectAsTitleCatAuthor(Catogory);
                           
                            break;

                        }
                    break;

                    case 5:
                        Console.WriteLine("Displying Record");
                        Console.WriteLine("----------------------------");
                        Console.WriteLine("1.Display for Member");
                        Console.WriteLine("2.Display for Book");
                        Console.WriteLine("3.Display for Library Register");
                        Console.Write("Enter Choice(1-3):");
                        int choice3 = Convert.ToInt32(Console.ReadLine());

                        if (choice3 == 1)
                        {
                            Console.WriteLine("Record Of Members");
                            Connection.DisplayMember();
                        }
                        else if(choice3==2)
                        {
                            Console.WriteLine("Record Of Books");
                            Connection.DisplayBook();
                        }
                        else if(choice3==3)
                        {
                            Console.WriteLine("Record Of Library Register");
                            Connection.DisplayLibraryReg();
                        }
                        else
                        {
                            Console.WriteLine("Invalid Choice");
                        }
                        
                        break;


                    case 6:
                        Console.WriteLine("Exiting From The Application");
                        Console.ReadLine();
                        Environment.Exit(0);
                            break;

         }

            Console.WriteLine("Do You Wish to continue:");
            reply = Convert.ToChar(Console.ReadLine());

            } while (reply == 'Y');




            Console.ReadKey();

        }
        public static bool isValidMobileNumber(string inputMobileNumber)
        {
            string strRegex = @"(^[0-9]{10}$)|(^\+[0-9]{2}\s+[0-9] {2}[0-9]{8}$)|(^[0-9]{3}-[0-9]{4}-[0-9]{4}$)";


            Regex re = new Regex(strRegex);


            if (re.IsMatch(inputMobileNumber))
            {
                return (true);
            }

            else
            {
                return (false);
            }

        }
    }
}
