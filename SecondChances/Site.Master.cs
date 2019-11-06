using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecondChances
{
    public partial class SiteMaster : MasterPage
    {
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