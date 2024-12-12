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
using static ver.Form8;
//using Microsoft.Data.SqlClient;

namespace ver
{
   
    public partial class Form9 : Form
    {
        private Conexion mConexion; //objeto de clase conexion

    
        public Form9(string b, string numero)
        {
            InitializeComponent();
            mConexion = new Conexion();

            txtB.Text = b;
            txtNumero.Text = numero;
        }

        private void btnV_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8("");  //llamar el siguiente form
            form8.Show();  //mostrar siguiente interfaz
            this.Hide();   //se esconde una interfaz y aparece otra
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            //acceso al sql server
            SqlConnection connection = mConexion.getConexion();
            //establecer conexion c#
            connection.Open();  

            //preparar query
            string sql = "SELECT Descripcion, TipoPresentacion, Dosis FROM Medicamento WHERE Nombre = @NombreMed;";
            SqlCommand comando = new SqlCommand(sql, connection);

            // usar el valor del parámetro (nombre del medicamento pasado como 'b')
            comando.Parameters.AddWithValue("@NombreMed", txtB.Text);

            SqlDataReader reader = null;

            try
            {

                reader = comando.ExecuteReader();
                if (reader.HasRows)    //si hay filas en la bd entonces el lector lee el seleccionado
                {
                    while (reader.Read())
                    {
                       
                        txtDescrip.Text = reader.GetString(0); 
                        txtTipoM.Text = reader.GetString(1);
                        txtDosis.Text = reader.GetString(2);
                       
                    }
                }

            }
            catch (MySqlException ex)
            {

                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                reader.Close();
                connection.Close();
            }
        
        }

        private void btnA_Click(object sender, EventArgs e)   

        {
                    // obtener el valor del TextBox
                       string t = txtB.Text;

                    // abrir el formulario dependiendo del Modo
                    if (ModoAc.Modo == "Guardar")
                    {
                      
                         Form4 form4 = new Form4(t);
                        form4.Show();
                    }
                    else if (ModoAc.Modo == "Actualizar")
                    {
                         string l = txtNumero.Text;
                         Form6 form6 = new Form6(l, t);
                        form6.Show();
                    }

                    this.Hide(); // ocultar este
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtB_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

