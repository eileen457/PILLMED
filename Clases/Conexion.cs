using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
//using Microsoft.Data.SqlClient;
using System.Configuration;

namespace ver.Clases
{
    internal class Conexion
    {
        static string server= "EILEEN\\SQLEXPRESS"; 
        static string database = "pillmed";
        static string puerto ="1433";  
         string cadenaConexion;



        public Conexion()
        {
            // cadenaConexion = "Data Source" + server + "," + puerto + ";" + "Initial Catalog" + database + ";" +
            //     "Integrated Security=true";



               cadenaConexion = "Data Source=" + server + "," + puerto + ";" +
               "Initial Catalog=" + database + ";" +
               "Integrated Security=true;";  

            //   string databasePath = @"C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\pillmed.mdf"; // Cambia esta ruta al archivo .mdf real
            //  cadenaConexion = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + databasePath + ";Integrated Security=True;Connect Timeout=30;";  


        }

        public SqlConnection getConexion()  
{
SqlConnection conexion = null;
try
{

    //objeto
    conexion = new SqlConnection(cadenaConexion);
    conexion.Open();
    //  MySqlConnection conexion = new MySqlConnection(cadenaConexion);
   //  return conexion;

}
catch (SqlException ex)
{

    MessageBox.Show("Error: " + ex.Message);
    return null;
}
finally { conexion.Close(); }
return conexion;
}



}
}
