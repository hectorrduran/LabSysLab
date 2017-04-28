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
    public partial class CPResulExamen : UserControl
    {
        public Panel pn;
        public Panel panel;
        CNTest T = new CNTest();
        public CPResulExamen()
        {
            InitializeComponent();
        }

        private void CPResulExamen_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try

            { 
                DgvSubTest.Rows.Clear();

            if (textBox1.Text != "")
                {
                    try
                    {
                        int a = 0;
                        DataTable table = new DataTable();
                        table = T.MostrarExamenesResul(Convert.ToInt32(textBox1.Text));
                        textBox2.Text = table.Rows[0][0].ToString();
                        textBox3.Text = table.Rows[0][1].ToString();
                        
                        foreach (DataRow row in table.Rows)
                        {
                            a = a + 1;
                            DgvSubTest.Rows.Add(row[2], a, row[3]);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Nro de Orden No existe");
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese Campo Nro de Orden");
                }
            }
            catch { }
          
        }

        private void DgvSubTest_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CNPaciente pac = new CNPaciente();
            pac.Nombre = textBox2.Text;
            pac.Apellido = textBox3.Text;
            CPMenuPrincipal frm = new CPMenuPrincipal();
            CPIngresarResultados obj = new CPIngresarResultados();
            obj.pn = pn;
            obj.nroExamen = Convert.ToInt32(DgvSubTest.Rows[DgvSubTest.CurrentRow.Index].Cells[0].Value);
            obj.NroOrden = Convert.ToInt32(textBox1.Text);
            obj.Examen = Convert.ToString(DgvSubTest.Rows[DgvSubTest.CurrentRow.Index].Cells[2].Value);
            obj.paciente = pac;
            panel.Controls.Clear();
            obj.Top = (panel.Height - obj.Height) / 2;
            obj.Left = (panel.Width - obj.Width) / 2;
            panel.Controls.Add(obj);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pn.Controls.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            DgvSubTest.Rows.Clear();
        }
    }
}
