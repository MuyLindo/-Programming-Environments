using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondPart
{
    class User
    {
        public String Username;
        public String Password;
        public String FacultyNumber;
        public Int32 Role;

        public User()
        {
        }

        public User(String Username, String Password, String FacultyNumber, Int32 Role)
        {
            this.Username = Username;
            this.Password = Password;
            this.FacultyNumber = FacultyNumber;
            this.Role = Role;
        }
    }
}
