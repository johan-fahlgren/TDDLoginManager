using System;
using System.Collections.Generic;

namespace Core
{
    


    public class LoginManager
    {
        public string userName;
        public string userPassword;

        public void AddNewUser(string givenUserName, string givenUserPassword)
        {
            userName = givenUserName;
            userPassword = givenUserPassword;
           
            
        }

        public static bool LogInUser(string v1, string v2)
        {
            throw new NotImplementedException();
        }
    }
}
