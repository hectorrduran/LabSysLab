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
    public partial class CPIngresarUsuarioC : UserControl
    {
        private CNUsuario P = new CNUsuario();
        private CNEmpleado PE = new CNEmpleado();
        private Utilidades U = new Utilidades();
        public Panel pn;
        public CPIngresarUsuarioC()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try{
                U.validar_campos(groupBox1);
                if (textBox3.Text==textBox4.Text) {
                    String Mensaje = "";
                    P.Cedula = Convert.ToInt32(textBox1.Text);
                    P.Usuario = textBox2.Text;
                    P.Contrasena = textBox3.Text;
                    P.pregunta = comboBox1.Text;
                    P.respuesta = textBox5.Text;
                    P.pregunta1 = comboBox2.Text;
                    P.respuesta1 = textBox6.Text;
                    Mensaje = P.RegistraUsuarios();
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
                    MessageBox.Show("Las contraseñas no son iguales", "Sistema de SysLab", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pn.Controls.Clear();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                PE.Cedula = Convert.ToInt32(textBox1.Text);
                dt = PE.ListarEmpleado();
                textBox1.Text = dt.Rows[0][0].ToString();
                textBox8.Text = dt.Rows[0][1].ToString();
                textBox7.Text = dt.Rows[0][2].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Empleado no se encuentra Registrado", "Sistema de SysLab", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void CPIngresarUsuarioC_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            U.validar_Campo_num(e);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
