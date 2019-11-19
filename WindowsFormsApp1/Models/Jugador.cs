using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    [Serializable]
    public class Jugador
    {
        public string Nombre { get; set; }
        public string Posicion { get; set; }
        public int Goles { get; set; }
        public string Equipo { get; set; }
    }
}
