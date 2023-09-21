using KpopZtation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtation.Repository
{
    public class CartRepository
    {
        private static DatabaseEntities db = ConnectDb.getDb();

        public static string insertCart(Cart a)
        {
            try
            {
                db.Carts.Add(a);
                db.SaveChanges();

                return "Success";
            }
            catch (Exception ex)
            {
                return "Something wrong with inserting process";
            }
        }

        public static List<Cart> GetCartByUserId(int uid)
        {
            return (from c in db.Carts where c.CustomerID == uid select c).ToList();
        }

        public static Cart GetCartByAlbumId(int aid)
        {
            return (from c in db.Carts where c.AlbumID == aid select c).FirstOrDefault();
        }

        public static string DeleteCart(Cart a)
        {
            try
            {
                db.Carts.Remove(a);
                db.SaveChanges();

                return "Success";
            }
            catch (Exception ex)
            {
                return "there's something wrong with deleting process";
            }
        }
    }
}