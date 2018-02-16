using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BupaAssignment
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ToggleLoginMenu();
        }

        private void ToggleLoginMenu()
        {
            if (Request.Cookies.AllKeys.Contains("username"))
            {
                login.Visible = false;
                register.Visible = false;
            }
            else
            {
                myprofile.Visible = false;
                btnLogout.Visible = false;
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Cookies["username"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("/programs");
        }
    }
}