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
    public partial class CPModificarExamen : UserControl
    {
        public Panel pn;
        CNTest T = new CNTest();
        public CPModificarExamen()
        {
            InitializeComponent();
        }

        private void CPModificarExamen_Load(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            dt = T.MostrarExamenes();
            if (dt.Rows.Count > 0)
            {
                comboBox2.ValueMember = "id";
                comboBox2.DisplayMember = "Nombre";
                comboBox2.DataSource = dt;
            }
            else { comboBox2.Text = "No Disponible"; }

            DataTable dt1 = new DataTable();
            dt1 = T.MostrarTest();
            if (dt1.Rows.Count > 0)
            {
                comboBox1.ValueMember = "id";
                comboBox1.DisplayMember = "Nombre";
                comboBox1.DataSource = dt1;
            }
            else { comboBox1.Text = "No Disponible"; }
        }

        private void comboBox2_DropDownClosed(object sender, EventArgs e)
        {
            DgvSubTest.Rows.Clear();
            DataTable dt = new DataTable();
            T.Id = Convert.ToInt32(comboBox2.SelectedValue);
            dt = T.MostrarTestExamen();
            foreach (DataRow row in dt.Rows)
            {
                DgvSubTest.Rows.Add(row[0], row[1]);
                checkBox1.Checked = Convert.ToBoolean(row[2]);
            }
            if(dt.Rows.Count>0)
            {
                groupBox1.Enabled = true;
                DgvSubTest.Enabled = true;
                checkBox1.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool bandera = false;
            for (int rows = 0; rows < DgvSubTest.RowCount; rows++)
            {
                if (Convert.ToInt32(DgvSubTest.Rows[rows].Cells[0].Value) == Convert.ToInt32(comboBox1.SelectedValue))
                {
                    MessageBox.Show("Test se Encuentra Agregado");
                    bandera = true;
                    break;
                }
            }
            if (bandera == false && comboBox1.Text!= "-Seleccione-")
                DgvSubTest.Rows.Add(comboBox1.SelectedValue, comboBox1.Text);
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

                if (DgvSubTest.RowCount > 0)
                {
                    var dataTable = new DataTable();
                    dataTable.Columns.Add("id", typeof(string));
                    for (int a = 0; a < DgvSubTest.RowCount; a++)
                    {
                        dataTable.Rows.Add(DgvSubTest.Rows[a].Cells[0].Value);
                    }

                    T.Id = Convert.ToInt32(comboBox2.SelectedValue);
                    T.Alerta = checkBox1.Checked;
                    Mensaje = T.ModificarTestExamen(dataTable);
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
                    MessageBox.Show("Debe Agregar Test Para Modificar el Examen", "Sistema de SysLab", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }catch
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pn.Controls.Clear();
        }
    }
}
