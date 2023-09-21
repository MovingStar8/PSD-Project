using KpopZtation.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KpopZtation.View.User
{
    public partial class UpdateArtist : System.Web.UI.Page
    {
        private static int artistId;
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["User"];

            string role = "";

            if (cookie != null)
            {
                role = cookie["Role"];
            }
            else if (Session["User"] != null)
            {
                role = Session["User"].ToString().Substring(0, Session["User"].ToString().IndexOf("#"));
            }

            if (role.Equals(""))
            {
                Response.Redirect("~/View/Guest/Login.aspx");
            }

            if (!role.Equals("Admin"))
            {
                Response.Redirect("~/View/User/Home.aspx");
            }

            artistId = int.Parse(Request.QueryString["ID"]);

            if (!IsPostBack)
            {
                var artist = AlbumController.GetArtistById(artistId);
                ArtistNameTxb.Text = artist.ArtistName;
            }
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (ImageFile.HasFile)
            {
                string folderPath = Server.MapPath("~/Assets/Artists/");
                string status = AlbumController.UpdateArtist(ArtistNameTxb.Text, ImageFile.PostedFile, folderPath, artistId.ToString());

                if (status.Equals("Success"))
                {
                    Response.Redirect("~/View/User/Home.aspx");
                }

                ErrorLbl.Text = status;
            }
            else
            {
                ErrorLbl.Text = "Please select a file.";
            }
        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/User/Home.aspx");
        }
    }
}