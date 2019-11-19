using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using WindowsFormsApp1.Models;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class ArchivosController
    {
        private BinaryFormatter formatter;

        public ArchivosController()
        {
            formatter = new BinaryFormatter();
        }

        public void Serializar<T>(string archivo, T model)
        {
            var lista = Deserializar<T>(archivo);

            if (lista == null)
            {
                lista = new List<T>();
            }

            FileStream file = new FileStream(archivo, FileMode.OpenOrCreate, FileAccess.Write);
            lista.Add(model);
            formatter.Serialize(file, lista);
            file.Close();
        }

        public void Serializar<T>(string archivo, List<T> lista)
        {
            FileStream file = new FileStream(archivo, FileMode.OpenOrCreate, FileAccess.Write);
            formatter.Serialize(file, lista);
            file.Close();
        }

        public List<T> Deserializar<T>(string archivo)
        {
            FileStream file = new FileStream(archivo, FileMode.OpenOrCreate, FileAccess.Read);

            try
            {
                object resp = formatter.Deserialize(file);
                return resp as List<T>;
            }
            catch (Exception)
            { 
                return null;
            }
            finally
            {
                file.Close();
            }
        }
    }
}
