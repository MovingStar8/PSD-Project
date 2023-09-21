using KpopZtation.Factory;
using KpopZtation.Model;
using KpopZtation.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtation.Handler
{
    public class CartHandler
    {
        public static string InsertCart(int custId, int albumId, int quantity)
        {
            return CartRepository.insertCart(CartFactory.createCart(custId, albumId, quantity));
        }

        public static List<Cart> GetCartByUserId(int uid)
        {
            return CartRepository.GetCartByUserId(uid);
        }

        public static string DeleteCartByAlbumId(int aid)
        {

            var cart = CartRepository.GetCartByAlbumId(aid);
            return CartRepository.DeleteCart(cart);
        }
    }
}