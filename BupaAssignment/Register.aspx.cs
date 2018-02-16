using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BupaAssignment.Data;
using BupaAssignment.Repository;
using System.Web.UI.HtmlControls;

namespace BupaAssignment
{
    public partial class Register : System.Web.UI.Page
    {
        private readonly UserRepository _context;
        public Register()
        {
            _context = new UserRepository();
        }

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                lblMessage.Attributes.Add("style", "display:none;");
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate("vgRegister");
                if (Page.IsValid)
                {
                    if (!IsUserNameExist(txtUserName.Text))
                    {
                        BupaUser objUser = new Data.BupaUser();
                        objUser.Firstname = txtFirstName.Text;
                        objUser.LastName = txtLastName.Text;
                        objUser.UserName = txtUserName.Text;
                        objUser.Password = txtPassword.Text;

                        _context.Insert(objUser);
                        _context.SaveChanges();
                        ClearInput();
                        ShowMessage("Registration successful !!!", string.Empty);
                    }
                    else
                        ShowMessage("Useranme already exist", "warning");
                }
            }
            catch (Exception ex)
            {
                ShowMessage("Something went wrong. Please try again after sometime", "warning");
            }
        }

        #endregion

        #region Methods

        private bool IsUserNameExist(string userName)
        {
            return _context.IsUserNameExist(userName);
        }

        private void ClearInput()
        {
            foreach (Control c in Page.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    ((TextBox)(c)).Text = string.Empty;
                }
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
        #endregion


    }
}