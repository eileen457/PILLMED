using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ver.Clases;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
//using Microsoft.Data.SqlClient;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;
//using Microsoft.Data.SqlClient;
using System.Text.Json;
using System.Security.Cryptography;
using System.Timers;
using System.Reflection;
using System.Text.Json.Serialization;


namespace ver
{                                                     //ALARMA FUNCIONA
                                                  

    public partial class Form5 : Form
    {
        private Conexion mConexion; //objeto de clase conexion
        
        public Form5()
        {
            InitializeComponent();
            song.CreateControl();
            mConexion = new Conexion();
            txtDosis.Enabled = false;




            string correo = DatosUsuario.CorreoUsuarioActual;
          
            string fileName = $"{correo}.json";
            ; string path = Path.Combine(Application.StartupPath, "settings", fileName);
            //  string path = Path.Combine(Application.StartupPath, "settings", "configuracion.json");
            if (!File.Exists(path))
            {
                //crea configuración predeterminada si el archivo no existe
                guardar datosPredeterminados = new guardar("", "", new List<string> { "" }, "", "", "","");

                        datosPredeterminados.guardarInt(correo); // Guardar los datos predeterminados
                        MessageBox.Show("Archivo de configuración creado con valores predeterminados.");
            }
            else
            {

            cargar(path,correo);
            }

             //  ruta de musica predeterminada    el nombre deberia cambiar tambien entonces al guardarse
                 ruta = "C:\\Users\\eilee\\Downloads\\bedside-clock-alarm-95792.mp3";
        }



        AxWMPLib.AxWindowsMediaPlayer song = new AxWMPLib.AxWindowsMediaPlayer();
        string ruta = string.Empty;
        string archivo = string.Empty;
        List<string> dias = new List<string>();


       
        /* int hour, minute, second;
         string alarmHour, alarmMinute; 

         private void btnReloj_Click(object sender, EventArgs e)
         {
             String nom = txtNombre.Text;

             if (string.IsNullOrEmpty(nom))
             {
                 MessageBox.Show("Por favor, ingrese un usuario");
                 return;
             }

             alarmHour = comboBox1.Text;
             alarmMinute = comboBox2.Text;
             MessageBox.Show("Ya se establecio la alarma");
             //clic start para establecer alarma
             button1_Click(sender, e);

         }*/



       

        private void txtNombre_TextChanged(object sender, EventArgs e){ }

        private void button1_Click(object sender, EventArgs e)
        {

            String nom = txtNombre.Text;


            SqlConnection connection = mConexion.getConexion();
            connection.Open();

            //hereda de la clase donde se guarda el nombre del correo
            string correo = DatosUsuario.CorreoUsuarioActual;
            // Reutilizar el correo que se guardó al iniciar sesión
            string sqlCorreo = "SELECT CuentaID FROM Cuenta WHERE Correo = '" + correo + "'";
            SqlCommand comandoCorreo = new SqlCommand(sqlCorreo, connection);

            object cuentaIdObj = comandoCorreo.ExecuteScalar();
            int cuentaId = (int)cuentaIdObj; //devuelve el ID como un entero paa evitar errores


            string sql =
           "SELECT Nombre, Pastillas FROM Usuarios WHERE CuentaID = @cuentaId AND Nombre = @nombre";   



            SqlDataReader reader = null;

            try
            {

                SqlCommand comando = new SqlCommand(sql, connection);

                comando.Parameters.AddWithValue("@nombre", nom);
                comando.Parameters.AddWithValue("@cuentaId", cuentaId);

                reader = comando.ExecuteReader();

                if (reader.HasRows)    //si hay filas en la bd entonces el lector lee el seleccionado
                {
                    while (reader.Read())
                    {
                        txtNombre.Text = reader.GetString(0);
                        txtDosis.Text = reader.GetInt32(1).ToString();

                    }
                }
                else { txtNombre.Text = string.Empty; txtDosis.Text = string.Empty; }
                //else
                //{ MessageBox.Show("No se encontro este nombre"); }

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
            finally
            {
                reader.Close();   //cerrar lector
                connection.Close();
            }

            int dosis;
            if (int.TryParse(txtDosis.Text, out dosis)) {
                if (dosis < 5) {
                    MessageBox.Show("Advertencia le quedan pocas pastillas");
                }
            }
        }

        private void btnMusica_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                archivo = ofd.SafeFileName;
                ruta = ofd.FileName;
                song.URL = ruta;
                song.settings.setMode("loop", true);
                song.Ctlcontrols.stop();

            }
            guardarConfiguracion();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }

