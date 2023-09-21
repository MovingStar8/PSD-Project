using KpopZtation.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KpopZtation.View.Guest
{
    public partial class Register : System.Web.UI.Page
    {
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

            if (!role.Equals(""))
            {
                Response.Redirect("~/View/User/Home.aspx");
            }
        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            string testInsert = UserController.InsertUser(NameTxb.Text, EmailTxb.Text, PasswordTxb.Text, GenderRadioBtn.SelectedValue, AddressTxb.Text);
            if (testInsert == "Insert Success")
            {
                Response.Redirect("~/View/Guest/Login.aspx");
            }
            else
            {
                ErrorLbl.Text = testInsert;
            }
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Guest/Login.aspx");
        }
    }
}