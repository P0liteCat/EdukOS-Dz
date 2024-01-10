using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdukOS1
{
    internal class Principal : Person
    {
        public List<Teacher> Teachers { get; set; }
        public List<Student> Students { get; set; }


        public Principal(string name, string surname, int ID) : base(name, surname, ID)
        {
            Teachers=new List<Teacher>();
            Students = new List<Student>();
        }

        public void AddTeacher(Teacher teacher)
        {
            Teachers.Add(teacher);
        }

        public void AddStudent(Student student)
        {
            Students.Add(student);
        }

        public void RemoveTeacher(Teacher teacher)
        {
            Teachers.Remove(teacher);
        }

        public void RemoveStudent(Student student)
        {
            Students.Remove(student);
        }

        public void CheckSchoolMarks()
        {
            foreach(var student in Students)
            {
                student.ShowMarks();
            }
        }
    }
}
