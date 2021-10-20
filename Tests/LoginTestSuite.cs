using Core;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;
using System.Threading;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;
using Xunit;

namespace Tests
{
    public class LoginTestSuite
    {

        //FIELD
        private readonly LoginManager _manager;
        private string defaultUser = "Default_User";
        private string defaultPassword = "Def4ult_Passw¤rd";
        private string defaultEmail = "User_Email@emailprovider.com";


        //CONSTRUCTOR
        public LoginTestSuite()
        {
            Thread.Sleep(500);
           _manager = new LoginManager();
        }

        [Fact]
        public void AddUserNameAndPasswordRegistrationTest() //UPPGIFT 1
        {
            _manager.AddNewUser
                (defaultEmail, defaultUser, defaultPassword);
            //ASSERT

            Assert.Equal(defaultUser, _manager.UserList[0].UserName);

            Assert.Equal(defaultPassword, _manager.UserList[0].Password);

        }


        [Fact]
        public void CanUserLoginTest() //UPPGIFT 2
        {
            _manager.AddNewUser
                (defaultEmail, defaultUser, defaultPassword);
            //ACT

            bool canUserLogin = _manager.LogInUser
                (defaultUser, defaultPassword);


            //ASSERT
            Assert.True(canUserLogin);
        }


        [Fact]
        public void WrongUserCantLoginTest() //UPPGIFT 2
        {
            _manager.AddNewUser
                (defaultEmail, defaultUser, defaultPassword);
            //ACT

            bool wrongUserCantLogin = _manager.LogInUser
                ("Wrong_User", "Wr0ng_Passw¤rd");


            //ASSERT
            Assert.False(wrongUserCantLogin);
        }


        [Fact]
        public void RegisterSameUserTwiceTest() //UPPGIFT 3
        {

            _manager.AddNewUser
                (defaultEmail, defaultUser, defaultPassword);

            //ACT
            bool registerSameUserAndPasswordTwice = _manager.AddNewUser
                (defaultEmail, defaultUser, defaultPassword);

            bool registerSameUserDifferentPassword = _manager.AddNewUser
                (defaultEmail, defaultUser, "Wrong_P4ssword");

            bool registerDifferentUserSamePassword = _manager.AddNewUser
                ("wrong_email@mail.gov", "Wrong_User", defaultPassword);


            //ASSERT
            Assert.False(registerSameUserAndPasswordTwice);

            Assert.False(registerSameUserDifferentPassword);

            Assert.True(registerDifferentUserSamePassword);


        }


        [Fact]
        public void UserNameCharactersTest() //UPPGIFT 4
        {

            //ACT
            bool newUserAcceptedCharacters = _manager.AddNewUser
                (defaultEmail, "Calle_Larsson1", defaultPassword);

            bool newUserNotAcceptedCharacters = _manager.AddNewUser
                (defaultEmail, "Örjan?Åberg", defaultPassword);

            bool newUserMax16Char = _manager.AddNewUser
                (defaultEmail, "16+_stycken_chars", defaultPassword);


            //ASSERT
            Assert.True(newUserAcceptedCharacters);

            Assert.False(newUserNotAcceptedCharacters);

            Assert.False(newUserMax16Char);
        }


        [Fact]
        public void UserPasswordCharactersTest()
        {
            //ACT - UPPGIFT 5
            bool newUserPasswordAcceptedCharacters = _manager.AddNewUser
                ("wrong_email@mail.se", "Default_User_PT", "D_3)lt-!(#*3s?");

            bool newUserPasswordNotAcceptedCharacters = _manager.AddNewUser
                ("wrong_email@mail.com", "Default_User_PT2", "Defult_Password");

            bool newUserPasswordMax16Char = _manager.AddNewUser
                ("wrong_email@mail.net", "Default_User_PT3", "16Plus_Characters");

            //ACT - UPPGIFT 6
            bool newUserPasswordMin8Char = _manager.AddNewUser
                ("wrong_email@mail.org", "Default_User_PT4", "-8_Char");

            bool newUserPasswordContainsNumberAndSpecialChar = _manager.AddNewUser
                ("wrong_email@mail.gov", "Default_User_PT5", "Defult_p4ssword");



            //ASSERT - UPPGIFT 5
            Assert.True(newUserPasswordAcceptedCharacters);

            Assert.False(newUserPasswordNotAcceptedCharacters);

            Assert.False(newUserPasswordMax16Char);

            //ASSERT - UPPGIFT 6
            Assert.False(newUserPasswordMin8Char);

            Assert.True(newUserPasswordContainsNumberAndSpecialChar);


        }


        [Fact]
        public void SaveUserAndPasswordTest() //UPPGIFT 7 & 8
        {

            //ARRANGE
            LoginManager manager = new LoginManager();

            _manager.AddNewUser
                (defaultEmail, "Saved_User", "S4ved_Passw¤rd");

            manager.ReadUserData();

            //ASSERT

            Assert.Equal("Saved_User", manager.UserList[0].UserName);

            Assert.Equal("S4ved_Passw¤rd",
                manager.UserList[0].Password);

            Assert.True(manager.LogInUser
                ("Saved_User", "S4ved_Passw¤rd"));

        }

        [Fact]
        public void ExpiredPasswordTest() //UPPGIFT 9
        {
            var mockTime = new MockTime();

            _manager.AddNewUser
                (defaultEmail, "Saved_User", "S4ved_Passw¤rd");


            var passwordValidDate = _manager.UserList[0].PasswordDateTime == mockTime.TodayDate;
            Assert.True(passwordValidDate);


            mockTime.SetDateTo(DateTime.Today + TimeSpan.FromDays(365 * 1));
            passwordValidDate = _manager.UserList[0].PasswordDateTime == mockTime.TodayDate;
            Assert.False(passwordValidDate);

        }


        [Fact]
        public void GenerateRandomPasswordTest() //UPPGIFT h
        {
            var GeneratedPassword = UserManager.RandomPasswordGenerator();

            bool GeneratedPasswordIsValidAndMaxLenght = _manager.AddNewUser
                (defaultEmail, "Saved_User", GeneratedPassword);


            //ASSERT
            Assert.Equal(16, GeneratedPassword.Length);

            Assert.True(GeneratedPasswordIsValidAndMaxLenght);

        }


        [Fact]
        public void ChangePasswordTest() //UPPGIFT c

        {
            _manager.AddNewUser
                (defaultEmail, "Saved_User", "S4ved_Passw¤rd");

            Assert.True(_manager.LogInUser
                ("Saved_User", "S4ved_Passw¤rd"));


            var username = "Saved_User";
            var NewPassword = "N3w_PassWord";
            var OldPassword = _manager.UserList[0].Password;

            _manager.ChangePasswordForUser(username, OldPassword, NewPassword);


            //ASSERT
            Assert.Equal(_manager.UserList[0].Password, NewPassword);

            Assert.True(_manager.LogInUser
                ("Saved_User", "N3w_PassWord"));



        }

        [Fact]
        public void CanRegisterAndLoginWithEmailAddress() //UPPGIFT f
        {
            _manager.AddNewUser
                (defaultEmail, defaultUser, defaultPassword);

            bool canUserLogin = _manager.LogInUserByEmail
                (defaultEmail, defaultPassword);


            //ASSERT
            Assert.Equal(defaultEmail, _manager.UserList[0].UserEmail);

            Assert.True(canUserLogin);

        }



    }
}
