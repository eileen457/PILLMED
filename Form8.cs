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

    public partial class Form8 : Form
    {
        private Conexion mConexion; //objeto de clase conexion
                                    // Propiedad para saber qué formulario está activo


        public Form8(string numero)
        {
            InitializeComponent();
            mConexion = new Conexion();
            txtNumero.Text = numero;
        }

        private void btnV_Click(object sender, EventArgs e)
        {
            String k = "";
            Form4 form4 = new Form4(k);  //llamar el siguiente form
            form4.Show();  //mostrar siguiente interfaz
            this.Hide();   //se esconde una interfaz y aparece otra
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            // Verificar que haya una fila seleccionada en el DataGridView
            if (this.dataGridView1.CurrentRow != null)
            {
                // Obtener el índice de la fila seleccionada
                int filaSelec = this.dataGridView1.CurrentRow.Index;
                if (filaSelec >= 0) // Asegurarse de que el índice de la fila es válido
                {


                    // Obtener valores de la fila seleccionada 
                    string Medicamento = dataGridView1.Rows[filaSelec].Cells[0].Value.ToString();
                    string l = txtNumero.Text; //hereda numero con txt invisible para no perder el numero

                    Form9 form9 = new Form9(Medicamento,l);  //llamar el siguiente form6  
                    form9.Show();
                    this.Hide();
                    //mostrar interfaz para editar a traves de boton de la tabla dentro de ahi colocar boton descripcion

                }
            }

        }

        private void btnM_Click(object sender, EventArgs e)
        {
            // Suponiendo que tienes un TextBox donde el usuario ingresa la letra de búsqueda
            string busqueda = txtB.Text;  // Obtenemos la letra que el usuario ingresó

            // Asegurarte de que el valor contenga el comodín para buscar cualquier texto que comience con esa letra
            string letra = busqueda + "%";

            // Consulta SQL con parámetro
            string sql = "SELECT Nombre FROM Medicamento WHERE Nombre LIKE @busqueda";

            // String busqueda = txtB.Text;
            SqlDataReader reader = null;  //objeto lector de mysqldatareader para bd

            //comando para la bd
            //  string sql = "SELECT Nombre FROM Medicamento WHERE Nombre LIKE '" + busqueda + "'";
            SqlConnection connection = mConexion.getConexion();


            connection.Open();

            try
            {
                SqlCommand comando = new SqlCommand(sql, connection);
                comando.Parameters.AddWithValue("@busqueda", letra);
                reader = comando.ExecuteReader();


                if (reader.HasRows)    //si hay filas en la bd entonces el lector lee el seleccionado
                {
                    while (reader.Read())
                    {

                        // txtB.Text = reader.GetString(1); //obtiene el valor de numero entero de la bd 
                        dataGridView1.Rows.Add(reader["Nombre"]);

                    }
                }
                else
                {
                    MessageBox.Show("No se encontro este registro");

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
            


            // Verificar que haya una fila seleccionada en el DataGridView
            if (this.dataGridView1.CurrentRow != null)
            {
                // Obtener el índice de la fila seleccionada
                int filaSelec = this.dataGridView1.CurrentRow.Index;
                if (filaSelec >= 0) // Asegurarse de que el índice de la fila es válido
                {
                    // Obtener valores de la fila seleccionada 
                    string Medicamento = dataGridView1.Rows[filaSelec].Cells[0].Value.ToString();

                    // Obtener el valor del TextBox
                    //   string t = txtB.Text;

                    // Abrir el formulario dependiendo del Modo
                    if (ModoAc.Modo == "Guardar")
                    {
                       
                        Form4 form4 = new Form4(Medicamento);
                        form4.Show();
                    }
                    else if (ModoAc.Modo == "Actualizar")
                    {
                        string l = txtNumero.Text;
                        Form6 form6 = new Form6(l, Medicamento);
                        form6.Show();
                    }

                    this.Hide(); 

                }
            }

        }


        private void ActivoCuenta()
        {
            // Conexion a la base de datos
            SqlConnection connection = mConexion.getConexion();
            connection.Open();

            try
            {
                // Correo que se guardó al iniciar sesión
                string correo = DatosUsuario.CorreoUsuarioActual;

                // Query del campo Activo de la cuenta general
                string sql = "SELECT Activo FROM Cuenta WHERE Correo = '" + correo + "'";
                SqlCommand comando = new SqlCommand(sql, connection);

                // Ejecutar el comando y obtener el valor de "activo"
                object activoObj = comando.ExecuteScalar();
              

                // Verificar si se obtuvo un valor
                if (activoObj != null)
                {
                    int activo = Convert.ToInt32(activoObj);  //devuelve el valor del activo como int

                    // Bloquear o habilitar el botón de Descripción por valor de "activo"
                    if (activo == 0)
                    {
                        btnD.Enabled = false; 
                    }
                    else
                    {
                        btnD.Enabled = true; 
                    }
                }
                
            }
            catch (Exception ex)
            { MessageBox.Show("Error: " + ex.Message);}
            finally
            { connection.Close(); }
        }


        public static class ModoAc
        {
            public static string Modo { get; set; }
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            ActivoCuenta();
        }
    }
}
