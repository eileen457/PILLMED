using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ver.Clases;
using static ver.Form8;
//using Microsoft.Data.SqlClient;

namespace ver
{
    public partial class Form4 : Form
    {
        private Conexion mConexion; //objeto de clase conexion
        public Form4(string be)
        {
            InitializeComponent();
            mConexion = new Conexion();
            txtMed.Text = be;
          
        }
        /*   private bool RegistroEsta(SqlConnection connection, string numero) //private no todos lo pueden usar     conectado a la base de datos busca en fila codigo
           {

               string query = "SELECT COUNT(*) FROM Usuarios WHERE Numero='" + numero + "'";
               SqlCommand cmd = new SqlCommand(query, connection);  //objeto utiliza conexion y comando en bd
               int count = Convert.ToInt32(cmd.ExecuteScalar()); //execute devuelve en numeros lo que el objeto cmd encuentre
               return count > 6; 

           }*/
        //verificar si un string contiene algún número
        private bool ContainsNum(string text)
        {
            return text.Any(char.IsDigit); //revisa en toda la cadena de texto si hay algun numero
        }                                  //si hay numero devuelve true
        private void btnCambios_Click(object sender, EventArgs e)
        {
            String Dosis=txtDosis.Text;   //NUEVO PARA dosis

            MemoryStream ms=new MemoryStream();
            pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] aByte = ms.ToArray();

            
          String numero = txtNumero.Text;
            String usuario = txtNombre.Text;
            String peso=txtPeso.Text;   
                                                // String edad=txtEdad.Text;
            String s=txtS.Text; 
            String sangre=txtSangre.Text;   
            String enfermedad=txtEnf.Text;
            String alergias = txtAle.Text;
                                                // String pastillas = txtCant.Text;
           String be = txtMed.Text;   // asignado en la biblioteca de medicinas
            String dia=txtDia.Text;
            int pastillas;
            int dosis;
            int edad;
            try
            {
               pastillas = int.Parse(txtCant.Text);
               edad=int.Parse(txtEdad.Text);
                dosis = int.Parse(txtDosis.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Error: Pastillas, edad y dosis tiene que ser numerico");
                return;
            }

            if (ContainsNum(s) || ContainsNum(alergias) || ContainsNum(dia))
            {
                MessageBox.Show("Ups! Al parecer tiene un error en genero, alergias o dia");
                return;
                //si hay un numero en la cadena, sale este mensaje
            }

            if (pastillas < 5)
            {
                MessageBox.Show("Advertencia le quedan pocas pastillas");
                // return;
            }

            SqlConnection connection = mConexion.getConexion();
            connection.Open();

            if (int.Parse(txtNumero.Text) > 5)
            {
                MessageBox.Show("Solo puede agregar 5 usuarios");
                return;
            }
            else
            {
              
 
                //hereda de la clase donde se guarda el nombre del correo
                string correo = DatosUsuario.CorreoUsuarioActual;
                // reutiliza el correo que se guardó al iniciar sesión
                string sqlCorreo = "SELECT CuentaID FROM Cuenta WHERE Correo = '" + correo + "'";
                SqlCommand comandoCorreo = new SqlCommand(sqlCorreo, connection);

                object cuentaIdObj = comandoCorreo.ExecuteScalar();
                int cuentaId = (int)cuentaIdObj; //devuelve el ID como un entero paa evitar errores


                // Convertir la imagen a un string hexadecimal para incluirla en la consulta
                string imagen = BitConverter.ToString(aByte).Replace("-", "");

                string sql = "INSERT INTO Usuarios ( Numero, Nombre, Peso, Edad, Sexo, Tipo_sangre, Enfermedades, Alergias, Pastillas, Dosis, Medicamento, Dia, Foto, CuentaID) VALUES" +
                " ('" + numero + "','" + usuario + "','" + peso + "', '" + edad + "', '" + s + "', '" + sangre + "', '" + enfermedad + "', '" + alergias + "','" + pastillas + "','" + dosis +"','" + be + "' , '" + dia + "',  0x" + imagen + "," + cuentaId + ") ;"; 

                
                try
                {

                    SqlCommand comando = new SqlCommand(sql, connection);
                    comando.ExecuteNonQuery();

                     //  comando.Parameters.AddWithValue("@hola", txtMed.Text);
          

                    MessageBox.Show("Registro guardado");


                }
                catch (SqlException ex)
                {

                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }

            Form3 form3 = new Form3();  //llamar el siguiente form
            form3.Show();  //mostrar siguiente interfaz
            this.Hide();   //se esconde una interfaz y aparece otra


        }

     
        private void btnFoto_Click(object sender, EventArgs e)
        {

            OpenFileDialog file= new OpenFileDialog();
            file.Filter = "archivos de imagen (*jpg; *png;) | *jpg; *png;";
            if(file.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image=Image.FromFile(file.FileName);
            }
        }

        private void label10_Click(object sender, EventArgs e)
        { }

        private void pictureBox1_Click(object sender, EventArgs e)
        { }

        private void txtCant_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscmed_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8(txtNumero.Text);  //recibe el numero para no perderlo
            form8.Show();  //mostrar siguiente interfaz
            this.Hide();   //se esconde una interfaz y aparece otra
            ModoAc.Modo = "Guardar";   //para identificar que esta en el forms de guardar cuando agrega medicamento

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
