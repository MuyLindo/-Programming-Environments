using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRepository
{
    public class StudentData
    {
        public static List<Student> testStudents;

        public static List<Student> TestStudents
        {
            get
            {
                return testStudents;
            }
            private set
            {
                testStudents = value;
            }
        }

        static StudentData()
        {
            testStudents = new List<Student>();

            testStudents.Add(new Student("Ivan", "Ivanov","Petrov", "FKST", "KSI", "bachelor", Status.FINNISHED_SEMESTER,
                "98523", 4, 2, 44, DateTime.Now, DateTime.Now));

            testStudents.Add(new Student("Pesho", "Ivanov", "Dimitrov", "FTK", "TK", "bachelor", Status.FINNISHED_SEMESTER,
                "45263", 1, 10, 54, DateTime.Now, DateTime.Now));

            testStudents.Add(new Student("Petko", "Georgiev", "Draganov", "FA", "AIUT","bachelor", Status.FINNISHED_SEMESTER,
                "26594", 3, 2, 10, DateTime.Now, DateTime.Now));
        }

        public static Student IsThereStudent(String fNumber)
        {
            Student result = (from currentStudent in TestStudents
                              where currentStudent.FacultyNumber == fNumber
                              select currentStudent
                             ).First();
            return result;
        }

        public static void Print(Student student)
        {
            Console.WriteLine(student.Name);
            Console.WriteLine(student.SecondName);
            Console.WriteLine(student.ThirdName);
            Console.WriteLine(student.Faculty);
            Console.WriteLine(student.Specialty);
            Console.WriteLine(student.Degree);
            Console.WriteLine(student.Status);
            Console.WriteLine(student.FacultyNumber);
            Console.WriteLine(student.Course);
            Console.WriteLine(student.Stream);
            Console.WriteLine(student.Group);
        }
    }
}
