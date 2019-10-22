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
            
        }

        //Hace magia pura cuando se le llama a esta funcion
        public void magia()
        {
            var cont = 0;
            for(cont = 0; cont < 25; cont++)
            {
                Response.Write("-+");
            }
        }

        //Otra funcion creada pero ya en la rama master con el merge de features
        public void noMana()
        {

        }
    }

}