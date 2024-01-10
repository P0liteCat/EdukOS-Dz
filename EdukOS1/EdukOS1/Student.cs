using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdukOS1
{
    internal class Student : Person
    {
        public List<int> Marks { get; set; }
        private string Grade { get; set; }


        public Student(string name, string surname, int ID, string grade) : base(name, surname, ID)
        {
            Marks = new List<int>();
            this.Grade = grade;
        }

        public void AddMark(int mark)
        {
            Marks.Add(mark);
        }

        public void ShowMarks()
        {
            Console.WriteLine($"Student: {Name} {Surname}:");
            foreach (var mark in Marks)
            {
                Console.Write($"{mark} ");
            }
            Console.WriteLine();
        }
    }
}
