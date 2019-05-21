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

            StudentData.Print(StudentData.IsThereStudent(fNum));

            Console.ReadKey();
        }
    }
}
