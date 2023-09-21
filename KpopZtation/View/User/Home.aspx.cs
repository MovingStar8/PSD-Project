using KpopZtation.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KpopZtation.View.User
{
    public partial class Home : System.Web.UI.Page
    {
        private static string role;
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["User"];

            role = "";

            if (cookie != null)
            {
                role = cookie["Role"];
            }
            else if (Session["User"] != null)
            {
                role = Session["User"].ToString().Substring(0, Session["User"].ToString().IndexOf("#"));
            }

            if (role.Equals("Admin"))
            {
                InsertBtn.Visible = true;
                ArtistGridView.Columns[2].Visible = true;
            }

            if (!IsPostBack)
            {
                var artist = AlbumController.GetArtistList();
                ArtistGridView.DataSource = artist;
                ArtistGridView.DataBind();
            }
        }

        protected void ArtistGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton imageBtn = (ImageButton)e.Row.FindControl("ImageBtn");
                string imageUrl = DataBinder.Eval(e.Row.DataItem, "ArtistImage").ToString();
                imageBtn.ImageUrl = imageUrl;
                string rowId = DataBinder.Eval(e.Row.DataItem, "ArtistID").ToString();
                imageBtn.Attributes["data-rowId"] = rowId;
                imageBtn.Click += ImageBtn_Click;
            }
        }

        protected void ImageBtn_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton imageBtn = (ImageButton)sender;
            string rowId = imageBtn.Attributes["data-rowId"];
            Response.Redirect("~/View/User/Artist.aspx?ID=" + rowId);
        }

        protected void ArtistGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow gv = ArtistGridView.Rows[e.NewEditIndex];
            ImageButton imageBtn = (ImageButton)gv.FindControl("ImageBtn");
            string rowId = imageBtn.Attributes["data-rowId"];
            Response.Redirect("~/View/User/UpdateArtist.aspx?ID=" + rowId);
        }

        protected void ArtistGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow gv = ArtistGridView.Rows[e.RowIndex];
            ImageButton imageBtn = (ImageButton)gv.FindControl("ImageBtn");
            string rowId = imageBtn.Attributes["data-rowId"];
            var status = AlbumController.DeleteArtistById(rowId);
            Response.Redirect("~/View/User/Home.aspx");
        }

        protected void InsertBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/User/InsertArtist.aspx");
        }
    }
}