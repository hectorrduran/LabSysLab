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
    public partial class CPModificarEmpleadoC : UserControl
    {
        private int cedula;
        Utilidades U = new Utilidades();
        public Panel pn;
        CNEmpleado P = new CNEmpleado();
        public CPModificarEmpleadoC()
        {
            InitializeComponent();
        }

        private void CPModificarEmpleadoC_Load(object sender, EventArgs e)
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
                        maskedTextBox1.Text = dt.Rows[0][4].ToString();
                        comboBox1.Text = dt.Rows[0][5].ToString();
                        cedula= Convert.ToInt32(textBox1.Text); 

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Cedula no se encuentra Registrada");
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese Campo Cedula");
                }
            }
            catch { }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                U.validar_campos(groupBox2);
                String Mensaje = "";
                P.Cedula = cedula;
                P.Nombre = textBox2.Text;
                P.Apellido = textBox3.Text;
                P.Correo = textBox4.Text;
                P.Telefono = maskedTextBox1.Text;
                P.Cargo = comboBox1.Text;
                Mensaje = P.ModificarEmpleado();
                if (Mensaje == "Los datos se han Actualizado Correctamente.")
                {
                    MessageBox.Show(Mensaje, "Sistema de SysLab", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    pn.Controls.Clear();
                }
                else
                {
                    MessageBox.Show("No se Actualizaron los datos", "Sistema de SysLab", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch { }
         }

        private void button2_Click(object sender, EventArgs e)
        {
            pn.Controls.Clear();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            U.validar_Campo_num(e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            U.validar_Campo_texto(e);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            U.validar_Campo_texto(e);
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
