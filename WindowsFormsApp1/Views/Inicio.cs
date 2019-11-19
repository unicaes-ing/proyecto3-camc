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
    public partial class Inicio : Form
    {
        private ArchivosController arch;
        private const string archivoEquipos = "equipos.bin";
        private const string archivoJugadores = "jugadores.bin";
        private List<Jugador> _jugadores;
        private List<Equipo> _equipos;

        public Inicio()
        {
            InitializeComponent();
            arch = new ArchivosController();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void equiposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EquiposForm equiposForm = new EquiposForm();
            equiposForm.ShowDialog();
        }

        private void jugadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JugadoresForm jugadoresForm = new JugadoresForm();
            jugadoresForm.ShowDialog();
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarLigaForm mostrarLigaForm = new MostrarLigaForm();
            mostrarLigaForm.ShowDialog();
        }

        private void goleadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TablaGoleadores tablaGoleadores = new TablaGoleadores();
            MostrarLigaForm mostrarLigaForm = new MostrarLigaForm();
            List<Equipo> listaEq = new List<Equipo>();
            string archivo = "equipos.bin";
            listaEq = arch.Deserializar<Equipo>(archivo);

            if (listaEq.Count >= 5 && listaEq.Count <= 10)
            {
                tablaGoleadores.ShowDialog();
            }           
        }

        private void ingresarResultadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IngresarResultadosForm ingresarResultados = new IngresarResultadosForm();
           
            
            List<Equipo> listaEq = new List<Equipo>();
            string archivo = "equipos.bin";
            listaEq = arch.Deserializar<Equipo>(archivo);

            if (listaEq != null)
            {
                if (listaEq.Count >= 5 && listaEq.Count <= 10)
                {
                    ingresarResultados.ShowDialog();
                }
            }
        }

        private void Inicio_Load(object sender, EventArgs e)
        {

        }

        private void posicionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TablaPosiciones tabla = new TablaPosiciones();
            List<Equipo> listaEq = new List<Equipo>();
            string archivo = "equipos.bin";
            listaEq = arch.Deserializar<Equipo>(archivo);

            if (listaEq != null)
            {
                if (listaEq.Count >= 5 && listaEq.Count <= 10)
                {
                    tabla.ShowDialog();
                }
            }
            
        }

        private void restaurarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que desea restaurar la liga?", "Alerta", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                _equipos = arch.Deserializar<Equipo>(archivoEquipos);
                _jugadores = arch.Deserializar<Jugador>(archivoJugadores);

                foreach (var item in _equipos)
                {
                    item.Resultado = new List<string>();
                    item.GC = 0;
                    item.GF = 0;
                    item.P = 0;
                    item.PE = 0;
                    item.PG = 0;
                    item.PJ = 0;
                    item.PP = 0;
                }

                foreach (var item in _jugadores)
                {
                    item.Goles = 0;
                }

                arch.Serializar(archivoEquipos, _equipos);
                arch.Serializar(archivoJugadores, _jugadores);
                MessageBox.Show("Liga restaurada!", "Alerta");
            }
        }
    }
}
