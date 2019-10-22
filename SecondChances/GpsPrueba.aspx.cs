using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecondChances
{
    public partial class GpsPrueba : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var london = new Savage.GPS.Position(-0.1, 51.52);
            var sanFrancisco = new Savage.GPS.Position(-122.45, 37.77);

            var distance = london.DistanceFrom(sanFrancisco);
        }
    }
}