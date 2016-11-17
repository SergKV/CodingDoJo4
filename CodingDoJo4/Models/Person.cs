using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingDoJo4.Models
{
    public class Person
    {

        public string Firstname { set; get; }
        public string Lastname { set; get; }
        public int SocSecNo { set; get; }
        public DateTime BirthDate { set; get; }

        public Person(string firstname, string lastname, int socSecNo, DateTime birthDate)
        {
            Firstname = firstname;
            Lastname = lastname;
            SocSecNo = socSecNo;
            BirthDate = birthDate;
        }
  
    }
}
