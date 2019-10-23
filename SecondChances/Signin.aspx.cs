using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using MySql.Data.MySqlClient;

namespace SecondChances
{
    public partial class Signin : System.Web.UI.Page
    {
        private MySqlConnection connection;
        private string server = "localhost";
        private string database = "dam_compartido_dev";
        private string uid = "root";
        private string password = "niko";

        String name, username, pass, mail;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                if( data_name.Text == ""
                    || data_user.Text == ""
                    || data_mail.Text == ""
                    || data_pass.Text == "")
                {
                    //Datos incompletos jajajajaj
                    Response.Write("<div class='ma_alert'>Faltan Datos</div>");
                }else
                {
                    //No hay campos vacios
                    make_connection();
                }
            }
        }

        public void make_connection()
        {
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
            //insert into `secondchance.users` (id, username, pass, name, mail)
            //values(0, `username`, `pass`, `name`, `mail`)

            try
            {
                connection.Open();
                
                String query = "insert into `secondchance.users` (id, username, pass, name, mail)" +
                                "values(0, @username, @pass, @name, @mail)";

                //Creamos el comado con la query y la conexion
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@username", data_user.Text);
                cmd.Parameters.AddWithValue("@pass", data_pass.Text);
                cmd.Parameters.AddWithValue("@name", data_name.Text);
                cmd.Parameters.AddWithValue("@mail", data_mail.Text);

                //Ejecutamos la query anteriormente preparada
                cmd.ExecuteNonQuery();
                Response.Write("<div class='ma_alert'>Datos insertados ;)</div>");
                connection.Close();

                data_user.Text = "";
                data_pass.Text = "";
                data_name.Text = "";
                data_mail.Text = "";
            }
            catch (MySqlException ex)
            {
                Response.Write("<div class='ma_alert'>" + ex + "</div>");
            }
        }
    }
}