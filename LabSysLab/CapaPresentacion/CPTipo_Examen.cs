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
    public partial class CPTipo_Examen : UserControl
    {
        public Panel pn;
        private CNTest P = new CNTest();
        public CPTipo_Examen()
        {
            InitializeComponent();
        }

        private void CPTipo_Examen_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = P.MostrarTest();
            if (dt.Rows.Count > 0)
            {
                comboBox1.ValueMember = "id";
                comboBox1.DisplayMember = "Nombre";
                comboBox1.DataSource = dt;
            }
            else { comboBox1.Text = "No Disponible"; }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool bandera = false;
           for(int rows=0; rows<DgvSubTest.RowCount; rows++)
            {
                if(Convert.ToInt32(DgvSubTest.Rows[rows].Cells[0].Value)== Convert.ToInt32(comboBox1.SelectedValue))
                {
                    MessageBox.Show("Test se Encuentra Agregado");
                    bandera = true;
                    break;
                }
            }
           if(bandera==false)
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
                if (textBox1.Text!="" && DgvSubTest.RowCount>0)
                {
                    String Mensaje = "";
                    var dataTable = new DataTable();
                    dataTable.Columns.Add("id", typeof(string));
                    for (int a = 0; a < DgvSubTest.RowCount; a++)
                    {
                        dataTable.Rows.Add(DgvSubTest.Rows[a].Cells[0].Value);
                    }
                    P.Nombre = textBox1.Text;
                    P.Alerta = checkBox1.Checked;
                    Mensaje = P.IngresarExamen(dataTable);
                    if (Mensaje == "Registrado Correctamente.")
                    {
                        MessageBox.Show(Mensaje, "Sistema Syslab", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        pn.Controls.Clear();
                    }
                    else
                    {
                        MessageBox.Show(Mensaje, "Sistema Syslab", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Faltan Campos Por llenar", "Sistema Syslab", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
