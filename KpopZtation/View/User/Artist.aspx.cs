using KpopZtation.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KpopZtation.View.User
{
    public partial class Artist : System.Web.UI.Page
    {
        private static int artistId;
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
                AlbumGridView.Columns[5].Visible = true;
            }

            artistId = int.Parse(Request.QueryString["ID"]);

            if (!IsPostBack)
            {
                var artist = AlbumController.GetArtistById(artistId);
                ArtistNameTxb.Text = artist.ArtistName;
                ArtistImg.ImageUrl = artist.ArtistImage;

                var album = AlbumController.GetAlbumList(artistId);
                AlbumGridView.DataSource = album;
                AlbumGridView.DataBind();
            }
        }

        protected void AlbumGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton imageBtn = (ImageButton)e.Row.FindControl("ImageBtn");
                string imageUrl = DataBinder.Eval(e.Row.DataItem, "AlbumImage").ToString();
                imageBtn.ImageUrl = imageUrl;
                string rowId = DataBinder.Eval(e.Row.DataItem, "AlbumID").ToString();
                imageBtn.Attributes["data-rowId"] = rowId;
                imageBtn.Click += ImageBtn_Click;
            }
        }

        protected void AlbumGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow gv = AlbumGridView.Rows[e.NewEditIndex];
            ImageButton imageBtn = (ImageButton)gv.FindControl("ImageBtn");
            string rowId = imageBtn.Attributes["data-rowId"];
            Response.Redirect("~/View/User/UpdateAlbum.aspx?ID=" + rowId);
        }

        protected void AlbumGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow gv = AlbumGridView.Rows[e.RowIndex];
            ImageButton imageBtn = (ImageButton)gv.FindControl("ImageBtn");
            string rowId = imageBtn.Attributes["data-rowId"];
            var status = AlbumController.DeleteAlbumById(rowId);
            Response.Redirect("~/View/User/Artist.aspx?ID=" + artistId.ToString());
        }

        protected void InsertBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/User/InsertAlbum.aspx?ID=" + artistId.ToString());
        }

        protected void ImageBtn_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton imageBtn = (ImageButton)sender;
            string rowId = imageBtn.Attributes["data-rowId"];
            Response.Redirect("~/View/User/Album.aspx?ID=" + rowId);
        }
    }
}