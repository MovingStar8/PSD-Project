using KpopZtation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtation.Factory
{
    public class TransactionFactory
    {
        public static TransactionHeader CreateTransactionHeader(int custId)
        {
            return new TransactionHeader
            {
                TransactionDate = DateTime.Now,
                CustomerID = custId
            };
        }

        public static TransactionDetail CreateTransactionDetail(int trId, int aId, int quantity)
        {
            return new TransactionDetail
            {
                Album = null,
                TransactionHeader = null,
                TransactionID = trId,
                AlbumID = aId,
                Qty = quantity
            };
        }
    }
}