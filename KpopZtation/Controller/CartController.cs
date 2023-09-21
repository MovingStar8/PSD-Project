using KpopZtation.Handler;
using KpopZtation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtation.Controller
{
    public class CartController
    {
        public static string InsertCart(int custId, int albumId, int quantity, int stock)
        {
            if (quantity == 0)
            {
                return "Quantity must be filled and with number";
            }

            if (quantity > stock)
            {
                return "Stock is not enough";
            }

            return CartHandler.InsertCart(custId, albumId, quantity);
        }

        public static string DeleteCartByAlbumId(int aid)
        {
            return CartHandler.DeleteCartByAlbumId(aid);
        }

        public static List<Cart> GetCartByUserId(int uid)
        {
            return CartHandler.GetCartByUserId(uid);
        }
    }
}