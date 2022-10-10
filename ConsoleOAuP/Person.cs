using System;
using System.Xml.Linq;

namespace Base
{
    class Person : IDateAndCopy
    {


        protected string Name;
        protected string Surname;
        protected System.DateTime DateOfBirth;


        public Person(string name, string surname, DateTime dateOfBirth)
        {
            this.Name = name;
            this.Surname = surname;
            this.DateOfBirth = dateOfBirth;
        }

        public Person()
        {
            this.Name = "Alex";
            this.Surname = "Avgust";
            this.DateOfBirth = new DateTime(2004, 04, 12);
        }


        public string Names
        {
            get { return Name; }
            set { Name = value; }
        }

        public string Surnames
        {
            get { return Surname; }
            set { Surname = value; }
        }

        public DateTime DateOfBirths
        {
            get { return DateOfBirth; }
            set { DateOfBirths = value; }
        }


        public int ChangingDateOfBirth
        {
            get { return DateOfBirth.Year; }
            set { DateOfBirth = new DateTime(value, DateOfBirth.Month, DateOfBirth.Day); }
        }

        public override string ToString()
        {
            return Name + " " + Surname + " " + DateOfBirths.Date.ToString();
        }

        public virtual string ToShortString()
        {
            return Name + " " + Surname;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            var p = obj as Person;
            if ((System.Object)p == null)
            {
                return false;
            }
            return (Name == p.Name) && (Surname == p.Surname) &&
             (DateOfBirth == p.DateOfBirth);

        }


        public override int GetHashCode()
        {
            return Name.GetHashCode() + Surname.GetHashCode() + DateOfBirth.GetHashCode();
        }


        public static bool operator ==(Person a, Person b)
        {
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator !=(Person a, Person b)
        {
            return !(a == b);
        }


        public virtual object DeepCopy()
        {
            return new Person(Name, Surname, DateOfBirth);
        }

        DateTime IDateAndCopy.Date { get; set; }

    }
}




