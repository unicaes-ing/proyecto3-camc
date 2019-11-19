using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Utils
{
    public class PromptTextAndSelection
    {
        private ArchivosController archivos;
        private const string archivoEquipos = "equipos.bin";
        private const string archivoJugadores = "jugadores.bin";
        private List<Jugador> _jugadores;
        private List<Equipo> _equipos;

        public PromptTextAndSelection()
        {
            archivos = new ArchivosController();
        }

        public void ShowDialog(string caption, string selStr, string equipo)
        {
            _jugadores = archivos.Deserializar<Jugador>(archivoJugadores);
            Form prompt = new Form
            {
                Width = 280,
                Height = 160,
                Text = caption
            };
            TextBox textBox = new TextBox() { Left = 16, Top = 40, Width = 240, TabIndex = 0, TabStop = true };
            Label selLabel = new Label() { Left = 16, Top = 66, Width = 88, Text = selStr };
            ComboBox cmbx = new ComboBox() { Left = 112, Top = 64, Width = 144 };

            var query = (from ju in _jugadores
                         where ju.Equipo == equipo
                         select ju).ToList();
            cmbx.DataSource = query;
            cmbx.DisplayMember = "Nombre";

            Button confirmation = new Button() { Text = "Elegir", Left = 16, Width = 80, Top = 88, TabIndex = 1, TabStop = true };
            confirmation.Click += (sender, e) => {
                var select = (Jugador)cmbx.SelectedItem;
                var encontrado = _jugadores.Find(j => j.Equipo == select.Equipo);
                encontrado.Goles++;
                archivos.Serializar(archivoJugadores, _jugadores);
                prompt.Close();
            };
            prompt.Controls.Add(selLabel);
            prompt.Controls.Add(cmbx);
            prompt.Controls.Add(confirmation);
            prompt.AcceptButton = confirmation;
            prompt.StartPosition = FormStartPosition.CenterScreen;
            prompt.ShowDialog();


            //return (Jugador)cmbx.SelectedItem;
        }
    }
}
