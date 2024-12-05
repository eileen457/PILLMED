using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ver.Clases;
//using Microsoft.Data.SqlClient;

namespace ver
{
    public partial class Form3 : Form
    {
        private Conexion mConexion; //objeto de clase conexion
        public Form3()
        {
            InitializeComponent();
            mConexion = new Conexion();
        }

       
        private void btnCrear_Click(object sender, EventArgs e)
        {

            SqlConnection connection = mConexion.getConexion();
            connection.Open();


            String c="";   
                Form4 form4 = new Form4(c);  //llamar el siguiente form
                form4.Show();  //mostrar siguiente interfaz
                this.Hide();   //se esconde una interfaz y aparece otra

          

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection connection = mConexion.getConexion();
            connection.Open();

            //boton editar
            if (e.ColumnIndex == 3 && e.RowIndex > -1)
            {                    //accede a la fila elegida        //obtiene el valor de la primera fila 0                   
                string valor = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

                Form6 form6 = new Form6(valor, "");  
                form6.Show();
                this.Hide();
               
            }
            else if (e.ColumnIndex == 4 && e.RowIndex > -1) {  //boton eliminar
                string v = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();


                DialogResult opcion1 = MessageBox.Show("¿Desea eliminar este registro?", "Advertencia de actualizacion", MessageBoxButtons.YesNo);
                if (opcion1 == DialogResult.Yes)
                {
                    try
                    {

                        //hereda de la clase donde esta el nombre de la cuenta
                        string correo = DatosUsuario.CorreoUsuarioActual;
                        // Reutilizar la cuenta que se guardó al iniciar sesión
                        string sqlCorreo = "SELECT CuentaID FROM Cuenta WHERE Correo = '" + correo + "'";
                        SqlCommand comandoCorreo = new SqlCommand(sqlCorreo, connection);

            //flexible a cualquier tipo de dato              //devuelve valor unico tipo objeto
                        object cuentaIdObj = comandoCorreo.ExecuteScalar();   //si sabe en que cuenta estoy
                        int cuentaId = (int)cuentaIdObj;

                        string sql = "DELETE FROM Usuarios WHERE Numero = @numero AND CuentaID = @cuentaId";
                        SqlCommand comando = new SqlCommand(sql, connection);
                   

                        comando.Parameters.AddWithValue("@Numero", v); 
                        comando.Parameters.AddWithValue("@cuentaId", cuentaId);


                        // Ejecutamos la consulta
                        int filasAfectadas = comando.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            
                            MessageBox.Show("Se eliminó de forma exitosa");
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el usuario a eliminar.");
                        }
                      //  MessageBox.Show("Se elimino de forma exitosa");
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Ocurrió un error al eliminar el usuario: " + ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }

                }
                else if (opcion1 == DialogResult.No)
                {
                    MessageBox.Show("Eliminar cancelado");
                }
                
            }
        }

        private void button1_Click(object sender, EventArgs e)   //PUEDO PONERLO DIRECTAMENTE EN LA INTERFAZ SI QUIERO Y NO UTILIZAR UN BOTON PARA MOSTRAR 
        {
            //acceso al sql server
            SqlConnection connection = mConexion.getConexion();
            //establecer conexion c#
            connection.Open();

            try
            {
               
                    //hereda de la clase donde se guarda el nombre del correo
                    string correo = DatosUsuario.CorreoUsuarioActual;
                    // Reutilizar el correo que se guardó al iniciar sesión
                    string sqlCorreo = "SELECT CuentaID FROM Cuenta WHERE Correo = '" + correo + "'";
                    SqlCommand comandoCorreo = new SqlCommand(sqlCorreo, connection);
                    object cuentaIdObj = comandoCorreo.ExecuteScalar();
                    int cuentaId = (int)cuentaIdObj;

           

                    //preparar query
                    string sql = "SELECT*FROM Usuarios WHERE CuentaID = '" + cuentaId + "'";
                    SqlCommand comando = new SqlCommand(sql, connection);

                var reader = comando.ExecuteReader();

                if (reader.HasRows) { 
                 //   var reader = comando.ExecuteReader();

                    dataGridView1.Rows.Clear();

                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(reader["Numero"], reader["Foto"], reader["Nombre"], "Editar", "Eliminar");
                    }

                }else{
                    MessageBox.Show("No hay usuarios, por favor agregue usuarios" );
                }

                reader.Close();
            }
            catch (SqlException ex) {
                MessageBox.Show("Error"+ex.Message); 
            }
            finally 
            {
               
                connection.Close(); 
            }

        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7(); 
            form7.Show();
            this.Hide();
        }
    }
}
