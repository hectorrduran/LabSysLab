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
    public partial class CPIngresarPacienteC : UserControl
    {
        Utilidades U = new Utilidades();
        private CNPaciente P = new CNPaciente();
        public Panel pn;
        public CPIngresarPacienteC()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           try {
            U.validar_campos(groupBox1);
            String Mensaje = "";
            P.validar_campos(groupBox1);
            P.Cedula = Convert.ToInt32(textBox1.Text);
            P.Nombre = textBox2.Text;
            P.Apellido = textBox3.Text;
            P.Edad = Convert.ToInt32(textBox4.Text);
            if(radioButton1.Checked==true)
               {
                    P.Sexo = 'M';
                }
                else
                {
                    P.Sexo = 'F';
                }
            P.Fecha = Convert.ToDateTime(dateTimePicker1.Value.Date);
            P.Direccion = textBox6.Text;
            P.Telefono = maskedTextBox1.Text;
            P.Correo = textBox8.Text;
            Mensaje = P.RegistrarPaciente();
            if (Mensaje == "Este Paciente ya ha sido Registrado.")
            {
                MessageBox.Show(Mensaje, "Sistema de SysLab", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show(Mensaje, "Sistema de SysLab", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pn.Controls.Clear();
                }
            }
            catch (Exception a)
            {

            }
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            pn.Controls.Clear();
        }

        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {
            int year, mes, dia, edad;
            year = DateTime.Now.Year;
            mes = DateTime.Now.Month;
            dia = DateTime.Now.Day;
            edad = DateTime.Now.Year - dateTimePicker1.Value.Year - 1;
            if (dateTimePicker1.Value.Month<=mes)
                if(dateTimePicker1.Value.Day<=dia)
                    {
                        edad = year - dateTimePicker1.Value.Year;
                    }
            textBox4.Text = Convert.ToString(edad);
        }

        private void CPIngresarPacienteC_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MaxDate = DateTime.Now;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            P.validar_Campo_num(e);   
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            U.validar_Campo_texto(e);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            U.validar_Campo_texto(e);
        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            try
            {

                if (U.ComprobarFormatoEmail(textBox8.Text) == false)
                {
                    MessageBox.Show("Direcciòn de correo invalida", "Agregar Empleado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox8.ForeColor = Color.Red;
                }
                else
                {
                    textBox8.ForeColor = Color.Green;
                }
            }
            catch { }
        }
    }
}
