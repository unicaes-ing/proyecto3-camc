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
using WindowsFormsApp1.Utils;

namespace WindowsFormsApp1.Views
{
    public partial class IngresarResultadosForm : Form
    {
        private ArchivosController archivos;
        private const string archivoEquipos = "equipos.bin";
        private const string archivoJugadores = "jugadores.bin";
        private List<Jugador> _jugadores;
        private List<Equipo> _equipos;

        public IngresarResultadosForm()
        {
            InitializeComponent();
            archivos = new ArchivosController();
        }

        private void IngresarResultadosForm_Load(object sender, EventArgs e)
        {
            _equipos = archivos.Deserializar<Equipo>(archivoEquipos);
            _jugadores = archivos.Deserializar<Jugador>(archivoJugadores);
            if (_equipos[0].PJ > 0)
            {
                RellenarGrid();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //int eq1 = int.Parse(Prompt.ShowDialog("Cantidad de goles para " + _equipos[i], _equipos[i] + " VS " + _equipos[i + 1]));
            foreach (var item in _equipos)
            {
                if (item.CantJugadores <= 0)
                {
                    MessageBox.Show("Al menos un equipo no posee jugadores", "Alerta", MessageBoxButtons.OK);
                    return;
                }
            }

            for (int i = 0; i < _equipos.Count; i++)
            {
                for (int j = 0; j < _equipos.Count; j++)
                {
                    if (_equipos[i].Nombre != _equipos[j].Nombre)
                    {
                        int eq1 = int.Parse(Prompt.ShowDialog("Goles para " + _equipos[i].Nombre, _equipos[i].Nombre + " VS " + _equipos[j].Nombre));

                        for (int k = 0; k < eq1; k++)
                        {
                            PromptTextAndSelection prompt = new PromptTextAndSelection();
                           prompt.ShowDialog("Gol " + (k + 1), "Jugador", _equipos[i].Nombre);
                        }

                        int contra = int.Parse(Prompt.ShowDialog("Goles para " + _equipos[j].Nombre, _equipos[i].Nombre + " VS " + _equipos[j].Nombre));

                        if (_equipos[i].Resultado == null)
                        {
                            _equipos[i].Resultado = new List<string>();
                        }
                        _equipos[i].Resultado.Add($"{eq1}-{contra}");
                        _equipos[i].PJ++;
                        _equipos[i].GF += eq1;
                        _equipos[i].GC += contra;

                        if (eq1 > contra)
                        {
                            _equipos[i].PG++;
                            _equipos[i].P += 3;
                        }
                        else if(eq1 == contra)
                        {
                            _equipos[i].PE++;
                            _equipos[i].P += 1;
                        }
                        else
                        {
                            _equipos[i].PP++;
                        }
                    }
                }
            }

            RellenarGrid();
            archivos.Serializar(archivoEquipos, _equipos);
        }

        private void RellenarGrid()
        {
            //var query = (from eq in _equipos
            //            select new { Equipo = eq.Nombre, eq.Resultado }).ToDictionary(e => e.Equipo, e => e.Resultado);
            //dataGridView1.DataSource = query.ToList();
            dataGridView1.ColumnCount = _equipos.Count + 1;
            
            DataGridViewRow row = new DataGridViewRow();

            for (int i = 0; i < _equipos.Count; i++)
            {
                dataGridView1.Columns[0].Name = "";
                dataGridView1.Columns[i + 1].Name = _equipos[i].Nombre;
            }
            

            string[,] cuadricula = new string[_equipos.Count, _equipos.Count + 1];


            for (int i = 0; i < cuadricula.GetLength(0); i++)
            {
                row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                int count = 0;
                for (int j = 1; j < cuadricula.GetLength(1); j++)
                {
                    row.Cells[0].Value = _equipos[i].Nombre;

                    if (i == (j - 1))
                    {
                        row.Cells[j].Value = " X ";
                    }
                    else
                    {
                        row.Cells[j].Value = _equipos[i].Resultado[count];
                        count++;
                    }
                }
                dataGridView1.Rows.Insert(i, row);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //if (queryEq.Count > 0)
            //{
            //    MessageBox.Show("Al menos un equipo no posee jugadores", "Alerta", MessageBoxButtons.OK);
            //    return;
            //}

            Random random = new Random();
            for (int i = 0; i < _equipos.Count; i++)
            {
                for (int j = 0; j < _equipos.Count; j++)
                {
                    if (_equipos[i].Nombre != _equipos[j].Nombre)
                    {
                        int eq1 = random.Next(0, 11);

                        for (int k = 0; k < eq1; k++)
                        {
                            var query = (from ju in _jugadores
                                         where ju.Equipo == _equipos[i].Nombre
                                         select ju).ToList();

                            var encontrado = query[random.Next(0, query.Count)];
                            encontrado.Goles++;
                            archivos.Serializar(archivoJugadores, _jugadores);
                        }

                        int contra = random.Next(0, 11);

                        if (_equipos[i].Resultado == null)
                        {
                            _equipos[i].Resultado = new List<string>();
                        }
                        _equipos[i].Resultado.Add($"{eq1}-{contra}");
                        _equipos[i].PJ++;
                        _equipos[i].GF += eq1;
                        _equipos[i].GC += contra;

                        if (eq1 > contra)
                        {
                            _equipos[i].PG++;
                            _equipos[i].P += 3;
                        }
                        else if (eq1 == contra)
                        {
                            _equipos[i].PE++;
                            _equipos[i].P += 1;
                        }
                        else
                        {
                            _equipos[i].PP++;
                        }
                    }
                }
            }

            RellenarGrid();
            archivos.Serializar(archivoEquipos, _equipos);
        }
    }
}
