using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    static class UserData
    {
        private static User _testUser;

        static private void ResetTestUserData()
        {
            _testUser.Username = "Somebody";
            _testUser.Password = "12346";
            _testUser.FacultyNumb = "121216306";
            _testUser.Role = 1;
        }

        public static User TestUser
        {
            get
            {
                ResetTestUserData();
                return _testUser;
            }

            set { }
        }

    }
}
