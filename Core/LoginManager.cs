using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Core
{
    public class LoginManager
    {
        // TODO Skapa List för user och password
        // TODO Lägga in i egen klass?

        //FIELD
        public string UserName;
        public string UserPassword;


        // METOD FÖR ATT SKAPA NY USER
        public bool AddNewUser(string givenUserName, string givenUserPassword)
        {
            
            if (!UserNameIsOk(givenUserName))
            {
                return false;
            }

            if (!UserPasswordIsOK(givenUserPassword))
            {
                return false;
            }

            
            UserName = givenUserName;
            UserPassword = givenUserPassword;
            return true;
           
        }


        // METOD FÖR ATT TESTA LOGIN
        public bool LogInUser(string givenUserName, string givenUserPassword)
        {
            bool loginSuccess = givenUserName == UserName && givenUserPassword == UserPassword;
            return loginSuccess;
        }



        // METOD FÖR ATT TESTA USER NAME 
        public bool UserNameIsOk(string givenUserName)
        {

            if (givenUserName == UserName)
            {
                return false;
            }
            
            if (givenUserName.Length > 16) 
            {
                return false;
            }

            return Regex.IsMatch(givenUserName, "^[a-zA-Z0-9_-]*$");
        }

        //METOD FÖR ATT TESTA PASSWORD
        public bool UserPasswordIsOK(string givenUserPassword)
        {

            if (givenUserPassword.Length is < 8 or > 16)
            {
                return false;
            }

            if (!Regex.IsMatch(givenUserPassword, "^([a-zA-Z0-9!\"#¤%&/()=?*'_-])*$"))
            {
                return false;
            }

            return Regex.IsMatch(givenUserPassword, "^(?=.*[0-9])(?=.*[!\"#¤%&/()=?*'_-])");

        }
    }
}
