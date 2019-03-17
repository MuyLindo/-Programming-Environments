using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin;

namespace SecondPart
{
    class LoginValidation
    {
        private String Username;
        private String Password;
        private String ErrorMessage;
        private ActionOnError error;

        public delegate void ActionOnError(String ErrorMessage);

        public LoginValidation(String Username, String Password, ActionOnError error)
        {
            this.Username = Username;
            this.Password = Password;
            this.error = error;
        }

        public bool ValidateUserInput(User user)
        {
            UserRoles currentUserRole = (UserRoles)user.Role;

            bool emptyUsername = Username.Equals(String.Empty);

            if(emptyUsername == true)
            {
                ErrorMessage = "No username entered";
                error(ErrorMessage);
                currentUserRole = 0;
                return false;
            }

            if(Username.Length < 5)
            {
                ErrorMessage = "The username must be longer";
                error(ErrorMessage);
                currentUserRole = 0;
                return false;
            }

            bool emptyPassword = Password.Equals(String.Empty);
            if(emptyPassword == true)
            {
                ErrorMessage = "No password entered";
                error(ErrorMessage);
                currentUserRole = 0;
                return false;
            }

            if(Password.Length < 5)
            {
                ErrorMessage = "The password must be longer";
                error(ErrorMessage);
                currentUserRole = 0;
                return false;
            }

            User test = UserData.IsUserPassCorrect(Username, Password);

            if(test == null)
            {
                ErrorMessage = "There is no such User";
                error(ErrorMessage);
                currentUserRole = 0;
                return false;
            }
            else
            {
                currentUserRole = (UserRoles)test.Role;
                return true;
            }
           
        }
    }
}
