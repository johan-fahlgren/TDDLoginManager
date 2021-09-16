using System;
using System.Collections.Generic;

namespace Core
{
    public class LoginManager
    {
        //FIELD
        public string userName;
        public string userPassword;

        public bool AddNewUser(string givenUserName, string givenUserPassword)
        {
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
