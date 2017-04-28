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
    public partial class CPIngresarEmpleadoC : UserControl
    {
        public Panel pn;
        Utilidades U = new Utilidades();
        CNEmpleado P = new CNEmpleado();
        public CPIngresarEmpleadoC()
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
                U.validar_campos(groupBox1);
                String Mensaje = "";
                P.Cedula = Convert.ToInt32(textBox1.Text);
                P.Nombre = textBox2.Text;
                P.Apellido = textBox3.Text;
                P.Correo = textBox4.Text;
                P.Telefono = maskedTextBox1.Text;
                P.Cargo = comboBox1.Text;
                Mensaje = P.RegistrarProductos();
                if (Mensaje == "Este Empleado ya ha sido Registrado.")
                {
                    MessageBox.Show(Mensaje, "Sistema de SisLab.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show(Mensaje, "Sistema de SisLab.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pn.Controls.Clear();

                }
            }
            catch { }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            U.validar_Campo_num(e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            U.validar_Campo_texto(e);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            U.validar_Campo_texto(e);
        }

        private void CPIngresarEmpleadoC_Load(object sender, EventArgs e)
        {

        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            try
            {
               
                if (U.ComprobarFormatoEmail(textBox4.Text) == false)
                {
                    MessageBox.Show("Direcciòn de correo invalida", "Agregar Empleado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox4.ForeColor = Color.Red;
                }
                else
                {
                    textBox4.ForeColor = Color.Green;
                }
            }
            catch { }
        }
    }
}
