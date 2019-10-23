using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace SecondChances
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Código que se ejecuta al iniciar la aplicación
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            //Funcion que se ejecuta cuando se crea la session
            Session["Usuario"] = "Anonimo";
            Session["Id"] = 0;
            Session["Autenticacion"] = false;

            //Guardamos el numero de usuarios conectados a la app
            Application["Users_connected"] = int.Parse(Application["Users_connected"].ToString()) + 1;
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Response.Redirect("~/Exepciones.htm");
        }
    }
}