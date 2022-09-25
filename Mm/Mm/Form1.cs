using System;
using System.Windows.Forms;

namespace Mm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int Registros = 0;
            Conexion.EjecutaConsulta(textBox1.Text);
            AccionesComunes.Mensaje("" + Registros);
            AccionesComunes.llenarCombo(textBox1.Text, comboBox1, "Id", "Nombre");
            AccionesComunes.llenarCombo(textBox1.Text, comboBox2, "Id", "Nombre");
            AccionesComunes.llenarDataGrid(textBox1.Text, dataGridView1);
            AccionesComunes.llenarListView(textBox1.Text, listView1);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            label1.Text = comboBox1.SelectedValue.ToString();
        }
    }
}