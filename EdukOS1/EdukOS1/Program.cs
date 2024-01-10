// See https://aka.ms/new-console-template for more information
using EdukOS1;

class Program
{
    static void Main()
    {
        Principal ravnatelj = new Principal("ImeRavnatelja", "PrezimeRavnatelja", 1);

        Teacher ucitelj = new Teacher("ImeUcitelja", "PrezimeUcitelja", 2, new List<string> { "Matematika", "Hrvatski" });
        ravnatelj.AddTeacher(ucitelj);

        Student student = new Student("ImeStudenta", "PrezimeStudenta", 3, "1A");
        ravnatelj.AddStudent(student);

        Grade razred1A = new Grade("1A");
        razred1A.AddStudent(student);

        ucitelj.AddMark(student, 5);

        ravnatelj.CheckSchoolMarks();
        ucitelj.ShowGradeMarks(razred1A.Students);
    }
}
