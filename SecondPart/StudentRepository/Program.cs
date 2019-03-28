using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRepository
{
    class Program
    {
        static void Main(string[] args)
        {
            String fNum;
            Console.WriteLine("Enter faculty number: ");
            fNum = Console.ReadLine();
            Console.WriteLine();

           // List<Student> test = StudentData.testStudents;
           
                StudentData.print(StudentData.isThereStudent(fNum));

            Console.ReadKey();
        }
    }
}
