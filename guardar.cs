using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Data.SqlClient;
using System.Text.Json;
using System.Runtime.Serialization.Formatters.Binary;

namespace ver
{
    [Serializable]
    internal class guardar
    {
        private string hora;
        private string min;
        private string ruta;
        private string nombre;
        private List<string> dias;
        private string nom;
        private string med;

        public string Hora { get => hora; set => hora = value; }
        public string Min { get => min; set => min = value; }

        public List<string> Dias { get => dias; set => dias = value; }
        public string Ruta { get => ruta; set => ruta = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        

        public string Nom { get => nom; set => nom = value; }

        public string Med { get => med; set => med = value; }
        public guardar(string hora, string min, List<string> dias, string ruta, string nombre,  string nom, string med)
        {
            this.Hora = hora;
            this.Min = min;
            this.Dias = dias;
            this.Ruta = ruta;
            this.Nombre = nombre;
            
            this.Nom = nom;
            this.Med = med;

           
        }

        public int guardarInt(string correo)
        {
            try
            {
                string path = Path.Combine(Application.StartupPath, "settings");

                // crear directorio si no existe
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string filePath = Path.Combine(path, $"{correo}.json");
                // string filePath = Path.Combine(path, "configuracion.json");

                // guardar en formato JSON
                var opciones = new JsonSerializerOptions { WriteIndented = true };
                string jsonData = JsonSerializer.Serialize(this, opciones);
                File.WriteAllText(filePath, jsonData);

               // MessageBox.Show("Configuración guardada correctamente.");
                return 0; // Éxito
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 1; // Error
            }
            //try
            //{

            //    string path = Path.Combine(Application.StartupPath, "settings");

            //    // Crear el directorio si no existe
            //    if (!Directory.Exists(path))
            //    {
            //        Directory.CreateDirectory(path);
            //    }

            //    using (SaveFileDialog dialog = new SaveFileDialog())
            //    {
            //        dialog.InitialDirectory = path;
            //        dialog.Filter = "Archivo Binario (*.bin)|*.bin";
            //        dialog.FileName = "configuracion.bin";

            //        if (dialog.ShowDialog() == DialogResult.OK)
            //        {
            //            using (Stream st = File.Open(dialog.FileName, FileMode.Create))
            //            {
            //                var binfor = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            //                binfor.Serialize(st, this);
            //                return 0; // Operación exitosa
            //            }
            //        }
            //    }

            //    // Si el usuario cancela el diálogo
            //    return 1;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    return 1;
            //}

        }


    
    }
}

