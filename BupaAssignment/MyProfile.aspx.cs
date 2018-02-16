using BupaAssignment.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BupaAssignment.Repository;
namespace BupaAssignment
{
    public partial class MyProfile : System.Web.UI.Page
    {
        private readonly UserRepository _context;
        public MyProfile()
        {
            _context = new UserRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (IsLoggedInUser())
                    {
                        var user = GetMyProfileData(Request.Cookies["username"].Value);
                        if (user != null)
                            BindDataToControls(user);
                        else
                            ShowMessage("Something went wrong!", "warning");
                    }
                    else
                        Response.Redirect("/Login");
                }
            }
            catch (Exception ex)
            {
                ShowMessage("Something went wrong. Please try again after sometime", "warning");
            }
        }

        private bool IsLoggedInUser()
        {
            return Request.Cookies.AllKeys.Contains("username");
        }

        private BupaUser GetMyProfileData(string userName)
        {
            var user = _context.GetUserByUserName(userName);
            if (user != null)
                return user;
            else
                return null;
        }

        private void BindDataToControls(BupaUser bupaUser)
        {
            if (bupaUser != null)
            {
                txtUserId.Text = Convert.ToString(bupaUser.UserId);
                txtUserName.Text = bupaUser.UserName;
                txtFirstName.Text = bupaUser.Firstname;
                txtLastName.Text = bupaUser.LastName;
            }
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate("vgMyProfile");
                if (Page.IsValid)
                {
                    BupaUser objUser = new Data.BupaUser();
                    objUser.UserId = Convert.ToInt32(txtUserId.Text);
                    objUser.Firstname = txtFirstName.Text;
                    objUser.LastName = txtLastName.Text;
                    objUser.UserName = txtUserName.Text;
                    objUser.Password = txtPassword.Text;

                    _context.Update(objUser);
                    _context.SaveChanges();
                    ShowMessage("Profile updated successfully!", string.Empty);
                }
            }
            catch (Exception ex)
            {
                ShowMessage("Something went wrong. Please try again after sometime", "warning");
            }
        }
    }
}