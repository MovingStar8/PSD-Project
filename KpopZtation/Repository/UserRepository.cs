using KpopZtation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtation.Repository
{
    public class UserRepository
    {
        private static DatabaseEntities db = ConnectDb.getDb();

        public static string InsertUser(Customer c)
        {
            try
            {
                var isEmailExist = (from cust in db.Customers where cust.CustomerEmail.Equals(c.CustomerEmail) select cust).FirstOrDefault();
                if (isEmailExist != null)
                {
                    return "Email already exists!";
                }

                db.Customers.Add(c);
                db.SaveChanges();

                return "Insert Success";
            }
            catch (Exception ex)
            {
                return "Something wrong with inserting process";
            }
        }

        public static string GetUserForLogin(string email, string password)
        {
            try
            {
                var isUserExist = (from cust in db.Customers where cust.CustomerEmail.Equals(email) && cust.CustomerPassword.Equals(password) select cust).FirstOrDefault();
                if (isUserExist == null)
                {
                    return "Wrong credential!";
                }

                return isUserExist.CustomerRole + "#" + isUserExist.CustomerID;
            }
            catch (Exception ex)
            {
                return "Something wrong with get process";
            }
        }

        public static Customer GetUserById(int id)
        {
            try
            {
                var isUserExist = (from cust in db.Customers where cust.CustomerID.Equals(id) select cust).FirstOrDefault();
                if (isUserExist == null)
                {
                    return null;
                }

                return isUserExist;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static string UpdateUser(Customer c, string name, string email, string password, string gender, string address)
        {
            try
            {
                var isEmailExist = (from cust in db.Customers where cust.CustomerEmail.Equals(email) && !cust.CustomerID.Equals(c.CustomerID) select cust).FirstOrDefault();
                if (isEmailExist != null)
                {
                    return "Email already exists!";
                }

                c.CustomerName = name;
                c.CustomerEmail = email;
                c.CustomerPassword = password;
                c.CustomerGender = gender;
                c.CustomerAddress = address;
                
                db.SaveChanges();

                return "Update Success";
            }
            catch (Exception ex)
            {
                return "Something wrong with updating process";
            }
        }
    }
}