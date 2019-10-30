using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//using MySql.Data.MySqlClient;

namespace SecondChances
{
    public partial class Signin : System.Web.UI.Page
    {
        //Conexion com mysql
        //private MySqlConnection connection;
        private string server = "localhost";
        private string database = "dam_compartido_dev";
        private string uid = "root";
        private string password = "niko";

        //Conexion con SQL Server
        SqlConnection con;

        String name, username, pass, mail;
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
             * Si la pagina recibe el evento POST (normalmente pasa cuando se submitea un fromulario, por defecto todos 
             * los botonos dentor del form lanzan este evento)
             */
            if(IsPostBack)
            {
                //Pequeña validacion, por si al usuario se le ha olvidado introducir algun dato ;)
                if( data_name.Text == ""
                    || data_user.Text == ""
                    || data_mail.Text == ""
                    || data_pass.Text == "")
                {
                    //Datos incompletos jajajajaj
                    Response.Write("<div class='ma_alert'>Faltan Datos<i class='material-icons closable'>close</i></div>");
                }else
                {
                    //No hay campos vacios por lo tanto procedemos a insertar los datos en la base de datos
                    conectSQLServer();
                }
            }
        }

        public void conectSQLServer()
        {
            //Creamos la conexion con SQL sever con el conecition string que esta en web.config
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["mi_conexion"].ConnectionString);

            /*
             * Utilizamos un try catch para poder gestionar los errores de ejecucion, de esta forma si durante la 
             * ejecucuin se produce algun error, el programa no se para y lo podemos gestionar nosotros.
            */
            try
            {
                //Abrimos la conexion
                con.Open();

                /*
                 * Creamos el comando, que prepara un procedimento almacenado, le pasamos el nombre del procediminto
                 * y la conexion con el servidor
                 * En nuestro caso es un procedimiento que inserta usuarios la base de datos
                */
                SqlCommand cmd = new SqlCommand("SecondChance.sp_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure; //Especificamos que es un porcedimiento almacenado

                /*
                 * Asignamos los parametros al procedimiento almacenado - nombre, valor
                 * En el caso del id recibe un 0 ya que se autoincrementa en la base de datos
                 */
                cmd.Parameters.AddWithValue("@UserID", 0);
                cmd.Parameters.AddWithValue("@First_Name", data_name.Text.ToString());
                cmd.Parameters.AddWithValue("@Email", data_mail.Text.ToString());
                cmd.Parameters.AddWithValue("@Password", data_pass.Text.ToString());
                cmd.Parameters.AddWithValue("@Username", data_user.Text.ToString());

                //Ejecutamos el procediminto y obtenemos el resultado de la ejecucion
                int codereturn = (int)cmd.ExecuteScalar();

                //Gestionamos el resutado obtenido del procediminto
                if(codereturn == -1)
                {
                    this.Master.thorwAlertDude("El usuario ya existe DUDE");
                    //Response.Write("<div class='ma_alert'>El usuario ya existe :(<i class='material-icons closable'>close</i></div>");
                }else
                {
                    //Si todo ha ido bien, es decir si la ejecucion llega a este punto, redirigimos al usuario al login
                    Response.Redirect("~/Login.aspx");
                }
            }
            catch (Exception ex)
            {
                this.Master.thorwAlertDude(ex.ToString());
                //Si ocurre alguna cosa extraña durante la ejecucion lo mostraremos con un alert personalizado
                //Response.Write("<div class='ma_alert'>" + ex + "<i class='material-icons closable'>close</i></div>");
            }
        }

        public void make_connection()
        {
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            //connection = new MySqlConnection(connectionString);
            //insert into `secondchance.users` (id, username, pass, name, mail)
            //values(0, `username`, `pass`, `name`, `mail`)

            try
            {
                //connection.Open();
                
                String query = "insert into `secondchance.users` (id, username, pass, name, mail)" +
                                "values(0, @username, @pass, @name, @mail)";

                //Creamos el comado con la query y la conexion
                //MySqlCommand cmd = new MySqlCommand(query, connection);

                /*cmd.Parameters.AddWithValue("@username", data_user.Text);
                cmd.Parameters.AddWithValue("@pass", data_pass.Text);
                cmd.Parameters.AddWithValue("@name", data_name.Text);
                cmd.Parameters.AddWithValue("@mail", data_mail.Text);
                */
                //Ejecutamos la query anteriormente preparada
                /*
                cmd.ExecuteNonQuery();
                Response.Write("<div class='ma_alert'>Datos insertados ;)</div>");
                connection.Close();
                */
                
                data_user.Text = "";
                data_pass.Text = "";
                data_name.Text = "";
                data_mail.Text = "";
            }
            catch (Exception ex)
            {
                Response.Write("<div class='ma_alert'>" + ex + "<i class='material-icons closable'>close</i></div>");
            }
        }
    }
}