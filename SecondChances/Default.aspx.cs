using MySql.Data.MySqlClient;
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
        //Conexion com mysql
        private MySqlConnection connection;
        private string server = "localhost";
        private string database = "secondchance";//"dam_compartido_dev";
        private string uid = "root";
        private string password = "usbw";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["user"] != null)
            {
                //whois.InnerText = "Welcome " + (string)Session["user"];
                cargarProductos();
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
            
        }

        public void cargarProductos()
        {
            string connectionString;
            //Creamos el conection string para conectarnos a mySql
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            //Creamos la conexion
            connection = new MySqlConnection(connectionString);
            string query = "SELECT * FROM `productos` LIMIT 50";

            try
            {
                connection.Open();

                //Creamos el comado con la query y la conexion
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Ejecutamos la consulta y recibimos el resultado
                MySqlDataReader read = cmd.ExecuteReader();

                while(read.Read())
                {
                    string elem = "<div class='prd'>";
                    elem += "<div class='pr_prize'>" + read.GetDecimal("precio").ToString() + " $</div>";
                    elem += "<img src='" + read.GetString("img") + "' alt='pr_photo'/>";
                    elem += "<div class='pr_name'>" + read.GetString("nombre") + "</div>";
                    elem += "</div>";
                    pr_list.InnerHtml += elem;
                }
                connection.Close();
            }
            catch(Exception e)
            {

            }
        }
    }
}