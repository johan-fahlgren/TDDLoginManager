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
           

            //ASSERT
            Assert.Equal("Default_User", loginManager.userName );

            Assert.Equal("Default_Password", loginManager.userPassword );


        }
    }
}
