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
    public partial class CPConsultarUsuario : UserControl
    {
        public Panel pn;
        CNUsuario P = new CNUsuario();
        Utilidades U = new Utilidades();
        public CPConsultarUsuario()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pn.Controls.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    DataTable dt = new DataTable();
                    P.Cedula = Convert.ToInt32(textBox1.Text);
                    dt = P.BusquedaUsuario();
                    try
                    {
                        textBox2.Text = dt.Rows[0][0].ToString();
                        comboBox1.Text = dt.Rows[0][1].ToString();
                        textBox5.Text = dt.Rows[0][2].ToString();
                        comboBox2.Text = dt.Rows[0][3].ToString();
                        textBox6.Text = dt.Rows[0][4].ToString();


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Cedula no se encuentra Registrada", "Sistema de SysLab", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese el Campo Cedula", "Sistema de SysLab", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch { }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            U.validar_Campo_num(e);
        }
    }
}
