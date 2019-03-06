using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondPart
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User();

            user.Username = "Gosho";
            user.Password = "123456";
            user.FacultyNumber = "121216001";
            user.Role = 1;

            Console.WriteLine("Username: " + UserData.TestUser.Username);
            Console.WriteLine("Password: " + UserData.TestUser.Password);
            Console.WriteLine("FacultyNumber: " + UserData.TestUser.FacultyNumber);

            switch (UserData.TestUser.Role)
            {
                case 1:
                    Console.WriteLine("Role: Administrator"); break;
                case 2:
                    Console.WriteLine("Role: Inspector"); break;
                case 3:
                    Console.WriteLine("Role: Teacher"); break;
                case 4:
                    Console.WriteLine("Role: Student"); break;
                default: Console.WriteLine("Incorrect number!"); break;
            }
            Console.ReadKey();
        }
    }
}
