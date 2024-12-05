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
    public partial class Form7 : Form
    {
        private Conexion mConexion; //objeto de clase conexion
        public Form7()
        {
            InitializeComponent();
            mConexion = new Conexion();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          

        }

        private void Form7_Load(object sender, EventArgs e)
        {
            //acceso al sql server
            SqlConnection connection = mConexion.getConexion();
            //establecer conexion c#
            connection.Open();

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

            dataGridView1.Rows.Clear();

            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader["Numero"], reader["Foto"], reader["Nombre"], reader["Peso"], reader["Edad"], reader["Sexo"], reader["Tipo_sangre"]
                    , reader["Enfermedades"], reader["Alergias"], reader["Pastillas"], reader["Dosis"], reader["Medicamento"], reader["Dia"]);
            }

            connection.Close();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }
    }
}
