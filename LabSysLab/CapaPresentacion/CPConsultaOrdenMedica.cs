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
    public partial class CPConsultaOrdenMedica : UserControl
    {
        Utilidades U = new Utilidades();
        Panel panel;
        public Panel pn;
        CNTest T = new CNTest();
        public UserControl obj = new UserControl();
        public CPConsultaOrdenMedica(Panel p)
        {
            InitializeComponent();
            panel = p;
        }

        private void CPConsultaOrdenMedica_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    try
                    {
                        DataTable consulta = new DataTable();
                        consulta = T.MostrarOrdenMedicas(Convert.ToInt32(textBox1.Text));

                        textBox2.Text = consulta.Rows[0][4].ToString();
                        textBox3.Text = consulta.Rows[0][5].ToString();

                        foreach (DataRow row in consulta.Rows)
                        {
                            DgvSubTest.Rows.Add(row[0].ToString(), row[2].ToString() + " " + row[3].ToString(), Convert.ToDateTime(row[1]).Date.ToShortDateString());
                        }
                    }
                    catch { MessageBox.Show("Cedula No registrada"); }
                }
                else
                {
                    MessageBox.Show("Ingrese Campo Cedula");
                }
            }
            catch { }
        }

        private void DgvSubTest_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CPMenuPrincipal frm = new CPMenuPrincipal();
            CPOrdenMedicaIndv obj = new CPOrdenMedicaIndv();
            obj.pn = pn;
            obj.nro_ord = Convert.ToInt32(DgvSubTest.Rows[DgvSubTest.CurrentRow.Index].Cells[0].Value);
            panel.Controls.Clear();
            obj.Top = (panel.Height - obj.Height) / 2;
            obj.Left = (panel.Width - obj.Width) / 2;
            panel.Controls.Add(obj);
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
