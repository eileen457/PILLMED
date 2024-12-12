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
                                    // propiedad para saber qué formulario está activo


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
            // verificar que haya una fila seleccionada en el DataGridView
            if (this.dataGridView1.CurrentRow != null)
            {
                // bbtiene el índice de la fila seleccionada
                int filaSelec = this.dataGridView1.CurrentRow.Index;
                if (filaSelec >= 0) // asegura que el índice de la fila es válido
                {


                    // obtener valores de la fila seleccionada 
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
           
            string busqueda = txtB.Text;  // obtenemos la letra que el usuario ingresó

            // comodín para buscar cualquier texto que comience con esa letra
            string letra = busqueda + "%";

            // consulta sql con parámetro
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
            


            // verificar que haya una fila seleccionada en el DataGridView
            if (this.dataGridView1.CurrentRow != null)
            {
                // obtener el índice de la fila seleccionada
                int filaSelec = this.dataGridView1.CurrentRow.Index;
                if (filaSelec >= 0) // asegurarse de que el índice de la fila es válido
                {
                    // obtiene valores de la fila seleccionada 
                    string Medicamento = dataGridView1.Rows[filaSelec].Cells[0].Value.ToString();

                    // bbtener el valor del TextBox
                    //   string t = txtB.Text;

                    // abrir el formulario dependiendo del Modo
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
            // conexion a la base de datos
            SqlConnection connection = mConexion.getConexion();
            connection.Open();

            try
            {
                // correo que se guardó al iniciar sesión
                string correo = DatosUsuario.CorreoUsuarioActual;

                // query del campo Activo de la cuenta general
                string sql = "SELECT Activo FROM Cuenta WHERE Correo = '" + correo + "'";
                SqlCommand comando = new SqlCommand(sql, connection);

                // ejecutar el comando y obtener el valor de "activo"
                object activoObj = comando.ExecuteScalar();
              

                // verificar si se obtuvo un valor
                if (activoObj != null)
                {
                    int activo = Convert.ToInt32(activoObj);  //devuelve el valor del activo como int

                    // bloquear o habilitar el botón de descripción por valor de "activo"
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
