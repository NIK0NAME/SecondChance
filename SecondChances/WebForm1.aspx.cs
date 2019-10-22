using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace SecondChances
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        //SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            String db_conn_string = ConfigurationManager.ConnectionStrings["mi_conexion"].ToString();

            SqlConnection conn = createConnection(db_conn_string);


            if (conn == null)
            {
                Response.Write("Peto la conexion con la base de datos");
                return;
            }

            String my_query = "INSERT INTO [dbo].[provedor] (nombre,direccion) VALUES ('Armendio', 'Homie del hambo Armendio')";
            String my_select = "SElECT * FROM [dbo].[products]";

            SqlCommand cmd = new SqlCommand(my_select, conn);

            SqlDataReader reader = cmd.ExecuteReader();

            GridView gr1 = new GridView();

            gr1.DataSource = reader;
            gr1.DataBind();
            gr1.CssClass = "beatifull-table";

            

            GridView1.DataSource = reader;
            GridView1.DataBind();
        }

        protected SqlConnection createConnection(String db_connection)
        {
            SqlConnection conn = new SqlConnection(db_connection);
            conn.Open();

            return conn;
        }
    }
}