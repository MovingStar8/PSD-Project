using KpopZtation.Handler;
using KpopZtation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace KpopZtation.Controller
{
    public class UserController
    {
        public static string InsertUser(string name, string email, string password, string gender, string address)
        {
            string validate = ValidateUserForInsert(name, email, password, gender, address);

            if (validate.Equals("success"))
            {
                return UserHandler.InsertUser(name, email, password, gender, address);
            }
            else
            {
                return validate;
            }
        }

        public static string UpdateUser(Customer c, string name, string email, string password, string gender, string address)
        {
            string validate = ValidateUserForInsert(name, email, password, gender, address);

            if (validate.Equals("success"))
            {
                return UserHandler.UpdateUser(c, name, email, password, gender, address);
            }
            else
            {
                return validate;
            }
        }

        public static string ValidateUserForInsert(string name, string email, string password, string gender, string address)
        {
            if (name.Equals("") || name.Length < 5 && name.Length > 50)
            {
                return "name must be filled and between 5 and 50 characters";
            }
            if (email.StartsWith("@") || !email.Contains("@") || !email.EndsWith(".com"))
            {
                return "email must contain @, doesn't start with @, and ends with \".com\"";
            }

            if (gender.Equals(""))
            {
                return "gender must be chosen";
            }

            if (address.Equals("") || !address.EndsWith("Street"))
            {
                return "address must ends with \"Street\"";
            }

            if (password.Equals(""))
            {
                return "password cannot be empty";
            }

            string pattern = "^[a-zA-Z0-9]+$";

            Regex regex = new Regex(pattern);

            Match match = regex.Match(password);

            if (!match.Success)
            {
                return "password must be alphanumeric";
            }

            return "success";
        }

        public static string GetUserForLogin(string email, string password)
        {
            if (email.Equals("") || password.Equals(""))
            {
                return "email and password must be filled";
            }

            return UserHandler.GetUserForLogin(email, password);
        }

        public static Customer GetUserById(int id)
        {
            return UserHandler.GetUserById(id);
        }
    }
}