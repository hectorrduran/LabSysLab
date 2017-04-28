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
    public partial class CPConsultarEmpleadoC : UserControl
    {
        public Panel pn;
        private CNEmpleado P = new CNEmpleado();

        public CPConsultarEmpleadoC()
        {
            InitializeComponent();
        }

        private void CPConsultarEmpleadoC_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    DataTable dt = new DataTable();
                    P.Cedula = Convert.ToInt32(textBox1.Text);
                    dt = P.ListarEmpleado();
                    try
                    {
                        textBox2.Text = dt.Rows[0][1].ToString();
                        textBox3.Text = dt.Rows[0][2].ToString();
                        textBox4.Text = dt.Rows[0][3].ToString();
                        textBox5.Text = dt.Rows[0][4].ToString();
                        textBox6.Text = dt.Rows[0][5].ToString();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Cedula no se encuentra Registrada", "Sistema de SysLab", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else {
                    MessageBox.Show("Ingresar Campo Cedula", "Sistema de SysLab", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pn.Controls.Clear();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades U = new Utilidades();
            U.validar_Campo_num(e);
        }
    }
}
