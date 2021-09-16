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
        public string UserName;
        public string UserPassword;



        public bool AddNewUser(string givenUserName, string givenUserPassword)
        {
            if (!UserNameIsOk(givenUserName))
            {
                return false;
            }

            if (!UserPasswordIsOk(givenUserPassword))
            {
                return false;
            }


            UserName = givenUserName;
            UserPassword = givenUserPassword;
            return true;

        }



        public bool LogInUser(string givenUserName, string givenUserPassword)
        {
            bool loginSuccess = givenUserName == UserName && givenUserPassword == UserPassword;
            return loginSuccess;
        }




        public bool UserNameIsOk(string givenUserName)
        {

            if (givenUserName == UserName)
            {
                return false;
            }

            if (givenUserName.Length > 16) //Username max length
            {
                return false;
            }

            if (!Regex.IsMatch(givenUserName, "^[a-zA-Z0-9_-]*$")) //Kontrollerar a-z,A-Z,0-9 och "-_"
            {
                return false;
            }

            return true;


        }


        public bool UserPasswordIsOk(string givenUserPassword)
        {
            
            if (givenUserPassword.Length > 16)
            {
                return false;
            }

            if (!Regex.IsMatch(givenUserPassword, "^[a-zA-Z0-9_!'/&=#\\*¤\"%\\(?\\)-]*$"))
            {
                return false;
            }

            return true;

        }
    }
}
