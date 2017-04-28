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
    public partial class CPTest : UserControl
    {
        int num = 1;
        public Panel pn;
        private CNTest P = new CNTest();
        public CPTest()
        {
            InitializeComponent();
        }

        private void CPTest_Load(object sender, EventArgs e)
        {
  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && DgvSubTest.RowCount > 0)
                {
                    String Mensaje = "";
                    var dataTable = new DataTable();
                    dataTable.Columns.Add("Nombre", typeof(string));
                    dataTable.Columns.Add("Parametros", typeof(string));
                    for (int a = 0; a < DgvSubTest.RowCount; a++)
                    {
                        dataTable.Rows.Add(DgvSubTest.Rows[a].Cells[1].Value, DgvSubTest.Rows[a].Cells[2].Value);
                    }
                    P.Nombre = textBox1.Text;
                    P.Parametro = textBox2.Text;
                    Mensaje = P.IngresarTest(dataTable);
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
                else
                {
                    MessageBox.Show("Faltan Campos por Completar", "Sistema de SysLab", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                num = DgvSubTest.RowCount;
                DgvSubTest.Rows.Add(num, textBox3.Text, textBox4.Text);
                textBox3.Clear();
            }
            else {
                MessageBox.Show("Ingrese Nombre del SubTest", "Sistema de SysLab", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DgvSubTest_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DgvSubTest.Rows.RemoveAt(DgvSubTest.CurrentRow.Index);
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
                DgvSubTest.Rows.Clear();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pn.Controls.Clear();
        }
    }
}
