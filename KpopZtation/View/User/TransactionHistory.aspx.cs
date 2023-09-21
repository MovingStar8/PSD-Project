using KpopZtation.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KpopZtation.View.User
{
    public partial class TransactionHistory : System.Web.UI.Page
    {
        private static string role;
        private static string uid;
        private static List<CartGV> albums;
        private static List<Model.TransactionHeader> th;
        private static List<TransactionHeaderGV> thGV;
        private static List<Model.TransactionDetail> td;

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

            if (!role.Equals("Cust"))
            {
                Response.Redirect("~/View/User/Home.aspx");
            }

            if (!IsPostBack)
            {
                thGV = new List<TransactionHeaderGV>();
                th = TransactionController.GetTransactionHeaderById(int.Parse(uid));
                foreach(var t in th)
                {
                    var customer = UserController.GetUserById(int.Parse(uid));
                    TransactionHeaderGV tGV = new TransactionHeaderGV
                    {
                        TransactionID = t.TransactionID,
                        CustomerName = customer.CustomerName
                    };
                    thGV.Add(tGV);
                }

                TransactionGridView.DataSource = thGV;
                TransactionGridView.DataBind();
            }
        }

        protected void CartGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Image image = (Image)e.Row.FindControl("ImageBtn");
                string imageUrl = DataBinder.Eval(e.Row.DataItem, "AlbumImage").ToString();
                image.ImageUrl = imageUrl;
            }
        }

        protected void TransactionGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            CartGridView.Visible = true;
            GridViewRow gv = TransactionGridView.Rows[e.RowIndex];
            td = new List<Model.TransactionDetail>();
            Console.WriteLine(td);

            td = TransactionController.GetTransactionDetailById(int.Parse(gv.Cells[0].Text));
            albums = new List<CartGV>();
            foreach (var t in td)
            {
                var album = AlbumController.GetAlbumById(t.AlbumID);
                var albumGV = new CartGV
                {
                    AlbumID = album.AlbumID,
                    AlbumImage = album.AlbumImage,
                    AlbumDescription = album.AlbumDescription,
                    AlbumName = album.AlbumName,
                    AlbumPrice = album.AlbumPrice,
                    AlbumStock = t.Qty
                };
                albums.Add(albumGV);
            }

            CartGridView.DataSource = albums;
            CartGridView.DataBind();
        }
    }

    public class TransactionHeaderGV
    {
        public int TransactionID { get; set; }
        public string CustomerName { get; set; }
    }
}