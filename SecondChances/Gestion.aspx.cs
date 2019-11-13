using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecondChances
{
    public partial class Gestion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || Int32.Parse(Session["admin"].ToString()) == 0)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                
            }
        }
    }
}