using Core;
using System;
using Xunit;

namespace Tests
{
    public class LoginTestSuite
    {

        //FIELD
        private LoginManager _manager;

        //CONSTRUCTOR
        public LoginTestSuite()
        {
            _manager = new LoginManager();
            _manager.AddNewUser("Default_User", "Default_Password");
        }

        [Fact]
        public void AddUserNameAndPasswordRegistrationTest()
        {

            //ASSERT

            Assert.Equal("Default_User", _manager.userName);

            Assert.Equal("Default_Password", _manager.userPassword);


        }


        [Fact]
        public void CanUserLoginTest()
        {

            //ACT

            bool canUserLogin = _manager.LogInUser("Default_User", "Default_Password");


            //ASSERT
            Assert.True(canUserLogin);
        }


        [Fact]
        public void WrongUserCantLoginTest()
        {

            //ACT

            bool wrongUserCantLogin = _manager.LogInUser("Wrong_User", "Wrong_Password");


            //ASSERT
            Assert.False(wrongUserCantLogin);
        }
    }
}
