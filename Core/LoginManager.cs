using System;
using System.Collections.Generic;

namespace Core
{
    public class LoginManager
    {
        //FIELD
        public string userName;
        public string userPassword;

        public void AddNewUser(string givenUserName, string givenUserPassword)
        {
            userName = givenUserName;
            userPassword = givenUserPassword;


        }

        public bool LogInUser(string givenUserName, string givenUserPassword)
        {
            bool loginSuccess = givenUserName == userName && givenUserPassword == userPassword;
            return loginSuccess;
        }
    }
}
