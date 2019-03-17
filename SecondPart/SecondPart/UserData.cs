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

        public static User TestUser
        {
            get
            {
                ResetTestUserData();
                for(int i = 0; i < _testUser.Length; i++)
                {
                    return _testUser[i];
                }
                
            }
            set { }
        }

        private static void ResetTestUserData()
        {
            User _testUser[0] = UserData("Name", "pass");
            
            /*
            _testUser.Username = "Gosho";
            _testUser.Password = "123456";
            _testUser.FacultyNumber = "121216001";
            _testUser.Role = 1;
            */
        }

        public static User IsUserPassCorrect(String Username, String Password)
        {

            return ;
        }
    }
}
