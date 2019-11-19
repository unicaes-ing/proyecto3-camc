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
    public partial class JugadoresForm : Form
    {
        private ArchivosController archivos;
        private const string archivoEquipos = "equipos.bin";
        private const string archivoJugadores = "jugadores.bin";
        private Jugador _borrarJugador;
        private int selectRow = 0;
        private List<string> _posiciones;
        private List<Equipo> _equipos;

        public JugadoresForm()
        {
            InitializeComponent();
            archivos = new ArchivosController();
            _posiciones = new List<string>
            {
                "Delantero",
                "Portero",
                "Volante",
                "Defenza"
            };

            btnBorrar.Enabled = false;
        }

        private void JugadoresForm_Load(object sender, EventArgs e)
        {
            var todos = archivos.Deserializar<Jugador>(archivoJugadores);
            comboEquipos.DataSource = archivos.Deserializar<Equipo>(archivoEquipos);
            dataGridView1.DataSource = todos;
            comboEquipos.DisplayMember = "Nombre";
            comboEquipos.ValueMember = "Nombre";

            foreach (var pos in _posiciones)
            {
                comboPos.Items.Add(pos);
            }

            if (todos != null)
            {
                btnBorrar.Enabled = true;              
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                lblErrorNombre.Visible = true;
                lblErrorNombre.Text = "El nombre es requerido";
                return;
            }
            if (nbGoles.Value < 0)
            {
                lblErrorGoles.Visible = true;
                lblErrorGoles.Text = "Los goles no pueden ser menores a cero";
                return;
            }
            lblErrorNombre.Visible = false;
            lblErrorGoles.Visible = false;

            var selectedEquipo = (Equipo)comboEquipos.SelectedItem;

            Jugador jugador = new Jugador
            {
                Nombre = txtNombre.Text,
                Posicion = comboPos.Text,
                Goles = Convert.ToInt32(nbGoles.Value),
                Equipo = selectedEquipo.Nombre,
            };

            _equipos = archivos.Deserializar<Equipo>(archivoEquipos);
            var encontrar = _equipos.Find(eq => eq.Nombre == jugador.Equipo);
            if (encontrar != null)
            {
                encontrar.CantJugadores++;
            }
            archivos.Serializar(archivoJugadores, jugador);
            archivos.Serializar(archivoEquipos, _equipos);
            dataGridView1.DataSource = archivos.Deserializar<Jugador>(archivoJugadores);
            btnBorrar.Enabled = true;
            txtNombre.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectRow = e.RowIndex;
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            string nombre = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string equipo = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            List<Jugador> jugadores = new List<Jugador>();
            jugadores = archivos.Deserializar<Jugador>(archivoJugadores);
            _borrarJugador = jugadores.Find(jugador1 => jugador1.Equipo == equipo && jugador1.Nombre == nombre);

            if (_borrarJugador.Goles > 0)
            {
                MessageBox.Show("El jugador ya posee goles. No se puede eliminar", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            DialogResult result = MessageBox.Show("¿Seguro que desea eliminar este jugador?", "Alerta", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                jugadores.Remove(_borrarJugador);
                archivos.Serializar(archivoJugadores, jugadores);
                dataGridView1.DataSource = archivos.Deserializar<Jugador>(archivoJugadores);

                _equipos = archivos.Deserializar<Equipo>(archivoEquipos);
                var encontrar = _equipos.Find(eq => eq.Nombre == _borrarJugador.Equipo);
                if (encontrar != null)
                {
                    encontrar.CantJugadores--;
                }
                archivos.Serializar(archivoEquipos, _equipos);
            }
            if (dataGridView1.RowCount == 0)
            {
                btnBorrar.Enabled = false;
            }
        }   
    }
}
