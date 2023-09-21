using KpopZtation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtation.Repository
{
    public class TransactionRepository
    {
        private static DatabaseEntities db = ConnectDb.getDb();

        public static string InsertTransactionHeader(TransactionHeader th)
        {
            try
            {
                db.TransactionHeaders.Add(th);
                db.SaveChanges();

                return "Success";
            }
            catch (Exception ex)
            {
                return "something wrong with inserting process";
            }
        }

        public static List<TransactionHeader> GetTransactionHeaders()
        {
            return (from th in db.TransactionHeaders select th).ToList();
        }

        public static List<TransactionHeader> GetTransactionHeaderById(int uid)
        {
            return (from th in db.TransactionHeaders where th.CustomerID == uid select th).ToList();
        }

        public static List<TransactionDetail> GetTransactionDetailById(int tid)
        {
            return db.TransactionDetails.Where(x => x.TransactionID == tid).ToList();
        }

        public static string InsertTransactionDetail(TransactionDetail td)
        {
            try
            {
                db.TransactionDetails.Add(td);
                db.SaveChanges();

                Console.WriteLine(td);
                return "Success";
            }
            catch (Exception ex)
            {
                return "something wrong with inserting process";
            }
        }

        public static int GetTransactionIdForDetail()
        {
            return (from th in db.TransactionHeaders orderby th.TransactionID descending select th.TransactionID).FirstOrDefault();
        }
    }
}