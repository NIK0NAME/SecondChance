using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecondChances
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                /*string contento = File.ReadAllText("~/header.html");
                mi_header.InnerHtml = contento;*/
                Response.WriteFile("header.html");
            }
            //Response.Write("<script language='javascript'>alert('aa');</script>");

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public void thorwAlertDude(String msg)
        {
            String html_elem = "<div class='ma_alert'>" + msg + "<i class='material-icons closable'>close</i></div>";
            alert_placer.InnerHtml += html_elem;
            //Response.Write("<div class='ma_alert'>" + msg + "<i class='material-icons closable'>close</i></div>");
        }

        public void cleanAlerts()
        {
            alert_placer.InnerHtml = "";
        }
    }
}