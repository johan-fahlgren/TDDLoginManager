using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Core
{
    public class LoginManager
    {
        // TODO Skapa List för user och password
        // TODO Lägga in i egen klass?
        
        //FIELD
        public string userName;
        public string userPassword;

        public bool AddNewUser(string givenUserName, string givenUserPassword)
        {
            
            //givenUserName
            if (givenUserName == userName)
            {
                return false;
            }
            if (givenUserName.Length > 16) //Username max length
            {
                return false;
            }

            if (!(Regex.IsMatch(givenUserName, "^[a-zA-Z0-9_-]*$"))) //Kontrollerar a-z,A-Z,0-9 och "-_"
            {
                return false;
            }


            //givenUserPassword


            userName = givenUserName;
            userPassword = givenUserPassword;

            return true;
        }

        public bool LogInUser(string givenUserName, string givenUserPassword)
        {
            bool loginSuccess = givenUserName == userName && givenUserPassword == userPassword;
            return loginSuccess;
        }


    }
}
