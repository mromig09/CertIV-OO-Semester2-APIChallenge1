using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_1.Models
{
    public class BookModels
    {
        public int isbn { get; set; }
        public string title { get; set; }
        public int borrower { get; set; }
        public int author { get; set; }

        public BookModels(int ISBN, string Title, int Borrower, int Author)
        {
            isbn = ISBN;
            title = Title;
            borrower = Borrower;
            author = Author;
        }
}
}