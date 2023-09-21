using KpopZtation.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KpopZtation.View.Guest
{
    public partial class Login : System.Web.UI.Page
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

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            var getUser = UserController.GetUserForLogin(EmailTxb.Text, PasswordTxb.Text);

            if (getUser.Contains("#"))
            {
                if (RememberMeCB.Checked)
                {
                    HttpCookie cookie = new HttpCookie("User");
                    cookie["Id"] = getUser.Substring(getUser.IndexOf("#") + 1, getUser.Length - (getUser.IndexOf("#") + 1));
                    cookie["Role"] = getUser.Substring(0, getUser.IndexOf("#"));
                    cookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(cookie);
                }
                else
                {
                    Session["User"] = getUser;
                }

                Response.Redirect("~/View/User/Home.aspx");
            }
            else
            {
                ErrorLbl.Text = getUser;
            }
        }
    }
}