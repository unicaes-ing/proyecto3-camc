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
    public partial class EquiposForm : Form
    {
        private ArchivosController archivos;
        private const string nombreArchivo = "equipos.bin";
        private int rowIndex;

        public EquiposForm()
        {
            InitializeComponent();
            archivos = new ArchivosController();
        }

        private void EquiposForm_Load(object sender, EventArgs e)
        {
            var lista = archivos.Deserializar<Equipo>(nombreArchivo);
            var query = (from eq in lista
                         select new { eq.Nombre }).ToList();
            dataGridView1.DataSource = query;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtnombreEquipo.Text))
            {
                lblError.Visible = true;
                lblError.Text = "El nombre es requerido";
                return;
            }

            var lista = archivos.Deserializar<Equipo>(nombreArchivo);
            if (lista != null)
            {
                if (lista.Find(eq => eq.Nombre.Equals(txtnombreEquipo.Text.ToUpper())) != null)
                {
                    lblError.Visible = true;
                    lblError.Text = "El nombre ya está en la lista";
                    return;
                }
            }

            lblError.Visible = false;

            Equipo equipo = new Equipo
            {
                Nombre = txtnombreEquipo.Text.ToUpper(),
            };

            archivos.Serializar<Equipo>(nombreArchivo, equipo);
            var equipos = archivos.Deserializar<Equipo>(nombreArchivo);
            var query = (from eq in equipos
                         select new { eq.Nombre }).ToList();
            dataGridView1.DataSource = query;
            txtnombreEquipo.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEliminar.Enabled = true;
            rowIndex = e.RowIndex;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rowIndex == -1) return;

            string equipo = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            var equipos = archivos.Deserializar<Equipo>(nombreArchivo);

            var borrar = equipos.Find(eq => eq.Nombre == equipo);
            equipos.Remove(borrar);

            archivos.Serializar(nombreArchivo, equipos);

            equipos = archivos.Deserializar<Equipo>(nombreArchivo);

            var query = (from eq in equipos
                         select new { eq.Nombre }).ToList();
            dataGridView1.DataSource = query;

            //Eliminar equipos hay que agregar al modelo los resultados y si ya poseen no se borra
            //Si no existe hay que borrarlo asi : listaJugadores.RemoveAll(j => j.Equipo = equipo);

        }
    }
}
