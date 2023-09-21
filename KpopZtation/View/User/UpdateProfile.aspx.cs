using KpopZtation.Controller;
using KpopZtation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KpopZtation.View.User
{
    public partial class UpdateProfile : System.Web.UI.Page
    {
        private static Customer c;

        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["User"];

            string role = "";
            string id = "";

            if (cookie != null)
            {
                role = cookie["Role"];
                id = cookie["Id"];
            }
            else if (Session["User"] != null)
            {
                role = Session["User"].ToString().Substring(0, Session["User"].ToString().IndexOf("#"));
                id = Session["User"].ToString().Substring(Session["User"].ToString().IndexOf("#") + 1, Session["User"].ToString().Length - (Session["User"].ToString().IndexOf("#") + 1));
            }

            if (role.Equals(""))
            {
                Response.Redirect("~/View/Guest/Login.aspx");
            }

            int searchId = int.Parse(id);

            c = UserController.GetUserById(searchId);

            if (!IsPostBack)
            {
                NameTxb.Text = c.CustomerName;
                EmailTxb.Text = c.CustomerEmail;
                GenderRadioBtn.SelectedValue = c.CustomerGender;
                AddressTxb.Text = c.CustomerAddress;
                PasswordTxb.Text = c.CustomerPassword;
            }
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            string testUpdate = UserController.UpdateUser(c, NameTxb.Text, EmailTxb.Text, PasswordTxb.Text, GenderRadioBtn.SelectedValue, AddressTxb.Text);
            if (testUpdate.Equals("Update Success"))
            {
                Response.Redirect("~/View/User/Home.aspx");
            }

            ErrorLbl.Text = testUpdate;
        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/User/Home.aspx");
        }
    }
}