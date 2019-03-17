using System;
using System.Collections.Generic;
using System.IO;
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

            /*
            Console.WriteLine("Enter username: ");
            user.Username = Console.ReadLine();

            Console.WriteLine("Enter password: ");
            user.Password = Console.ReadLine();
            */

            LoginValidation login = new LoginValidation(user.Username, user.Password, Error);

            if (login.ValidateUserInput(user) == true)
            {
                Console.WriteLine("Username: " + user.Username);
                Console.WriteLine("Password: " + user.Password);
                Console.WriteLine("FacultyNumber: " + user.FacultyNumber);

                switch (currentUserRole)
                {
                    case UserRoles.ANONYNOUS:
                        Console.WriteLine("Welcome, Anonymous"); break;
                    case UserRoles.ADMIN:
                        Console.WriteLine("Welcome, Admin");

                        String AdminMode;

                        Console.WriteLine("Изберете опция: ");
                        Console.WriteLine("0: Изход");
                        Console.WriteLine("1: Промяна на роля на потребител");
                        Console.WriteLine("2: Промяна на активност на потребител");
                        Console.WriteLine("3: Списък на потребителите");
                        Console.WriteLine("4: Преглед на лог активност");
                        Console.WriteLine("5: Преглед на текуща активност");

                        AdminMode = Console.ReadLine();

                        switch (AdminMode)
                        {
                            case "1":
                                ChangeUserRole();
                                break;
                            case "2":
                                ChangeUserActivity();
                                break;
                            case "3":
                                Dictionary<string, int> allusers = UserData.AllUsersUsernames();
                                for(int i = 0; i < allusers.Count; i++)
                                {
                                    Console.WriteLine(allusers.ElementAt(i).Key);
                                    Console.WriteLine(allusers.ElementAt(i).Value);
                                }
                                break;
                            case "4":
                                loadActivityLogs();
                                break;
                            case "5":
                                Console.WriteLine("Enter filter for log");
                                String filter = Console.ReadLine();
                                String currentLogData = Logger.GetCurrentSessionActivities(filter);
                                Console.WriteLine(currentLogData);
                                break;
                        }

                        break;
                    case UserRoles.INSPECTOR:
                        Console.WriteLine("Welcome, Ispector"); break;
                    case UserRoles.PROFESSOR:
                        Console.WriteLine("Welcome, Professor"); break;
                    case UserRoles.STUDENT:
                        Console.WriteLine("Welcome, Student"); break;
                }
            }

            Console.ReadKey();
        }

        public static void ChangeUserActivity()
        {
            Console.WriteLine("Enter Username: ");
            String UName = Console.ReadLine();
            Console.WriteLine("Enter a Date: ");
            int Date = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter a Month: ");
            int Month = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter a Year: ");
            int Year = int.Parse(Console.ReadLine());
            DateTime InputDate = new DateTime(Year, Month, Date);
            Dictionary<string, int> allUsers = UserData.AllUsersUsernames();
            UserData.SetUserActiveTo(allUsers[UName], InputDate);
        }

        public static void ChangeUserRole()
        {
            Console.WriteLine("Enter Username: ");
            String UName = Console.ReadLine();
            Console.WriteLine("Enter new User Role: ");
            int URole = int.Parse(Console.ReadLine());
            //UserRoles currentRole = (UserRoles)URole;
            Dictionary<String, int> allUsers = UserData.AllUsersUsernames();
            UserData.AssignUserRole(allUsers[UName], URole);
        }

        public static void loadActivityLogs()
        {
            StreamReader reader = new StreamReader("test.txt");
            String currentLine = reader.ReadLine();
            StringBuilder logBuilder = new StringBuilder();
            while (currentLine != null)
            {
                logBuilder.Append(currentLine);
                logBuilder.Append(Environment.NewLine);
                currentLine = reader.ReadLine();
            }
            Console.WriteLine(logBuilder.ToString());
            reader.Close();
        }
    }

}
