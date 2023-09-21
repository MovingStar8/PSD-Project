using KpopZtation.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KpopZtation.View.User
{
    public partial class InsertAlbum : System.Web.UI.Page
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
        }

        protected void InsertBtn_Click(object sender, EventArgs e)
        {
            if (ImageFile.HasFile)
            {
                string folderPath = Server.MapPath("~/Assets/Albums/");
                string status = AlbumController.InsertAlbum(AlbumNameTxb.Text, ImageFile.PostedFile, folderPath, int.Parse(AlbumPriceTxb.Text), int.Parse(AlbumStockTxb.Text), AlbumDescriptionTxb.Text, artistId.ToString());

                if (status.Equals("Success"))
                {
                    Response.Redirect("~/View/User/Artist.aspx?ID=" + artistId.ToString());
                }

                ErrorLbl.Text = status;
            }
            else
            {
                ErrorLbl.Text = "Please select a file.";
            }
        }
    }
}