using CodingDoJo4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingDoJo4.ViewModel
{
    public class PersonVM
    {
        private Person person;

        public string Firstname
        {
            set { person.Firstname = value; }
            get { return person.Firstname; }
        }

        public string Lastname
        {
            set { person.Lastname = value; }
            get { return person.Lastname; }
        }

        public int SocSecNo
        {
            set { person.SocSecNo = value; }
            get { return person.SocSecNo; }
        }

        public DateTime BirthDate
        {
            set { person.BirthDate = value; }
            get { return person.BirthDate; }
        }

        public PersonVM(string firstname, string lastname, int socSecNo, DateTime birthDate)
        {
            person = new Person(firstname, lastname, socSecNo, birthDate);
        }
    }
}
