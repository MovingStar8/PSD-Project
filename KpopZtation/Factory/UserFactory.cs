using KpopZtation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtation.Factory
{
    public class UserFactory
    {
        public static Customer createCustomer(string name, string email, string password, string gender, string address)
        {
            return new Customer
            {
                CustomerName = name,
                CustomerEmail = email,
                CustomerPassword = password,
                CustomerGender = gender,
                CustomerAddress = address,
                CustomerRole = "Cust"
            };
        }
    }
}