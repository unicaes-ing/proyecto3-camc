using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    [Serializable]
    public class Equipo
    {
        public string Nombre { get; set; }
        public List<string> Resultado { get; set; }
        public int PJ { get; set; }
        public int PG { get; set; }
        public int PE { get; set; }
        public int PP { get; set; }
        public int GF { get; set; }
        public int GC { get; set; }
        public int P { get; set; }
        public int CantJugadores { get; set; }
        //public int Posicion { get; set; }
        //public int CantidadJugadores { get; set; }
        //public int CantidadGoles { get; set; }
    }
}
