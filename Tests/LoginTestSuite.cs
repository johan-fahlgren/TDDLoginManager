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

            Assert.Equal("Default_User", _manager.UserName);

            Assert.Equal("Default_Password", _manager.UserPassword);


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

        [Fact]
        public void RegisterSameUserTwiceTest()
        {

            //Act
            bool registerSameUserAndPasswordTwice = _manager.AddNewUser("Default_User", "Default_Password");

            bool registerSameUserDifferentPassword = _manager.AddNewUser("Default_User", "Wrong_Password");

            bool registerSameDifferentUserSamePassword = _manager.AddNewUser("Wrong_User", "Default_Password");


            //Assert
            Assert.False(registerSameUserAndPasswordTwice);

            Assert.False(registerSameUserDifferentPassword);

            Assert.True(registerSameDifferentUserSamePassword);


        }

        [Fact]
        public void UserNameCharactersTest()
        {
            //Act
            bool newUserAcceptedCaracters = _manager.AddNewUser("Calle_Larsson1", "Default_Pwd_UT");

            bool newUserNotAcceptedCharacters = _manager.AddNewUser("Örjan?Åberg", "Default_Pwd_UT");

            bool newUserMax16Char = _manager.AddNewUser("12345678910111213", "Default_Pwd_UT");


            //Assert
            Assert.True(newUserAcceptedCaracters);

            Assert.False(newUserNotAcceptedCharacters);

            Assert.False(newUserMax16Char);
        }

        [Fact]
        public void UserPasswordCharactersTest()
        {
            //Act - Uppgift 5
            bool newUserPasswordAcceptedCharacters = _manager.AddNewUser("Default_User_PT", "D_3)lt-!(#*3s?");

            bool newUserPasswordNotAcceptedCharacters = _manager.AddNewUser("Default_User_PT", "Däfult_Pässwörd");

            bool newUserPasswordMax16Char = _manager.AddNewUser("Default_User_PT", "12345678910111213");
            
            // - Uppgift 6
            bool newUserPasswordMin8Char = _manager.AddNewUser("Default_User_PT", "1234567");

            bool newUserPasswordContainsNumber = _manager.AddNewUser("Default_User_PT", "D3fult_p4ssword");
            
            bool newUserPasswordContainsSpecialCharacter = _manager.AddNewUser("Default_User_PT", "Defau!t_Password");



            //Assert - Uppgift 5
            Assert.True(newUserPasswordAcceptedCharacters);

            Assert.False(newUserPasswordNotAcceptedCharacters);

            Assert.False(newUserPasswordMax16Char);

            // - Uppgift 6

            Assert.False(newUserPasswordMin8Char);

            Assert.False(newUserPasswordContainsNumber);

            Assert.False(newUserPasswordContainsSpecialCharacter);
        }
    }
}
