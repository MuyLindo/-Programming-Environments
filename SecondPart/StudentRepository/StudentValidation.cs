using SecondPart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRepository
{
    class StudentValidation
    {
        Student GetStudentDataByUser(User user)
        {
            if(user.FacultyNumber == null || user == null)
            {
                Console.WriteLine("There is no such student!");
                return null;
            }

            Student student = StudentData.IsThereStudent(user.FacultyNumber);
            if(student == null)
            {
                Console.WriteLine("No such student!");
            }

            return student;
        }
    }
}
