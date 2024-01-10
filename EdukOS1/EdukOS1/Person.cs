using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdukOS1
{
    internal abstract class Person
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        private int ID { get; set; }


        public Person(string name, string surname, int ID)
        {
            this.Name = name;
            this.Surname = surname;
            this.ID = ID;
        }
    }
}