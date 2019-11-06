using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecondChances
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                validarDatos();
            }
            else
            {

            }
        }

        public void validarDatos()
        {
            //Los datos vienen validados desde el cliente
            String user = data_user.Text;
            String pass = data_pass.Text;

            //Preparamos la query 
            string sql = "SELECT * FROM users WHERE username = '" + user + "' and pass = '" + pass + "'";

            SqlCommand cmd = new SqlCommand(sql, conn);
            //cmd.CommandText = sql;
            cmd.CommandType = System.Data.CommandType.Text;
            //cmd.Connection = conn;
            
            SqlDataReader reader = cmd.ExecuteReader();

            if(reader.HasRows)
            {
                //El usuario se ha logueado correctamente
                Response.Redirect("Default.aspx");
            }else
            {
                //Algo no rulo bene
            }
        }
    }
}