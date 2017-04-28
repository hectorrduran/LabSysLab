using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
namespace CapaPresentacion
{
    public partial class CPModificarOrdenMedica : UserControl
    {
        Utilidades U = new Utilidades();
        CNTest T = new CNTest();
        public Panel pn;
        public CPModificarOrdenMedica()
        {
            InitializeComponent();
        }

        private void CPModificarOrdenMedica_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = T.MostrarExamenes();
            if (dt.Rows.Count > 0)
            {
                comboBox1.ValueMember = "id";
                comboBox1.DisplayMember = "Nombre";
                comboBox1.DataSource = dt;
            }
            else { comboBox1.Text = "No Disponible"; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                try
                {
                    DataTable table = new DataTable();
                    table = T.MostrarExamenesResul(Convert.ToInt32(textBox1.Text));
                    textBox2.Text = table.Rows[0][0].ToString();
                    textBox3.Text = table.Rows[0][1].ToString();
                    foreach (DataRow row in table.Rows)
                    {

                        DgvSubTest.Rows.Add(row[2], row[3]);
                    }
                }
                catch
                {
                    MessageBox.Show("Nro Orden no Existe");
                }
            }
            else
            {
                MessageBox.Show("Ingrese Campo Nro Orden");
            }
        }

        private void DgvSubTest_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DgvSubTest.Rows.RemoveAt(DgvSubTest.CurrentRow.Index);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            bool bandera = false;
            for (int rows = 0; rows < DgvSubTest.RowCount; rows++)
            {
                if (Convert.ToInt32(DgvSubTest.Rows[rows].Cells[0].Value) == Convert.ToInt32(comboBox1.SelectedValue))
                {
                    MessageBox.Show("Examen se Encuentra Agregado");
                    bandera = true;
                    break;
                }
            }
            if (bandera == false)
                DgvSubTest.Rows.Add(comboBox1.SelectedValue, comboBox1.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvSubTest.RowCount > 0)
                {
                    String Mensaje = "";
                    var dataTable = new DataTable();
                    dataTable.Columns.Add("id_examen", typeof(string));
                    for (int a = 0; a < DgvSubTest.RowCount; a++)
                    {
                        dataTable.Rows.Add(DgvSubTest.Rows[a].Cells[0].Value);
                    }

                    Mensaje = T.ModificarOrdenExamen(dataTable, Convert.ToInt32(textBox1.Text));
                    if (Mensaje == "Actualizado Correctamente.")
                    {
                        MessageBox.Show(Mensaje, "Sistema de SysLab.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        pn.Controls.Clear();
                    }
                    else
                    {
                        MessageBox.Show(Mensaje, "Sistema de SysLab.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }else
                {
                    MessageBox.Show("Ingrese Examenes a la Orden", "Sistema de SysLab.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pn.Controls.Clear();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            U.validar_Campo_num(e);
        }
    }
}
