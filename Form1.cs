using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ver.Clases;
//using Microsoft.Data.SqlClient;



namespace ver
{
   
    public partial class Form1 : Form
    {
       


        private Conexion mConexion; //objeto de clase conexion
        public Form1()
        {
            InitializeComponent();
            mConexion = new Conexion();
        }
      

        /*

        //verifica si el registro ya existe antes de guardar
        private bool RegistroEsta(SqlConnection connection, string usuario) //private no todos lo pueden usar     conectado a la base de datos busca en fila codigo
        {
           
            string sql = "SELECT COUNT(*) FROM Cuenta WHERE Correo='" + usuario + "'";
            SqlCommand cmd = new SqlCommand(sql, connection); //objeto utiliza conexion y comando en bd
            int count = Convert.ToInt32(cmd.ExecuteScalar()); //execute devuelve en numeros lo que el objeto cmd encuentre
            return count > 0; //si es uno entonces ya existe si es cero no existe

        }                       */
                           
        private void button1_Click(object sender, EventArgs e)
        {

            /*
            //declarar variables tipo string
            String usuario = txtUsuario.Text;
            String contraseña = txtContraseña.Text;
          

            //comando para bd
            string sql = "INSERT INTO Cuenta (Correo, Contra) VALUES('" + usuario + "' , '" + contraseña + "')";

            SqlConnection connection = mConexion.getConexion(); // conexión a la bd


            try
            {
                connection.Open();
                if (RegistroEsta(connection, usuario))
                {
                    MessageBox.Show("Ya existe un registro con el mismo usuario");

                    return;

                }
                else
                {
                    SqlCommand comando = new SqlCommand(sql, connection);
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Cuenta guardado");


                }

            }
            catch (SqlException ex)
            {

                MessageBox.Show("Error: " + ex.Message);
            }  
            finally { connection.Close(); }   */

            
           
        }
        private void button2_Click(object sender, EventArgs e)
        {  /*
            Form2 form2 = new Form2();  //llamar el siguiente form
            form2.Show();  //mostrar siguiente interfaz
            this.Hide();   //se esconde una interfaz y aparece otra     */
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
           
            String usuario = txtUsuario.Text;
            String contraseña = txtContraseña.Text;

            string sql2 = "SELECT * FROM Cuenta WHERE Correo = @usuario AND Contra = @contraseña";
            SqlConnection connection = mConexion.getConexion(); // conexión a la bd
            connection.Open();

            SqlDataReader reader = null;

            try
            {
                
                SqlCommand comando = new SqlCommand(sql2, connection);
       

                comando.Parameters.AddWithValue("@usuario", usuario); //espacio listo para introducir lo que se escriba en la variable usuario
                comando.Parameters.AddWithValue("@contraseña", contraseña);  //se compara con los datos de la bd y si no marca error


                reader = comando.ExecuteReader();

                if (reader.HasRows)
                {     
                    DatosUsuario.CorreoUsuarioActual = usuario;  //viene de la clase nueva que hereda a otras interfaces
                    while (reader.Read())
                    {

                        txtId.Text = reader.GetInt32(0).ToString();
                        txtUsuario.Text = reader.GetString(1);
                        txtContraseña.Text = reader.GetString(2);

                       // if (usuario == txtUsuario.Text && contraseña == txtContraseña.Text)
                        //{

                            Form3 form3 = new Form3();  //llamar el siguiente form
                            form3.Show();  //mostrar siguiente interfaz
                            this.Hide();   //se esconde una interfaz y aparece otra

                            Form5 form5 = new Form5();  //llamar el siguiente form
                            form5.Show();
                        }
                    }
                        else
                        {
                            MessageBox.Show("Usuario o contraseña incorrectos, verifique de nuevo");
                        }

                   // }
              //  }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
            finally
            {
                reader.Close();   //cerrar lector
                connection.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form10 form10 = new Form10();  //llamar el siguiente form
            form10.Show();  //mostrar siguiente interfaz
            this.Hide();   //se esconde una interfaz y aparece otra

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

    public static class DatosUsuario   //nueva clase
    {
        // Variable estática accesible desde cualquier formulario
        public static string CorreoUsuarioActual;
    }
}
