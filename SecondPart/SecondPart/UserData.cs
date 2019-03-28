using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondPart
{
    static class UserData
    {
        // private static User[] _testUser = new User[5];

        private static List<User> testUsers;

        public static List<User> TestUser
        {
            get
            {
                ResetTestUserData();
                 return testUsers;               
            }
            private set { }
        }

        private static void ResetTestUserData()
        {
            /*
             _testUser[0] = new User("Gosho", "passwd", "123", 1);
             _testUser[1] = new User("Pesho", "passwd", "123", 2);
             _testUser[2] = new User("Tosho", "passwd", "123", 3);
             */

            testUsers = new List<User>();
            testUsers.Add(new User("Gosho", "passwd", "123456", 1));
            testUsers.Add(new User("Pesho", "passwd", "123459", 4));
            testUsers.Add(new User("Tosho", "passwd", "123461", 3));

            for (int i = 0; i < testUsers.Count; i++)
            {
                testUsers[i].Created = DateTime.Now;
                testUsers[i].ExpiryDate = DateTime.MaxValue;
            }
            
        }

        public static void SetUserActiveTo(int index, DateTime newDate)
        {
            testUsers[index].ExpiryDate = newDate;
            Logger.LogActivity("Промяна на активност на " + testUsers[index].Username); 

            /*
            foreach (User i in testUsers)
            {
                if (i.Username == Username)
                {
                    i.Created = date;
                }
            }
            */
        }

        public static void AssignUserRole(int index, int newRole)
        {
            testUsers[index].Role = (int)newRole;
            Logger.LogActivity("Промяна на роля на " + testUsers[index].Username); //в AssignUserRole 
           
            /*
            foreach (User i in testUsers)
            {
                if (i.Username == Username)
                {
                    i.Role = Role;
                }
            }
            */
        }

        public static User IsUserPassCorrect(String User, String Pass)
        {
            /* for (int i = 0; i < _testUser.Length; i++)
             {
                 if (_testUser[i].Username == User && _testUser[i].Password == Pass)
                 {
                     return _testUser[i];
                 }
             }*/

            /*
            foreach (User i in testUsers)
            {
                if(i.Username == User && i.Password == Pass)
                {
                    return i;
                }
            }
        
            return null;
            */

            User user = (from findUser in TestUser
                         where findUser.Username == User && findUser.Password == Pass
                         select findUser).First();
            return user;

        }

        static public Dictionary<string, int> AllUsersUsernames()
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            for (int i = 0; i < testUsers.Count; i++)
            {
                result.Add(testUsers[i].Username, i);
            }

            return result;
        }
    }
}
