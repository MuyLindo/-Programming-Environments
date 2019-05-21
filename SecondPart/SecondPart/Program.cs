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

        public static UserRoles CurrentUserRole { get; private set; }

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

                switch ((int)CurrentUserRole)
                {
                    case 0:
                        Console.WriteLine("Welcome, Anonymous"); break;
                    case 1:
                        Console.WriteLine("Welcome, Admin");
                        String adminOption = "-1";
                        while (adminOption != "0")
                        {
                            Console.WriteLine("Choose an option:");
                            Console.WriteLine("0: Exit");
                            Console.WriteLine("1: Change User Role");
                            Console.WriteLine("2: Change User Activity");
                            Console.WriteLine("3: User List");
                            Console.WriteLine("4: Display Activity Log");
                            Console.WriteLine("5: Display Current Activity Logs");
                            adminOption = Console.ReadLine();

                            switch (adminOption)
                            {
                                case "1": ChangeUserRole(); break;
                                case "2": ChangeUserActivity(); break;
                                case "3":
                                    Dictionary<String, int> allusers = UserData.AllUsersUsernames();
                                    foreach (var currentUser in allusers)
                                    {
                                        Console.WriteLine(currentUser.Key);
                                        Console.WriteLine(UserData.TestUser[currentUser.Value]);
                                    }
                                    break;
                                case "4":
                                    LoadActivityLogs(); break;

                                case "5":
                                    Console.WriteLine("Enter log filter:");
                                    String filter = Console.ReadLine();
                                    String currentLogData = Logger.GetCurrentSessionActivities(filter);
                                    Console.WriteLine(currentLogData); break;

                            }

                        }

                        break;
                    case 2: Console.WriteLine("Welcome, INSPECTOR!"); break;
                    case 3: Console.WriteLine("Welcome, PROFESSOR!"); break;
                    case 4: Console.WriteLine("Welcome, STUDENT!"); break;
                    
                }
            }

            else
            {
                Console.WriteLine("Validation Failed!");
                Console.WriteLine(LoginValidation.CurrentUserRole);
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

        public static void LoadActivityLogs()
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
