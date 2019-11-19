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
    public partial class MostrarLigaForm : Form
    {
        private ArchivosController archivos;
        private const string archivoEquipos = "equipos.bin";
        private const string archivoJugadores = "jugadores.bin";
        private List<Jugador> _jugadores;
        private List<Equipo> _equipos;

        public MostrarLigaForm()
        {
            InitializeComponent();
            archivos = new ArchivosController();
        }

        private void MostrarLigaForm_Load(object sender, EventArgs e)
        {
            _equipos = archivos.Deserializar<Equipo>(archivoEquipos);
            _jugadores = archivos.Deserializar<Jugador>(archivoJugadores);
            comboBox1.DataSource = _equipos;
            comboBox1.DisplayMember = "Nombre";

            //Todos los jugadores ordenados por equipos
            var query = (from j in _jugadores
                         join eq in _equipos on j.Equipo equals eq.Nombre
                         select j).OrderBy(ju => ju.Equipo);

            dataGridView1.DataSource = query.ToList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selection = (Equipo)comboBox1.SelectedItem;

            var query = (from j in _jugadores
                         where j.Equipo == selection.Nombre
                         select j).OrderBy(ju => ju.Equipo);

            dataGridView1.DataSource = query.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var query = (from j in _jugadores
                         join eq in _equipos on j.Equipo equals eq.Nombre
                         select j).OrderBy(ju => ju.Equipo);

            dataGridView1.DataSource = query.ToList();
        }
    }
}
