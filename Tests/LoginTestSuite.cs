using Core;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;
using Xunit;

namespace Tests
{
    public class LoginTestSuite
    {

        //FIELD
        private readonly LoginManager _manager;

        //CONSTRUCTOR
        public LoginTestSuite()
        {
            _manager = new LoginManager();
            _manager.AddNewUser
                ("Default_User", "Def4ult_Passw¤rd");
        }

        [Fact]
        public void AddUserNameAndPasswordRegistrationTest() //UPPGIFT 1
        {
            //ASSERT

            Assert.Equal("Default_User", _manager.UserList[0].UserName);

            Assert.Equal("Def4ult_Passw¤rd", _manager.UserList[0].Password);


        }


        [Fact]
        public void CanUserLoginTest() //UPPGIFT 2
        {

            //ACT

            bool canUserLogin = _manager.LogInUser
                ("Default_User", "Def4ult_Passw¤rd");


            //ASSERT
            Assert.True(canUserLogin);
        }


        [Fact]
        public void WrongUserCantLoginTest() //UPPGIFT 2
        {

            //ACT

            bool wrongUserCantLogin = _manager.LogInUser
                ("Wrong_User", "Wr0ng_Passw¤rd");


            //ASSERT
            Assert.False(wrongUserCantLogin);
        }

        [Fact]
        public void RegisterSameUserTwiceTest() //UPPGIFT 3
        {

            //ACT
            bool registerSameUserAndPasswordTwice = _manager.AddNewUser
                ("Default_User", "Default_P4ssword");

            bool registerSameUserDifferentPassword = _manager.AddNewUser
                ("Default_User", "Wrong_P4ssword");

            bool registerSameDifferentUserSamePassword = _manager.AddNewUser
                ("Wrong_User", "Default_P4ssword");


            //ASSERT
            Assert.False(registerSameUserAndPasswordTwice);

            Assert.False(registerSameUserDifferentPassword);

            Assert.True(registerSameDifferentUserSamePassword);


        }

        [Fact]
        public void UserNameCharactersTest() //UPPGIFT 4
        {
            //ACT
            bool newUserAcceptedCharacters = _manager.AddNewUser
                ("Calle_Larsson1", "Default_P4ssword");

            bool newUserNotAcceptedCharacters = _manager.AddNewUser
                ("Örjan?Åberg", "Default_P4ssword");

            bool newUserMax16Char = _manager.AddNewUser
                ("16+_stycken_chars", "Default_P4ssword");


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
                ("Default_User_PT", "D_3)lt-!(#*3s?");

            bool newUserPasswordNotAcceptedCharacters = _manager.AddNewUser
                ("Default_User_PT2", "Defult_Password");

            bool newUserPasswordMax16Char = _manager.AddNewUser
                ("Default_User_PT3", "16Plus_Characters");

            //ACT - UPPGIFT 6
            bool newUserPasswordMin8Char = _manager.AddNewUser
                ("Default_User_PT4", "-8_Char");

            bool newUserPasswordContainsNumberAndSpecialChar = _manager.AddNewUser
                ("Default_User_PT5", "Defult_p4ssword");



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
            _manager.AddNewUser
                ("Saved_User", "S4ved_Passw¤rd");
            //ASSERT

            Assert.Equal("Saved_User", _manager.UserList[1].UserName);

            Assert.Equal("S4ved_Passw¤rd", _manager.UserList[1].Password);


        }


        [Fact]
        public void ExpiredPasswordTest() //UPPGIFT 9
        {
            var mockTime = new MockTime();

            _manager.AddNewUser
                ("Saved_User", "S4ved_Passw¤rd");


            var passwordValidDate = _manager.UserList[1].PasswordDateTime == mockTime.TodayDate;
            Assert.True(passwordValidDate);


            mockTime.SetDateTo(DateTime.Today + TimeSpan.FromDays(365 * 1));
            passwordValidDate = _manager.UserList[1].PasswordDateTime == mockTime.TodayDate;
            Assert.False(passwordValidDate);



        }

        [Fact]
        public void GenerateRandomPasswordTest() //UPPGIFT h
        {
            var GeneratedPassword = UserManager.RandomPasswordGenerator();

            bool GeneratedPasswordIsValidAndMaxLenght = _manager.AddNewUser
                ("Saved_User", GeneratedPassword);


            //ASSERT
            Assert.Equal(16, GeneratedPassword.Length);

            Assert.True(GeneratedPasswordIsValidAndMaxLenght);




        }


        [Fact]
        public void ChangePasswordTest() //UPPGIFT c
        {
            _manager.AddNewUser
                ("Saved_User", "S4ved_Passw¤rd");

            var username = "Saved_User";
            var NewPassword = "N3w_PassWord";
            var OldPassword = _manager.UserList[1].Password;
            
            _manager.ChangePasswordForUser(username,OldPassword,NewPassword);



            Assert.Equal(_manager.UserList[1].Password, NewPassword);



        }



    }
}
