using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondPart
{
    static class UserData
    {
       // public static User TestUser = new User();
        private static User[] _testUser = new User[5];

        public static User[] TestUser
        {
            get
            {
                ResetTestUserData();
                 return _testUser;               
            }
            set { }
        }

        private static void ResetTestUserData()
        {
             _testUser[0] = new User("Gosho", "passwd", "123", 1);
             _testUser[1] = new User("Pesho", "passwd", "123", 2);
             _testUser[2] = new User("Tosho", "passwd", "123", 3);
            
            /*
            _testUser.Username = "Gosho";
            _testUser.Password = "123456";
            _testUser.FacultyNumber = "121216001";
            _testUser.Role = 1;
            */
        }

        public static User IsUserPassCorrect(String User, String Pass)
        {
            for (int i = 0; i < _testUser.Length; i++)
            {
                if (_testUser[i].Username == User && _testUser[i].Password == Pass)
                {

                    return _testUser[i];
                }
                    
                
            }
            return null;
        }
    }
}
