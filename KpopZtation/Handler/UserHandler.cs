using KpopZtation.Factory;
using KpopZtation.Model;
using KpopZtation.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtation.Handler
{
    public class UserHandler
    {
        public static string InsertUser(string name, string email, string password, string gender, string address)
        {
            try
            {
                return UserRepository.InsertUser(UserFactory.createCustomer(name, email, password, gender, address));
            }
            catch (Exception ex)
            {
                return "Something wrong with handling process";
            }
        }

        public static string UpdateUser(Customer c, string name, string email, string password, string gender, string address)
        {
            try
            {
                return UserRepository.UpdateUser(c, name, email, password, gender, address);
            }
            catch (Exception ex)
            {
                return "Something wrong with handling process";
            }
        }

        public static string GetUserForLogin(string email, string password)
        {
            return UserRepository.GetUserForLogin(email, password);
        }

        public static Customer GetUserById(int id)
        {
            return UserRepository.GetUserById(id);
        }
    }
}