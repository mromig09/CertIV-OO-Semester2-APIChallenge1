using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_1.Models
{
    public class BorrowerModels
    {
        public int id { get; set; }
        public string surname { get; set; }
        public string firstname { get; set; }
        public string dob { get; set; }

        public BorrowerModels(int bID, string bSurname, string bFirstname, string DOB)
        {
            id = bID;
            surname = bSurname;
            firstname = bFirstname;
            dob = DOB;
        }
    }
}