using System;

namespace LibraryModel
{
    public class BookLibrary
    {
        public string BookId
        {
            get;
            set;
        }
        public string BookTitle
        {
            get;
            set;
        }
        public int Price
        {
            get;
            set;
        }
        public string Auther
        {
            get;
            set;
        }
        public string MemberId
        {
            get;
            set;
        }
        public string MemberName
        {
            get;
            set;
        }
        public DateTime StartDate
        {
            get;
            set;
        }
        public DateTime ReturnedDate
        {
            get;
            set;
        }
    }
}
