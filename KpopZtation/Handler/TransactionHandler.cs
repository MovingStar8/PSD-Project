using KpopZtation.Factory;
using KpopZtation.Model;
using KpopZtation.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtation.Handler
{
    public class TransactionHandler
    {
        public static string InsertTransactionHeader(int custId)
        {
            return TransactionRepository.InsertTransactionHeader(TransactionFactory.CreateTransactionHeader(custId));
        }

        public static string InsertTransactionDetail(int trId, int aId, int qty)
        {
            return TransactionRepository.InsertTransactionDetail(TransactionFactory.CreateTransactionDetail(trId, aId, qty));
        }

        public static List<TransactionHeader> GetTransactionHeaders()
        {
            return TransactionRepository.GetTransactionHeaders();
        }

        public static List<TransactionHeader> GetTransactionHeaderById(int uid)
        {
            return TransactionRepository.GetTransactionHeaderById(uid);
        }

        public static List<TransactionDetail> GetTransactionDetailById(int tid)
        {
            return TransactionRepository.GetTransactionDetailById(tid);
        }

        public static int GetTransactionIdForDetail()
        {
            return TransactionRepository.GetTransactionIdForDetail();
        }
    }
}