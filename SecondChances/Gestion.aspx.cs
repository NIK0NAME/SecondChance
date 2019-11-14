using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecondChances
{
    public partial class Gestion : System.Web.UI.Page
    {
        String estado;

        //Conexion com mysql
        public MySqlConnection connection;
        public string server = "localhost";
        public string database = "secondchance";//"dam_compartido_dev";
        public string uid = "root";
        public string password = "usbw";

        string connectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            if (Session["user"] == null || Int32.Parse(Session["admin"].ToString()) == 0)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                if(!IsPostBack)
                {
                    estado = "neutro";
                    gest_estado.Value = "neutro";
                    Page.Title = "Gestion";
                    toolbar_gestion.Visible = false;
                    expositor_gestion.InnerHtml = "Selecciona una opcion de Gestion";
                }else
                {
                    Page.Title = "Gestion " + gest_estado.Value;
                }
            }
        }

       

        protected void gest_usuario_Click(object sender, EventArgs e)
        {
            //estado = "usuario";
            gest_estado.Value = "usuario";
            Page.Title = "Gestion " + gest_estado.Value;
            expositor_gestion.InnerHtml = "<h1>Opcion Gestion Usuario Seleccionada</h1>";
            cargar_elementos();

            form_add_user.Visible = true;

            cargarUsuarios();
        }

        protected void gest_productos_Click(object sender, EventArgs e)
        {
            estado = "producto";
            gest_estado.Value = "producto";
            Page.Title = "Gestion " + gest_estado.Value;
            expositor_gestion.InnerHtml = "<h1>Opcion Gestion Productos Seleccionada</h1>";

            form_add_user.Visible = false;
            cargar_elementos();
        }

        protected void gest_categorias_Click(object sender, EventArgs e)
        {
            estado = "categoria";
            gest_estado.Value = "categoria";
            Page.Title = "Gestion " + gest_estado.Value;
            expositor_gestion.InnerHtml = "<h1>Opcion Gestion Categorias Seleccionada</h1>";

            form_add_user.Visible = false;
            cargar_elementos();
        }

        public void cargar_elementos()
        {
            toolbar_gestion.Visible = true;
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            
            expositor_gestion.InnerHtml = "<h1>Añadimos " + gest_estado.Value + "</h1>";
            if(gest_estado.Value == "usuario")
            {
                add_user();
            }
        }

        protected void btn_remove_Click(object sender, EventArgs e)
        {
            expositor_gestion.InnerHtml = "<h1>Removemos " + sender.ToString() + "</h1>";
        }

        public void add_user()
        {
            String nombre = txt_user_nombre.Text;
            String username = txt_user_username.Text;
            String pass = txt_user_pass.Text;
            String mail = txt_user_mail.Text;
            Boolean admin = check_user_admin.Checked;
            expositor_gestion.InnerHtml += "<p>Usuario " + nombre + " añadido</p>";



            connection = new MySqlConnection(connectionString);
            //insert into `secondchance.users` (id, username, pass, name, mail)
            //values(0, `username`, `pass`, `name`, `mail`)

            try
            {
                connection.Open();
                int isAdm = admin == true ? 1 : 0;

                String query = "insert into `usuarios` (id, username, pass, nombre, mail, admin)" +
                                "values('', '" + username + "', '" + pass + "', '" + nombre + "', '" + mail + "', " + isAdm + ")";

                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                expositor_gestion.InnerHtml += "<h1>Algo ha ido mal" + ex + "</h1>";
            }

            txt_user_nombre.Text = "";
            txt_user_mail.Text = "";
            txt_user_pass.Text = "";
            txt_user_username.Text = "";
            cargarUsuarios();
        }

        public void generarTabla(string [] cols, MySqlDataReader read)
        {
            String tabla = "<table style='width: 100%;'>";
            tabla += "<tr>";
            for(int i = 0; i < cols.Length; i++)
            {
                tabla += "<th>" + cols[i] + "</th>";
            }
            tabla += "<th>Actions</th>";
            tabla += "</tr>";
            while(read.Read())
            {
                tabla += "<tr>";
                for (int i = 0; i < cols.Length; i++)
                {
                    
                    tabla += "<td>" + read.GetValue(i).ToString() +"</td>";
                }
                //Opciones de row
                tabla += "<td><div class='tb_action' onclick='removeMeARow("+read.GetValue(0)+")'>Remove</div></td>";
                tabla += "</tr>";
            }
            tabla += "</table>";
            expositor_gestion.InnerHtml = tabla;
        }

        public void cargarUsuarios()
        {
            //expositor_gestion.InnerHtml;
            connection = new MySqlConnection(connectionString);

            String query = "SELECT * FROM `usuarios`";

            try
            {
                //Abrimos la conexion
                connection.Open();
                //return;
                //Creamos el comado con la query y la conexion
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Ejecutamos la consulta y recibimos el resultado
                MySqlDataReader read = cmd.ExecuteReader();

                if (read.HasRows)
                {
                    String[] cols = { "id", "nombre", "username", "pass", "mail", "admin"};
                    expositor_gestion.InnerHtml = "";
                    generarTabla(cols, read);
                    /*while (read.Read())
                    {
                        expositor_gestion.InnerHtml += "<h3>" + read.GetString("username") + "</h3>";
                    }*/
                }
                else
                {
                    expositor_gestion.InnerHtml += "<h1>No hay usuarios</h1>";
                }

            }
            catch (Exception ex)
            {
                expositor_gestion.InnerHtml += "<h1>Algo ha ido mal" + ex + "</h1>";
            }
        }
    }
}