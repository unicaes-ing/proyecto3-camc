using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Views
{
    public partial class TablaGoleadores : Form
    {
        private ArchivosController archivos;
        private const string archivoEquipos = "equipos.bin";
        private const string archivoJugadores = "jugadores.bin";
        private List<Jugador> _jugadores;
        private List<Equipo> _equipos;

        public TablaGoleadores()
        {
            InitializeComponent();
            archivos = new ArchivosController();
        }

        private void TablaGoleadores_Load(object sender, EventArgs e)
        {
            _equipos = archivos.Deserializar<Equipo>(archivoEquipos);
            _jugadores = archivos.Deserializar<Jugador>(archivoJugadores);
            int i = 1;

            var query = (from j in _jugadores
                         join eq in _equipos on j.Equipo equals eq.Nombre
                         orderby j.Goles descending
                         select new { RK = i++, Jugador = j.Nombre, j.Goles, Posición = j.Posicion, j.Equipo });

            dataGridView1.DataSource = query.ToList();
        }
    }
}
