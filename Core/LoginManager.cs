using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Core
{
    public class LoginManager
    {
        
        //FIELD
        public List<UserManager> UserList = new List<UserManager>();


        public bool ChangePasswordForUser(string userName, string oldPassword, string newPassword)
        {
            foreach (var userManager in UserList)
            {
                if (userManager.UserName == userName)
                {
                    return userManager.ChangePassword(newPassword, oldPassword);
                }
                
            }
            return false;
        }


        // METOD FÖR ATT SKAPA NY USER
        public bool AddNewUser(string givenUserName, string givenUserPassword)
        {


            if (!UserNameIsOk(givenUserName))
            {
                return false;
            }

            if (!UserPasswordIsOK(givenUserPassword))
            {
                return false;
            }

            UserList.Add(new UserManager(givenUserName, givenUserPassword));

            List<string> userStringList = new List<string>();

            foreach (var userManager in UserList)
            {
                userStringList.Add(userManager.ToString());

            }

            string filepath = @"C:\Users\johan\source\repos\ECU\Inlamningsuppgift-2\Core\UserData.txt";
            File.WriteAllLines(filepath, userStringList);

            return true;



        }


        // METOD FÖR ATT TESTA LOGIN
        public bool LogInUser(string givenUserName, string givenUserPassword)
        {
            foreach (var userManager in UserList)
            {
                if (givenUserName == userManager.UserName && givenUserPassword == userManager.Password)
                    return true;
            }
            return false;
        }



        // METOD FÖR ATT TESTA USER NAME 
        public bool UserNameIsOk(string givenUserName)
        {
            foreach (var userManager in UserList)
            {
                if (givenUserName == userManager.UserName)
                {
                    return false;
                }
            }


            if (givenUserName.Length > 16)
            {
                return false;
            }

            return Regex.IsMatch(givenUserName, "^[a-zA-Z0-9_-]*$");
        }

        //METOD FÖR ATT TESTA PASSWORD
        public bool UserPasswordIsOK(string givenUserPassword)
        {

            if (givenUserPassword.Length is < 8 or > 16)
            {
                return false;
            }

            if (!Regex.IsMatch(givenUserPassword, "^([a-zA-Z0-9!\"#¤%&/()=?*'_-])*$"))
            {
                return false;
            }

            return Regex.IsMatch(givenUserPassword, "^(?=.*[0-9])(?=.*[!\"#¤%&/()=?*'_-])");

        }
    }


    public class UserManager
    {
        public readonly string UserName;
        public string Password { get; private set; }
        public DateTime PasswordDateTime { get; set; }
        
        public UserManager(string username, string password)
        {
            UserName = username;
            Password = password;
            PasswordDateTime = DateTime.Today;

        }


        public override string ToString()
        {
            return UserName + "," + Password + ";" + PasswordDateTime;
        }

       
        public static string RandomPasswordGenerator(int lenght = 16)
        {
            string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            string specialChars = "0123456789!\"#¤%&/()=?*'_-";
            

            Random random = new Random();

            char[] chars = new char[lenght];
            for (int i = 0; i < lenght; i++)
            {
                chars[i] = validChars[random.Next(0, validChars.Length)];
                chars[i] = specialChars[random.Next(0, specialChars.Length)];
               
            }

            return new string(chars);

        }

        public bool ChangePassword(string newPassword, string oldPassword)
        {
            if (oldPassword != Password) return false;
            Password = newPassword;
            return true;

        }



    }


}
