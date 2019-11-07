using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using MySql.Data.MySqlClient;

namespace SecondChances
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection conn;

        //Conexion com mysql
        private MySqlConnection connection;
        private string server = "localhost";
        private string database = "dam_compartido_dev";
        private string uid = "root";
        private string password = "niko";

        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                alert_placer.InnerHtml = "";
                validarDatos();
            }
            else
            {

            }
        }

        public void validarDatos()
        {
            //Recogemos los datos del formulario previamente validados en el cliente (js)
            String user = data_user.Text;
            String pass = data_pass.Text;

            string connectionString;
            //Creamos el conection string para conectarnos a mySql
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            
            //Creamos la conexion
            connection = new MySqlConnection(connectionString);

            string query = "SELECT * FROM `secondchance.users` WHERE username = '" + user + "' and pass = '" + pass + "'";

           

            try
            {
                //Abrimos la conexion
                connection.Open();

                //Creamos el comado con la query y la conexion
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Ejecutamos la consulta y recibimos el resultado
                MySqlDataReader read = cmd.ExecuteReader();

                if (read.HasRows) {
                    read.Read();
                    alert_placer.InnerHtml += "<div class='ma_alert'>Los datos son correctos " + read.GetString("name") + "<i class='material-icons closable'>close</i></div>";

                    
                    Session["user"] = read.GetString("username");
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    alert_placer.InnerHtml += "<div class='ma_alert'>Los datos introducidos no son correctos<i class='material-icons closable'>close</i></div>";
                }

            }
            catch(Exception ex)
            {
                alert_placer.InnerHtml += "<div class='ma_alert'>"+ex+"<i class='material-icons closable'>close</i></div>";
            }
        }
    }
}