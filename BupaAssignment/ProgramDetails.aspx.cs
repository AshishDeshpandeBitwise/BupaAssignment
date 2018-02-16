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
    public partial class ProgramDetails : System.Web.UI.Page
    {
        private readonly ProgramRepository _context;
        public ProgramDetails()
        {
            _context = new ProgramRepository();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["id"] != null)
                    LoadProgramDetails(Convert.ToInt32(Request.QueryString["id"]));
                else
                    ShowMessage("Bad request. please go back to <a href='/programs'>List</a>", "warning");
            }
            catch (Exception ex)
            {
                ShowMessage("Something went worng!", "warning");
            }
        }

        private bool IsLoggedInUser()
        {
            return Request.Cookies.AllKeys.Contains("username");
        }

        private bool IsPaidProgram(int Id)
        {
            return _context.isPaidProgram(Id);
        }

        private void LoadProgramDetails(int Id)
        {
            if (IsPaidProgram(Id))
            {
                if (IsLoggedInUser())
                    BindProgramDetails(GetProgramDetails(Id));
                else
                    Response.Redirect("/Login");
            }
            else
                BindProgramDetails(GetProgramDetails(Id));

        }

        private BupaProgram GetProgramDetails(int Id)
        {
            return _context.GetProgramDetails(Id);
        }

        private void BindProgramDetails(BupaProgram bupaProgram)
        {
            rptrPrograms.DataSource = new[] { bupaProgram };
            rptrPrograms.DataBind();
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