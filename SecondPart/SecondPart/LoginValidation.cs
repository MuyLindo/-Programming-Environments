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
        private String username;
        private String password;
        private String ErrorMessage;
        private ActionOnError error;

        public delegate void ActionOnError(String ErrorMessage);

        public LoginValidation(String username, String password, ActionOnError error)
        {
            this.username = username;
            this.password = password;
            this.error = error;
        }

        public bool ValidateUserInput(User user)
        {
            UserRoles currentUserRole = (UserRoles)user.Role;

            Logger.LogActivity("Успешен Login"); //във ValidateUserInput 

            bool emptyUsername = username.Equals(string.Empty);

            if(emptyUsername == true)
            {
                ErrorMessage = "No username entered";
                error(ErrorMessage);
                currentUserRole = 0;
                return false;
            }

            if(username.Length < 5)
            {
                ErrorMessage = "The username must be longer";
                error(ErrorMessage);
                currentUserRole = 0;
                return false;
            }

            bool emptyPassword = password.Equals(string.Empty);
            if(emptyPassword == true)
            {
                ErrorMessage = "No password entered";
                error(ErrorMessage);
                currentUserRole = 0;
                return false;
            }

            if(password.Length < 5)
            {
                ErrorMessage = "The password must be longer";
                error(ErrorMessage);
                currentUserRole = 0;
                return false;
            }

            User test = UserData.IsUserPassCorrect(username, password);

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
