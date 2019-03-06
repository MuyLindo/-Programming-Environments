using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            user.Username = "Somebody";
            user.Password = "12346";
            user.FacultyNumb = "121216306";
            user.Role = 1;

            LoginValidation login = new LoginValidation();
            if (login.ValidateUserInput() == true)
            {
                Console.WriteLine(UserData.TestUser.Username);
                Console.WriteLine(UserData.TestUser.Password);
                Console.WriteLine(UserData.TestUser.FacultyNumb);
                Console.WriteLine(LoginValidation.currentUserRole);

                /*
                switch (UserData.TestUser.Role)
                {

                    case 1:
                        Console.WriteLine("Administrator"); break;
                    case 2:
                        Console.WriteLine("Student"); break;

                    case 3:
                        Console.WriteLine("Student"); break;

                    case 4:
                        Console.WriteLine("Student"); break;

                    default: Console.WriteLine("Incorrect number!"); break;

                }
                */

            }


           

            Console.ReadKey();
        }
    }
    
}
