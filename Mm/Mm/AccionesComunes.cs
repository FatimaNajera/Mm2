using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;


namespace Mm
{
    internal class AccionesComunes
    {
        public static void Mensaje(string mensaje)
        {
            MessageBox.Show(mensaje, "AVISO!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void llenarCombo(string consulta, ComboBox combo, string id, string campo)
        {
            DataTable dt;
            dt = Conexion.EjecutaSeleccion(consulta);
            if (dt == null)
            {
                return;
            }
            DataRow fila = dt.NewRow();
            fila[id] = 0;
            fila[campo] = "TODOS";
            dt.Rows.InsertAt(fila, 0);
            combo.DataSource = dt;
            combo.ValueMember = id;
            combo.DisplayMember = campo;
        }
        public static void llenarDataGrid(string consulta, DataGridView datagrid)
        {
            DataTable dt;
            dt = Conexion.EjecutaSeleccion(consulta);
            if (dt == null)
            {
                return;
            }
            datagrid.DataSource = dt;
        }
        public static void llenarListView(string consulta, ListView list)
        {
            DataTable dt;
            dt = Conexion.EjecutaSeleccion(consulta);
            int columns = dt.Columns.Count;
            if (dt == null)
            {
                return;
            }
            list.View = View.Details;
            foreach (DataColumn itemColumn in dt.Columns)
            {
                list.Columns.Add(Convert.ToString(itemColumn));
            }
            foreach (DataRow row in dt.Rows)
            {
                ListViewItem itemlist = new ListViewItem(Convert.ToString(row[0]));
                for (int i = 1; i < columns; i++)
                {
                    itemlist.SubItems.Add(Convert.ToString(row[i]));
                }
                list.Items.Add(itemlist);
            }
        }
    }
}
