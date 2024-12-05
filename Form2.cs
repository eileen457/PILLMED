using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections;
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
    public partial class Form2 : Form
    {
        private Conexion mConexion; //objeto de clase conexion
        public Form2()
        {
            InitializeComponent();
            mConexion = new Conexion();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String pago = cbPago.Text;
            String usu = txtU.Text;
            String tiempo=cbTiempo.Text;    
           
           // int id = Convert.ToInt32(0);

            SqlConnection connection = mConexion.getConexion();
            connection.Open();

            string getCuentaIdSql = "SELECT CuentaID FROM Cuenta WHERE Correo = @Correo";
            SqlCommand getCuentaIdCmd = new SqlCommand(getCuentaIdSql, connection);
            getCuentaIdCmd.Parameters.AddWithValue("@Correo", usu);

            object cuentaIdObj = getCuentaIdCmd.ExecuteScalar();
            int cuentaId = (int)cuentaIdObj;
            


            string sql= @"
                   INSERT INTO Suscripcion (Metodo_pago,Tiempo_pago, CuentaID)
                    VALUES (@pago,@tiempo, @CuentaID);

                      UPDATE Cuenta
                      SET Activo = 1
                      WHERE CuentaID = @CuentaID;";
      

            SqlCommand comando = new SqlCommand(sql, connection);
           
           // comando.Parameters.AddWithValue("@Correo", usu);
           
            comando.Parameters.AddWithValue("@pago", pago);
            comando.Parameters.AddWithValue("@tiempo", tiempo);
            comando.Parameters.AddWithValue("@CuentaID", cuentaId);
      
  
            try
            {
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro actualizado, ya esta suscrito");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            Form1 form1 = new Form1();  //llamar el siguiente form
            form1.Show();  //mostrar siguiente interfaz
            this.Hide();

        }

       
        }

}
