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
    public partial class TablaPosiciones : Form
    {
        private ArchivosController archivos;
        private const string archivoEquipos = "equipos.bin";

        public TablaPosiciones()
        {
            InitializeComponent();
            archivos = new ArchivosController();
        }

        private void TablaPosiciones_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = archivos.Deserializar<Equipo>(archivoEquipos);
        }
    }
}
