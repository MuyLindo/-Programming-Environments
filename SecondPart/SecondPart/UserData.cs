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
        private static User _testUser = new User();

        public static User TestUser
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
            _testUser.Username = "Gosho";
            _testUser.Password = "123456";
            _testUser.FacultyNumber = "121216001";
            _testUser.Role = 1;
        }

        public static User IsUserPassCorrect(String Username, String Password)
        {

        }
    }
}
