using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_1.Models
{
    public class AuthorModels
    {
        public int id { get; set; }
        public string surname { get; set; }
        public string firstname { get; set; }

        public AuthorModels(int aID, string aSurname, string aFirstname)
        {
            id = aID;
            surname = aSurname;
            firstname = aFirstname;
        }
    }
}