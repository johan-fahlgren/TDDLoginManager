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
        public string UserName { get; init; }
        public string Password { get; init; }

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
        


    }


}
