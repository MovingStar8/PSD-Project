using KpopZtation.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KpopZtation.View.User
{
    public partial class Album : System.Web.UI.Page
    {
        private static string role;
        private static string uid;
        private static int albumId;
        private static int stock;

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

            if (role.Equals("Cust"))
            {
                AddCartBtn.Visible = true;
                QuantityLbl.Visible = true;
                QuantityTxb.Visible = true;
            }

            albumId = int.Parse(Request.QueryString["ID"]);

            if (!IsPostBack)
            {
                var album = AlbumController.GetAlbumById(albumId);
                stock = album.AlbumStock;
                List<Model.Album> albums = new List<Model.Album>();
                albums.Add(album);
                AlbumGridView.DataSource = albums;
                AlbumGridView.DataBind();
            }
        }

        protected void AlbumGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Image image = (Image)e.Row.FindControl("ImageBtn");
                string imageUrl = DataBinder.Eval(e.Row.DataItem, "AlbumImage").ToString();
                image.ImageUrl = imageUrl;
            }
        }

        protected void AddCartBtn_Click(object sender, EventArgs e)
        {
            string status;
            int parsedValue;
            if (int.TryParse(QuantityTxb.Text, out parsedValue))
            {
                
            }
            else
            {
                parsedValue = 0;
            }

            status = CartController.InsertCart(int.Parse(uid), albumId, parsedValue, stock);
            if (status.Equals("Success"))
            {
                ErrorLbl.ForeColor = System.Drawing.Color.Green;
            }
            
            ErrorLbl.Text = status;
        }
    }
}