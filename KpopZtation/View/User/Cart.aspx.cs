using KpopZtation.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KpopZtation.View.User
{
    public partial class Cart : System.Web.UI.Page
    {
        private static string role;
        private static string uid;
        private static List<CartGV> albums;
        private static List<Model.Cart> carts;

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
                carts = CartController.GetCartByUserId(int.Parse(uid));
                albums = new List<CartGV>();
                foreach (var cart in carts)
                {
                    var album = AlbumController.GetAlbumById((int)cart.AlbumID);
                    var albumGV = new CartGV
                    {
                        AlbumID = album.AlbumID,
                        AlbumImage = album.AlbumImage,
                        AlbumDescription = album.AlbumDescription,
                        AlbumName = album.AlbumName,
                        AlbumPrice = album.AlbumPrice,
                        AlbumStock = cart.Qty
                    };
                    albums.Add(albumGV);
                }

                CartGridView.DataSource = albums;
                CartGridView.DataBind();

                if (albums.Count == 0) CheckoutBtn.Visible = false;
                else CheckoutBtn.Visible = true;
            }
        }

        protected void CheckoutBtn_Click(object sender, EventArgs e)
        {
            var status = TransactionController.InsertTransactionHeader(int.Parse(uid));
            int id = TransactionController.GetTransactionIdForDetail();

            foreach(var cart in carts)
            {
                var album = AlbumController.GetAlbumById(cart.AlbumID);
                album.AlbumStock = album.AlbumStock - cart.Qty;
                var insert = TransactionController.InsertTransactionDetail(id, cart.AlbumID, cart.Qty);
                var statusDetail = CartController.DeleteCartByAlbumId(cart.AlbumID);
            }

            Response.Redirect("~/View/User/Home.aspx");
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

        protected void CartGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow gv = CartGridView.Rows[e.RowIndex];
            var album = albums.Where(x => x.AlbumName.Equals(gv.Cells[1].Text)).FirstOrDefault();
            var cart = carts.Where(x => x.AlbumID == album.AlbumID).FirstOrDefault();
            var status = CartController.DeleteCartByAlbumId((int)cart.AlbumID);
            Response.Redirect("~/View/User/Cart.aspx");
        }
    }

    public class CartGV
    {
        public int AlbumID { get; set; }
        public string AlbumName { get; set; }
        public string AlbumImage { get; set; }
        public int AlbumPrice { get; set; }
        public int AlbumStock { get; set; }
        public string AlbumDescription { get; set; }
    }
}