        int hour, minute, second;
        string alarmHour, alarmMinute;   //ya no se usa porque se compara con lo guardado en el json
        private void btnReloj_Click(object sender, EventArgs e)
        {

            String nom = txtNombre.Text;
            SqlConnection connection = mConexion.getConexion();
            connection.Open();

            //hereda de la clase donde se guarda el nombre del correo
            string correo = DatosUsuario.CorreoUsuarioActual;
            // Reutilizar el correo que se guardó al iniciar sesión
            string sqlCorreo = "SELECT CuentaID FROM Cuenta WHERE Correo = '" + correo + "'";
            SqlCommand comandoCorreo = new SqlCommand(sqlCorreo, connection);

            object cuentaIdObj = comandoCorreo.ExecuteScalar();
            int cuentaId = (int)cuentaIdObj; //devuelve el ID como un entero paa evitar errores


            string sql =
           "SELECT Nombre, Pastillas FROM Usuarios WHERE CuentaID = @cuentaId AND Nombre = @nombre";

            if (string.IsNullOrEmpty(nom))
            {
                MessageBox.Show("Por favor, ingrese un usuario");
                return;
            }

            SqlDataReader reader = null;
            try
            {
                SqlCommand comando = new SqlCommand(sql, connection);
                comando.Parameters.AddWithValue("@nombre", nom);
                comando.Parameters.AddWithValue("@cuentaId", cuentaId);

                reader = comando.ExecuteReader();
                if (reader.HasRows) // Si hay filas en la BD entonces el lector lee el seleccionado 
                {
                    while (reader.Read())
                    {
                        txtNombre.Text = reader.GetString(0);
                        txtDosis.Text = reader.GetInt32(1).ToString();
                    }
                }
                else { MessageBox.Show("No se encontró este nombre"); return; }
            }
            catch (SqlException ex) { MessageBox.Show("Error" + ex.Message); }
            finally
            {
                reader.Close(); // Cerrar lector
                connection.Close();
            }

            alarmHour = comboBox1.Text;
            alarmMinute = comboBox2.Text;
            MessageBox.Show("Ya se establecio la alarma");
           
            //clic start para establecer alarma
            button1_Click(sender, e);

        }



        void Ring_Alarm()
        {


            string dia = Application.CurrentCulture.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek).ToLower();
            string hora = DateTime.Now.Hour.ToString("00");
            string minutos = DateTime.Now.Minute.ToString("00");



            foreach (Control c in this.Controls)
            {

                if (c is CheckBox cb && cb.Checked)
                {
                   
                        if (dia == cb.Text.ToLower() && hora == comboBox1.Text && minutos == comboBox2.Text)
                        {
                        try { 
                            if (!string.IsNullOrEmpty(song.URL))
                            {
                                song.Ctlcontrols.play();

                            }
                            else
                            {

                                axWindowsMediaPlayer1.URL = "C:\\Users\\eilee\\Downloads\\bedside-clock-alarm-95792.mp3";
                                axWindowsMediaPlayer1.Ctlcontrols.play();
                            }
                            return;
                        }
                    catch (Exception ex)
                           {
                              MessageBox.Show("Error: " + ex.Message);
                           }
                        }
                    //else
                    //{
                    //    MessageBox.Show("Alarma no funciona");
                    //}


                }
               
            }


