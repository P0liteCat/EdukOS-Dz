using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdukOS1
{
    internal class Teacher : Person
    {
        public List<string> Subjects;

        public Teacher(string name, string surname, int ID, List<string> subjects) : base(name, surname, ID)
        {
            this.Subjects = subjects;
        }

        public void AddMark(Student student, int mark)
        {
            student.AddMark(mark);
        }

        public void ShowMarks(Student student)
        {
            student.ShowMarks();
        }

        public void ShowGradeMarks(List<Student> grade)
        {
            foreach(var student in grade)
            {
                ShowMarks(student);
            }
        }
    }
}
