using MySql.Data.MySqlClient;
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
    public partial class Form6 : Form
    {
        private Conexion mConexion; //objeto de clase conexion

        public Form6(string numero, string be)
        {
            InitializeComponent();
            mConexion = new Conexion();

            txtNumero.Text = numero;  //conexion con form3 desde boton editar dentro de la tabla
            txtMed.Text = be;

            txtNumero.Enabled = false; //bloquea la casilla de numero de usuario 
        }
        private bool ContainsNum(string text)
        {
            return text.Any(char.IsDigit); //revisa en toda la cadena de texto si hay algun numero
        }

        private void Form6_Load(object sender, EventArgs e){}

        private void btnAct_Click(object sender, EventArgs e)
        {


            SqlConnection connection = mConexion.getConexion();
            connection.Open();
            try
            {
                if (pictureBox1.Image == null)
                {
                    MessageBox.Show("La imagen esta vacia. Por favor, agurege una imagen");
                    return;
                }
                //   MemoryStream ms = new MemoryStream();
                // pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);    
                //byte[] aByte = ms.ToArray();

            String numero = txtNumero.Text; //para conectar con el forms de la tabla       y actulizar solo datos de ese numero de usuario
            String usuario = txtNombre.Text;
            String peso = txtPeso.Text;
           // String edad = txtEdad.Text;
            String s = txtS.Text;
            String sangre = txtSangre.Text;
            String enfermedad = txtEnf.Text;
            String alergias = txtAle.Text;
          //  String pastillas = txtCant.Text;
            String med = txtMed.Text;
            String dia = txtDia.Text;

            int pastillas;
            int dosis;
            int edad;

                if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(peso)
               || string.IsNullOrEmpty(s) || string.IsNullOrEmpty(sangre) || string.IsNullOrEmpty(enfermedad)
               || string.IsNullOrEmpty(alergias) || string.IsNullOrEmpty(med) || string.IsNullOrEmpty(dia)
               || string.IsNullOrEmpty(txtCant.Text) || string.IsNullOrEmpty(txtEdad.Text) || string.IsNullOrEmpty(txtDosis.Text))
                {
                    MessageBox.Show("Ups! Al parecer tiene recuadros vacio por llenar");
                    return;
                }

                try
                {
                    pastillas = int.Parse(txtCant.Text);
                    edad = int.Parse(txtEdad.Text);
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
               // pastillas = int.Parse(txtCant.Text);

            if (pastillas < 5)
            {
                MessageBox.Show("Advertencia le quedan pocas pastillas");
               // return;
            }

                try
                {
                    dosis = int.Parse(txtDosis.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Error: Dosis tiene que ser numerico");
                    return;
                }


            //hereda de la clase donde se guarda el nombre del correo
            string correo = DatosUsuario.CorreoUsuarioActual;
            // reutilizar el correo que se guardó al iniciar sesión
            string sqlCorreo = "SELECT CuentaID FROM Cuenta WHERE Correo = '" + correo + "'";
            SqlCommand comandoCorreo = new SqlCommand(sqlCorreo, connection);

            object cuentaIdObj = comandoCorreo.ExecuteScalar();
            int cuentaId = (int)cuentaIdObj;


            // Convertir la imagen a un string 
          //  string imagen = BitConverter.ToString(aByte).Replace("-", "");

            // Actualización del registro, incluyendo la imagen como parámetro
            string sql =
            "UPDATE Usuarios SET Nombre = @nombre, Peso = @peso, Edad = @edad, Sexo = @sexo, " +
            "Tipo_sangre = @sangre, Enfermedades = @enfermedad, Alergias = @alergias, Medicamento = @medicamento, " +
            "Pastillas = @pastillas, Dosis=@dosis, Dia = @dia, Foto = @foto WHERE CuentaID = @cuentaId AND Numero = @numero";

            SqlCommand comando = new SqlCommand(sql, connection);

            // agregar parámetros 
            comando.Parameters.AddWithValue("@nombre", usuario);
            comando.Parameters.AddWithValue("@peso", peso);
            comando.Parameters.AddWithValue("@edad", edad);
            comando.Parameters.AddWithValue("@sexo", s);
            comando.Parameters.AddWithValue("@sangre", sangre);
            comando.Parameters.AddWithValue("@enfermedad", enfermedad);
            comando.Parameters.AddWithValue("@alergias", alergias);
            comando.Parameters.AddWithValue("@medicamento", med);
            comando.Parameters.AddWithValue("@pastillas", pastillas);
            comando.Parameters.AddWithValue("@dosis", dosis);
            comando.Parameters.AddWithValue("@dia", dia);
           // comando.Parameters.AddWithValue("@foto", aByte);  // pasamos los bytes de la imagen
            comando.Parameters.AddWithValue("@cuentaId", cuentaId);
            comando.Parameters.AddWithValue("@numero", numero);

            // verificar si hay una imagen seleccionada para actualizar
            if (pictureBox1.Image != null)
            {
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] aByte = ms.ToArray();
                comando.Parameters.AddWithValue("@foto", aByte); // Aquí pasamos los bytes de la imagen
                }
            else
            {
                comando.Parameters.AddWithValue("@foto", DBNull.Value); // Si no hay imagen
            }


           
                comando.ExecuteNonQuery();
            MessageBox.Show("Registro actualizado");
                

            }
            catch (SqlException ex)
            {

                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            Form3 form3 = new Form3();  //llamar el siguiente form
            form3.Show();  //mostrar siguiente interfaz
            this.Hide();   //se esconde una interfaz y aparece otra

        }

        private void btnFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog fo = new OpenFileDialog();
            fo.Filter = "archivos de imagen (*jpg; *png;) | *jpg; *png;";
            if (fo.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(fo.FileName); 
                            
            }
        }

   

        private void btnBuscmed_Click(object sender, EventArgs e)
        {
           

            Form8 form8 = new Form8(txtNumero.Text);  //llamar el siguiente form
            form8.Show();  //mostrar siguiente interfaz
            this.Hide();   //se esconde una interfaz y aparece otra

            ModoAc.Modo = "Actualizar"; //para saber que esta en la interfaz de actualizacion cuando busca medicamento
        }

        private void txtNumero_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