            /* foreach (Control c in this.Controls)
             {
                 if (c is CheckBox)
                 {


                     if (dia == c.Text.ToLower().ToString() && alarmHour == label11.Text && alarmMinute == label12.Text && second.ToString() == "0")
                     {
                         axWindowsMediaPlayer1.Ctlcontrols.play();

                         //axWindowsMediaPlayer1.URL = "C:\\Users\\eilee\\Downloads\\alarma-morning-mix.mp3";

                         //  song.Ctlcontrols.play();
                     }
                     else { song.Ctlcontrols.play(); }

                 }
              }*/
            }





            private void Form5_Load(object sender, EventArgs e)  //carga el formulario
        {
            

            axWindowsMediaPlayer1.URL = "C:\\Users\\eilee\\Downloads\\bedside-clock-alarm-95792.mp3";
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            song.Ctlcontrols.stop();

            //axWindowsMediaPlayer1.URL = "C:\\Users\\eilee\\Downloads\\bedside-clock-alarm-95792.mp3";
            // "C:\\Users\\eilee\\Downloads\\alarma-morning-mix.mp3";


            SetupTimer();

            //timer1.Start();
            for (int i = 0; i < 24; i++)
            {
                comboBox1.Items.Add(i.ToString("00"));
            }

            for (int j = 0; j < 60; j++)
            {
                comboBox2.Items.Add(j.ToString("00"));
            }

            ActivoCuenta();
          

            //  btnLeer_Click(sender, e);   
            /*string filePath = Path.Combine(Application.StartupPath, @"settings\datos.txt");
               try
               {
                   if (File.Exists(filePath))
                   {
                       //  string filePath = Path.Combine(Application.StartupPath, @"settings\datos.txt");
                       cargar(filePath);
                   }
                   else { MessageBox.Show("El archivo que esta buscando no existe"); return; 
                   }
               }
               catch (Exception ex)
               {
                   MessageBox.Show("Error al cargar el archivo: " + ex.Message);
               }*/
            button1_Click(sender, e);         
        }

        private void timer1_Tick(object sender, EventArgs e)     //hace que el reloj sea igual a la hora real 
        {
            second = DateTime.Now.Second;
            minute = DateTime.Now.Minute;
            hour = DateTime.Now.Hour;

            label11.Text = hour.ToString("00");
            label12.Text = minute.ToString("00");
            label13.Text = second.ToString("00");
            Ring_Alarm();


        }
        private void SetupTimer()
        {
            timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 1000; // 1,000 ms = 1 segundo
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
        }
        //private void Ring_Alarm()  //si detecta el dia actual hora y minutso
        //{                           //si sabe los das guardados
        //    try
        //    {
        //        string correo = DatosUsuario.CorreoUsuarioActual;
        //        string fileName = $"{correo}.json";
        //        string path = Path.Combine(Application.StartupPath, "settings", fileName);

        //        if (File.Exists(path))
        //        {

        //            string jsonContent = File.ReadAllText(path);
        //            guardar g = JsonSerializer.Deserialize<guardar>(jsonContent);


        //            string dia = Application.CurrentCulture.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek).ToLower();
        //            string hora = DateTime.Now.Hour.ToString("00");
        //            string minutos = DateTime.Now.Minute.ToString("00");


        //            if (g.Hora == hora && g.Min == minutos && g.Dias.Contains(dia))
        //            {
        //                Console.WriteLine("Condiciones de tiempo coinciden. Reproduciendo canción...");
        //                MessageBox.Show("Condiciones de tiempo coinciden. Reproduciendo canción...", "Depuración");

        //                if (!string.IsNullOrEmpty(g.Ruta))
        //                {
        //                    song.URL = g.Ruta;
        //                    song.Ctlcontrols.play();
        //                }
        //                else
        //                {
        //                    axWindowsMediaPlayer1.URL = "C:\\Users\\eilee\\Downloads\\bedside-clock-alarm-95792.mp3";
        //                    axWindowsMediaPlayer1.Ctlcontrols.play();
        //                }
        //            }
        //            else
        //            {
        //                Console.WriteLine("Las condiciones de tiempo no coinciden.");
        //                MessageBox.Show("Las condiciones de tiempo no coinciden.", "Depuración");
        //            }
        //        }
        //        else
        //        {
        //            Console.WriteLine("El archivo de configuración no existe.");
        //            MessageBox.Show("El archivo de configuración no existe.", "Depuración");
        //        }
        //    }
        //    catch
        //        (SerializationException ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        return;

        //    }
        //}
        private void cbLun_CheckedChanged(object sender, EventArgs e){ }

        private void ActivoCuenta()
        {
            // conexion a la base de datos
            SqlConnection connection = mConexion.getConexion();
            connection.Open();

            try
            {
                // correo que se guardó al iniciar sesión
                string correo = DatosUsuario.CorreoUsuarioActual;

                // campo Activo de la cuenta general
                string sql = "SELECT Activo FROM Cuenta WHERE Correo = '" + correo + "'";
                SqlCommand comando = new SqlCommand(sql, connection);

                // ejecutar el comando y obtener el valor de "activo"
                object activoObj = comando.ExecuteScalar();


                // verificar si se obtuvo un valor
                if (activoObj != null)
                {
                    int activo = Convert.ToInt32(activoObj);  //devuelve el valor del activo como int

                    // bloquear o habilitar el botón de Descripción por valor de "activo"
                    if (activo == 0)
                    {
                        btnMusica.Enabled = false;
                    }
                    else
                    {
                        btnMusica.Enabled = true;
                    }
                }

            }
            catch (Exception ex)
            { MessageBox.Show("Error: " + ex.Message); }
            finally
            { connection.Close(); }
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            StreamWriter A = new StreamWriter(Application.StartupPath + "\\settings\\" + "datos.txt");
              // A.WriteLine(label1.Text +" "+ txtNombre.Text);
              A.WriteLine( txtNombre.Text);
              // A.WriteLine(label2.Text +" "+ txtDosis.Text);
              A.WriteLine(txtDosis.Text);
              A.Close();

            
             string filePath = Path.Combine(Application.StartupPath, "settings", "datos.txt");
             // Información a guardar en el archivo
             string contenido = $"{txtNombre.Text}\n{txtDosis.Text}";

             try
             {
                 // Sobrescribir el archivo cada vez que se presione el botón
                 File.WriteAllText(filePath, contenido);

                 MessageBox.Show("La información se ha guardado correctamente.");
             }
             catch (Exception ex)
             {
                MessageBox.Show("Error al guardar informacion: " + ex.Message);
                // MessageBox.Show($"Error al guardar la información: {ex.Message}");
            }

            
        }



        private void btnLeer_Click(object sender, EventArgs e)
        {

            /* string textFile = @"C:\settings\datos.txt";

             if (File.Exists(textFile))
             {

                 /* string[] line = File.ReadAllLines(textFile);
                  foreach (string l in line)
                  {
                      if (l.Contains("Nombre"))
                      {
                          txtNombre.Text = l;
                      }
                      else
                      {
                          txtDosis.Text = l;
                      }
                  }
                 string[] lines = File.ReadAllLines(textFile);
                 txtNombre.Text = lines[0];
                 txtDosis.Text = lines[1];
             } */

        }


        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {

             dias.Clear();
              foreach (Control c in this.Controls)
              {
                  if (c is CheckBox)
                  {
                      CheckBox cb = (CheckBox)c;
                      if (cb.Checked)
                      {
                          dias.Add(cb.Text);
                      }
                  }
              }
            guardarConfiguracion();

            /*    guardar g = new guardar(comboBox1.Text, comboBox2.Text, ruta, archivo, dias);
                int res = g.guardarInt();   //HAY QUE DARLE EN LA X PARA CERRAR EL RELOJ Y AHI ES CUANDO GUARDA
              if (res == 0)
              {
                  MessageBox.Show("Datos guardados exitosamente.");
              }
              else
              {
                  MessageBox.Show("Error al guardar los datos.");
              }
            */
            //  btnguardar_Click(sender, e);  se puso aca porque tiene la ruta para guardar


        }
        private void guardarConfiguracion()
        {
            
            string correo = DatosUsuario.CorreoUsuarioActual; 
            string fileName = $"{correo}.json"; 
            string path = Path.Combine(Application.StartupPath, "settings", fileName);
              //  string path = Path.Combine(Application.StartupPath, "settings", "configuracion.json");

            // Si no se ha seleccionado una canción personalizada, guardar la ruta como vacía
            string rutaGuardar = string.IsNullOrEmpty(ruta) ? string.Empty : ruta;

          
            guardar datos = new guardar(comboBox1.Text, comboBox2.Text, dias, rutaGuardar, archivo,  txtNombre.Text, txtDosis.Text);
          
            string json = JsonSerializer.Serialize(datos); 
            File.WriteAllText(path, json);  //revisar que hace esto
            int res = datos.guardarInt(correo);
            if (res == 0)
            {
                MessageBox.Show("Datos guardados exitosamente.");
            }
            else
            {
                MessageBox.Show("Error al guardar los datos.");
            }
        }




        /*public void cargar(string filepath)
            {
            string path = Application.StartupPath + @"\settings";


            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            try
            {
                var binfor = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                guardar g = (guardar)binfor.Deserialize(fs);

                comboBox1.Text = g.Hora;
                comboBox2.Text = g.Min;
                ruta = g.Ruta;
                archivo = g.Nombre;
                dias = g.Dias;

                foreach (Control c in this.Controls)
                {
                    if (c is CheckBox)  // Verifica que el control sea un CheckBox
                    {
                        CheckBox cb = (CheckBox)c;
                        if (dias.Count > 0)
                        {
                            for (int i = 0; i < dias.Count; i++)
                            {
                                if (c.Text == dias[i])
                                {
                                    ((CheckBox)c).Checked = true;
                                }
                            }
                        }
                    }
                }
                song.URL = ruta;

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            fs.Close();
        }*/

        public void cargar(string filePath, string correo)
        {

            try
            {               
                    // Código para leer los datos del archivo
                    string[] lines = File.ReadAllLines(filePath);
                    for (int i = 0; i < lines.Length; i++)
                    {
                        txtNombre.Text = lines[0];
                        txtDosis.Text = lines[1];
                    }

                //using (Stream st = File.Open(filePath, FileMode.Open))
                //{

                //    var binfor = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                //    guardar g = (guardar)binfor.Deserialize(st);


                // Leer el archivo JSON
                //string jsonContent = File.ReadAllText(filePath);
                //guardar g = JsonSerializer.Deserialize<guardar>(jsonContent);
             

                string fileName = $"{correo}.json"; 
                string path = Path.Combine(Application.StartupPath, "settings", fileName);

                string jsonContent = File.ReadAllText(filePath);
                if (jsonContent.TrimStart().StartsWith("{"))
                {
                    if (File.Exists(path))
                    {
                        guardar g = JsonSerializer.Deserialize<guardar>(jsonContent);
                        comboBox1.Text = g.Hora;
                        comboBox2.Text = g.Min;
                        ruta = g.Ruta;
                        archivo = g.Nombre;
                        dias = g.Dias;
                        txtNombre.Text = g.Nom;
                        txtDosis.Text = g.Med;

                        //// Configurar la ruta del reproductor
                        if (!string.IsNullOrEmpty(g.Ruta))
                        {
                            song.URL = g.Ruta;
                        }
                        foreach (Control c in this.Controls)
                        {
                            if (c is CheckBox cb)
                            {
                                if (dias.Count > 0)
                                {
                                    for (int i = 0; i < dias.Count; i++)
                                    {
                                        if (c.Text == dias[i])
                                        {
                                            ((CheckBox)c).Checked = true;

                                        }
                                    }
                                }
                            }

                        }

                    }
                   

                }
                else { MessageBox.Show("No se encontró la configuración para esta cuenta. Se creará una nueva configuración."); 
                    guardarConfiguracion(); 
                }
                //else
                //{
                //    MessageBox.Show("El archivo no contiene un JSON válido.");
                //}

                //comboBox1.Text = g.Hora;
                //    comboBox2.Text = g.Min;
                //    ruta = g.Ruta;
                //    archivo = g.Nombre;
                //    dias = g.Dias;

                //foreach (Control c in this.Controls)
                //{
                //    if (c is CheckBox cb)
                //    {
                //        if (dias.Count > 0)
                //        {
                //            for (int i = 0; i < dias.Count; i++)
                //            {
                //                if (c.Text == dias[i])
                //                {
                //                    ((CheckBox)c).Checked = true;

                //                }
                //            }
                //        }
                //    }

                //}

                //// Configurar la ruta del reproductor
                //if (!string.IsNullOrEmpty(g.Ruta))
                //{
                //    song.URL = g.Ruta;

                //}

                //}

            }
            catch (SerializationException ex)
            {
                MessageBox.Show(ex.Message);
                 return;
            }
            // st.Close();           
        }



        private void cbSL_CheckedChanged(object sender, EventArgs e)
            {
                foreach (Control c in this.Controls)
                {
                    if (c is CheckBox)
                    {
                        if (cbSL.Checked)
                            ((CheckBox)c).Checked = true;
                        else ((CheckBox)c).Checked = false;
                    }
                }


            }


        private void btnStop_Click(object sender, EventArgs e)
        {


            String nom = txtNombre.Text;
            String dosisp = txtDosis.Text;

            SqlConnection connection = mConexion.getConexion();
            connection.Open();

            //hereda de la clase donde se guarda el nombre del correo
            string correo = DatosUsuario.CorreoUsuarioActual;
            // reutilizar el correo que se guardó al iniciar sesión
            string sqlCorreo = "SELECT CuentaID FROM Cuenta WHERE Correo = '" + correo + "'";
            SqlCommand comandoCorreo = new SqlCommand(sqlCorreo, connection);

            object cuentaIdObj = comandoCorreo.ExecuteScalar();
            int cuentaId = (int)cuentaIdObj; //devuelve el ID como un entero paa evitar errores


            string query = "SP_RestarPastilla";

            SqlCommand comando = new SqlCommand(query, connection);
            comando.CommandType = CommandType.StoredProcedure;


            comando.Parameters.Add("@pastillas", SqlDbType.Int);
            comando.Parameters.Add("@nombre", SqlDbType.NVarChar, 100);
            comando.Parameters.Add("@cuentaId", SqlDbType.Int);

            comando.Parameters["@pastillas"].Value = dosisp;
            comando.Parameters["@nombre"].Value = nom;
            comando.Parameters["@cuentaId"].Value = cuentaId;
            SqlDataReader sqlDataReader = comando.ExecuteReader();


            connection.Close();

            Console.ReadLine();

            button1_Click(sender, e);

            timer1.Enabled = false;

            // Detener el sonido en ambos 
            if (axWindowsMediaPlayer1 != null)
            {
                axWindowsMediaPlayer1.Ctlcontrols.stop();
            }
            if (song != null)
            {
                song.Ctlcontrols.stop();
            }
        }




    }

}

