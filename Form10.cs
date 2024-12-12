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
    public partial class Form10 : Form
    {
        private Conexion mConexion; //objeto de clase conexion
        public Form10()
        {
            InitializeComponent();
            mConexion = new Conexion();
        }

        private bool RegistroEsta(SqlConnection connection, string usuario) //private: no todos lo pueden usar     conectado a la base de datos busca en fila codigo
        {

            string sql = "SELECT COUNT(*) FROM Cuenta WHERE Correo='" + usuario + "'";
            SqlCommand cmd = new SqlCommand(sql, connection); //objeto utiliza conexion y comando en bd
            int count = Convert.ToInt32(cmd.ExecuteScalar()); //execute devuelve en numeros lo que el objeto cmd encuentre
            return count > 0; //si es uno entonces ya existe si es cero no existe

        }
        private void btnGuardar_Click(object sender, EventArgs e)
        { 
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
            finally { connection.Close(); }

        }

        private void btnSus_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();  //llamar el siguiente form
            form2.Show();  //mostrar siguiente interfaz
            this.Hide();   //se esconde una interfaz y aparece otra
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();  //llamar el siguiente form
            form1.Show();  //mostrar siguiente interfaz
            this.Hide();   //se esconde una interfaz y aparece otra
        }
    }
}
