using BupaAssignment.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BupaAssignment.Data;

namespace BupaAssignment
{
    public partial class Programs : System.Web.UI.Page
    {
        private readonly ProgramRepository _context;
        public Programs()
        {
            _context = new ProgramRepository();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                List<BupaProgram> lstPrograms = new List<BupaProgram>();

                if (IsLoggedInUser())
                    BindPrograms(GetPrograms(true), true);

                BindPrograms(GetPrograms(false), false);
            }
            catch (Exception ex)
            {
                ShowMessage("Something went wrong. Please try again after sometime", "warning");
            }
        }


        private List<BupaProgram> GetPrograms(bool isPaid)
        {
            return _context.GetPrograms(isPaid).ToList();

        }

        private void BindPrograms(List<BupaProgram> lstPrograms, bool isPaid)
        {

            if (isPaid)
            {
                dvPrivate.Visible = true;
                rptrPrivatePrograms.DataSource = lstPrograms;
                rptrPrivatePrograms.DataBind();
            }
            else
            {
                rptrPublicPrograms.DataSource = lstPrograms;
                rptrPublicPrograms.DataBind();
            }

        }

        private bool IsLoggedInUser()
        {
            return Request.Cookies.AllKeys.Contains("username");
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