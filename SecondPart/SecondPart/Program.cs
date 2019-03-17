﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin;

namespace SecondPart
{
    class Program
    {
       public static void Error(String ErrorMessage)
        {
            Console.WriteLine("!!!" + ErrorMessage + "!!!");
        }

        public static UserRoles currentUserRole { get; private set; }

        static void Main(string[] args)
        {
            User user = new User();

            Console.WriteLine("Enter username: ");
            user.Username = Console.ReadLine();

            Console.WriteLine("Enter password: ");
            user.Password = Console.ReadLine();

            LoginValidation login = new LoginValidation(user.Username, user.Password, Error);

            if (login.ValidateUserInput(user) == true)
            {
                Console.WriteLine("Username: " + user.Username);
                Console.WriteLine("Password: " + user.Password);
                Console.WriteLine("FacultyNumber: " + user.FacultyNumber);

                switch (currentUserRole)
                {
                    case UserRoles.ANONYNOUS:
                        Console.WriteLine("Role: Anonymous"); break;
                    case UserRoles.ADMIN:
                        Console.WriteLine("Role: Admin"); break;
                    case UserRoles.INSPECTOR:
                        Console.WriteLine("Role: Ispector"); break;
                    case UserRoles.PROFESSOR:
                        Console.WriteLine("Role: Professor"); break;
                    case UserRoles.STUDENT:
                        Console.WriteLine("Role: Student"); break;
                }
            }
            
            Console.ReadKey();
        }
    }
}
