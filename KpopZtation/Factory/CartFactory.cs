using KpopZtation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtation.Factory
{
    public class CartFactory
    {
        public static Cart createCart(int custId, int albumId, int quantity)
        {
            return new Cart
            {
                CustomerID = custId,
                AlbumID = albumId,
                Qty = quantity
            };
        }
    }
}