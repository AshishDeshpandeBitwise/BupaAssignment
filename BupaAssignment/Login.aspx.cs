using BupaAssignment.Data;
using BupaAssignment.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BupaAssignment
{
    public partial class Login : System.Web.UI.Page
    {
        private readonly UserRepository _context;
        public Login()
        {
            _context = new UserRepository();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                lblMessage.Attributes.Add("style", "display:none;");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate("vgLogin");
                if (Page.IsValid)
                {
                    BupaUser objUser = new Data.BupaUser();
                    objUser.UserName = txtUserName.Text;
                    objUser.Password = txtPassword.Text;

                    if (_context.IsValidCredentials(objUser))
                    {
                        AddUserCookie(objUser.UserName);
                        Response.Redirect("~/Programs");
                    }
                    else
                        ShowMessage("Invalid credentials", "warning");
                }
            }
            catch (Exception ex)
            {
                ShowMessage("Something went wrong. Please try again after sometime", "warning");
            }
        }

        private void AddUserCookie(string UserName)
        {
            HttpCookie objCookie = new HttpCookie("username");
            objCookie.Value = UserName;
            Response.Cookies.Add(objCookie);
        }

        private void ShowMessage(string message, string messageType)
        {
            lblMessage.Text = message;
            if (string.Equals(messageType.ToLower(), "warning"))
                lblMessage.Attributes.Add("class", "alert alert-warning");
            else
                lblMessage.Attributes.Add("class", "alert alert-info");
            lblMessage.Attributes.Add("style", "display:block;");
        }
    }
}