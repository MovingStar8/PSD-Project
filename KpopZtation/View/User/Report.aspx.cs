using KpopZtation.Controller;
using KpopZtation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KpopZtation.View.User
{
    public partial class Report : System.Web.UI.Page
    {
        private static string role;
        private static string uid;
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["User"];

            role = "";

            if (cookie != null)
            {
                role = cookie["Role"];
                uid = cookie["Id"];
            }
            else if (Session["User"] != null)
            {
                role = Session["User"].ToString().Substring(0, Session["User"].ToString().IndexOf("#"));
                uid = Session["User"].ToString().Substring(Session["User"].ToString().IndexOf("#") + 1, Session["User"].ToString().Length - (Session["User"].ToString().IndexOf("#") + 1));
            }

            if (!role.Equals("Admin"))
            {
                Response.Redirect("~/View/User/Home.aspx");
            }

            List<TransactionHeader> th = TransactionController.GetTransactionHeaders();
            CrystalReport report = new CrystalReport();

            DataSet data = new DataSet();
            var dataReport = data.Report;

            int totalPrice = 0;
            int totalSubPrice = 0;
            int totalGrandPrice = 0;
            int prevOrderId = 0;

            foreach(var t in th)
            {
                var td = TransactionController.GetTransactionDetailById(t.TransactionID);
                List<TransactionDetail> list = td.Where(x => x.TransactionID == t.TransactionID).ToList();
                Customer c = UserController.GetUserById((int)t.CustomerID);
                
                foreach(var t2 in td)
                {
                    Model.Album a = AlbumController.GetAlbumById((int)t2.AlbumID);
                    if (prevOrderId == 0)
                    {
                        prevOrderId = t.TransactionID;
                    }
                    else if (prevOrderId != t.TransactionID)
                    {
                        totalSubPrice = 0;
                        prevOrderId = t.TransactionID;
                    }

                    var reportRow = dataReport.NewRow();

                    reportRow["TransactionId"] = t.TransactionID;
                    reportRow["Date"] = t.TransactionDate;
                    reportRow["CustomerName"] = c.CustomerName;
                    reportRow["Name"] = a.AlbumName;
                    reportRow["Price"] = a.AlbumPrice;
                    reportRow["Quantity"] = t2.Qty;

                    totalPrice = a.AlbumPrice * t2.Qty;
                    reportRow["TotalPrice"] = totalPrice;

                    totalSubPrice += totalPrice;
                    reportRow["TotalSubPrice"] = totalSubPrice;

                    if (t2.Equals(td.Last()))
                    {
                        totalGrandPrice += totalSubPrice;
                    }

                    reportRow["TotalGrandPrice"] = totalGrandPrice;

                    dataReport.Rows.Add(reportRow);
                }
            }

            report.SetDataSource(data);
            CrystalReportViewer.ReportSource = report;
        }
    }
}