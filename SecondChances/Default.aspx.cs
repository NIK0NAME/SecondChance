using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecondChances
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["user"] != null)
            {
                whois.InnerText = "Welcome " + (string)Session["user"];
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
            
        }
    }
}