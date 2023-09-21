using KpopZtation.Handler;
using KpopZtation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtation.Controller
{
    public class TransactionController
    {
        public static string InsertTransactionHeader(int custId)
        {
            return TransactionHandler.InsertTransactionHeader(custId);
        }

        public static string InsertTransactionDetail(int trId, int aId, int qty)
        {
            return TransactionHandler.InsertTransactionDetail(trId, aId, qty);
        }

        public static List<TransactionHeader> GetTransactionHeaders()
        {
            return TransactionHandler.GetTransactionHeaders();
        }

        public static List<TransactionHeader> GetTransactionHeaderById(int uid)
        {
            return TransactionHandler.GetTransactionHeaderById(uid);
        }

        public static List<TransactionDetail> GetTransactionDetailById(int tid)
        { 
            return TransactionHandler.GetTransactionDetailById(tid);
        }

        public static int GetTransactionIdForDetail()
        {
            return TransactionHandler.GetTransactionIdForDetail();
        }
    }
}