using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdukOS1
{
    internal class Grade
    {
        public string Name { get; set; }
        public List<Student> Students;

        public Grade(string name)
        {
            Name = name;
            Students = new List<Student>();
        }

        public void AddStudent(Student student)
        {
            Students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            Students.Remove(student);
        }

        public void ShowMarks()
        {
            foreach(Student student in Students)
            {
                student.ShowMarks();
            }
        }
    }
}
