using Core;
using System;
using Xunit;

namespace Tests
{
    public class LoginTestSuite
    {
        
        [Fact]
        public void AddUserNameAndPasswordRegistrationTest()
        {
            //ARRANGE
            LoginManager loginManager = new LoginManager();

            //ACT
            
            loginManager.AddNewUser("Default_User", "Default_Password");
            string user = loginManager.userName;
            string password = loginManager.userPassword;

            //ASSERT

            Assert.Equal("Default_User", user );

            Assert.Equal("Default_Password", password );


        }
    }
}
