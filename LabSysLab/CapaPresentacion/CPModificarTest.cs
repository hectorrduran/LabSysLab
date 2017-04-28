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
    public partial class CPModificarTest : UserControl
    {
        public Panel pn;
        CNTest P = new CNTest();
        DataTable dt = new DataTable();
        public CPModificarTest()
        {
            InitializeComponent();
        }

        private void CPModificarTest_Load(object sender, EventArgs e)
        {
            dt = P.MostrarTest();
            if (dt.Rows.Count > 0)
            {
                comboBox1.ValueMember = "id";
                comboBox1.DisplayMember = "Nombre";
                comboBox1.DataSource = dt;
            }
            else { comboBox1.Text = "No Disponible"; }
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            foreach(DataRow row in dt.Rows)
            {
                textBox1.Text = row[2].ToString();
            }

            DgvSubTest.Rows.Clear();
            DataTable dt1 = new DataTable();
            P.Id = Convert.ToInt32(comboBox1.SelectedValue);
            dt1 = P.MostrarSubTest();
            if (dt1.Rows.Count > 0)
            {
                DgvSubTest.Rows.Clear();
                foreach (DataRow row in dt1.Rows)
                {
                    DgvSubTest.Rows.Add(row[1], row[2]);
                }
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                groupBox1.Enabled = true;
                DgvSubTest.Enabled = true;
            }
            else
            {
                groupBox1.Enabled = false;
                DgvSubTest.Enabled = false;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                DgvSubTest.Rows.Add(textBox3.Text, textBox2.Text);
                textBox3.Clear();
                textBox2.Clear();
            }
            else
            {
                MessageBox.Show("Ingrese Nombre del SubTest", "Sistema de SysLab", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void DgvSubTest_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DgvSubTest.Rows.RemoveAt(DgvSubTest.CurrentRow.Index);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String Mensaje = "";
                var dataTable = new DataTable();
                dataTable.Columns.Add("Nombre", typeof(string));
                dataTable.Columns.Add("Parametros", typeof(string));
                for (int a = 0; a < DgvSubTest.RowCount; a++)
                {
                    dataTable.Rows.Add(DgvSubTest.Rows[a].Cells[0].Value, DgvSubTest.Rows[a].Cells[1].Value);
                }
                P.Id = Convert.ToInt32(comboBox1.SelectedValue);
                P.Parametro = textBox1.Text;
                Mensaje = P.ModificarSubTest(dataTable);
                if (Mensaje == "Registrado Correctamente.")
                {
                    MessageBox.Show(Mensaje, "Sistema de SysLab", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    pn.Controls.Clear();
                }
                else
                {
                    MessageBox.Show(Mensaje, "Sistema de SysLab", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pn.Controls.Clear();
        }
    }
}
