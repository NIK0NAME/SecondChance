﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecondChances
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {

            }else
            {

            }
        }

        public void validarDatos()
        {
            String user = data_user.Text;
            String pass = data_pass.Text;
        }
    }
}