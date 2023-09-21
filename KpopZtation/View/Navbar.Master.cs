using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KpopZtation.View
{
    public partial class Navbar : System.Web.UI.MasterPage
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

            if (role.Equals("Admin"))
            {
                LoginBtn.Visible = false;
                RegisterBtn.Visible = false;
                CartBtn.Visible = false;
                TransactionBtn.Visible = false;
                UpdateProfileBtn.Visible = false;
            }
            else if (role.Equals("Cust"))
            {
                LoginBtn.Visible = false;
                RegisterBtn.Visible = false;
                ReportBtn.Visible = false;
            }
            else
            {
                CartBtn.Visible = false;
                TransactionBtn.Visible = false;
                UpdateProfileBtn.Visible = false;
                ReportBtn.Visible = false;
                LogoutBtn.Visible = false;
            }
        }

        protected void HomeBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/User/Home.aspx");
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Guest/Login.aspx");
        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Guest/Register.aspx");
        }

        protected void CartBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/User/Cart.aspx");
        }

        protected void TransactionBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/User/TransactionHistory.aspx");
        }

        protected void UpdateProfileBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/User/UpdateProfile.aspx");
        }

        protected void ReportBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/User/Report.aspx");
        }

        protected void LogoutBtn_Click(object sender, EventArgs e)
        {
            string[] myCookie = Request.Cookies.AllKeys;
            foreach (string cookie in myCookie)
            {
                Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
            }
            Session.Clear();

            Response.Redirect("~/View/Guest/Login.aspx");
        }
    }
}