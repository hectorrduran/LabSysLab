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
    public partial class CPModificarPacienteC : UserControl
    {
        Utilidades U = new Utilidades();
        private CNPaciente P = new CNPaciente();
        public Panel pn;
        public CPModificarPacienteC()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox9.Text != "")
            {
                DataTable dt = new DataTable();
                P.Cedula = Convert.ToInt32(textBox9.Text);
                dt = P.BusquedaPaciente();
                try
                {
                    textBox2.Text = dt.Rows[0][1].ToString();
                    textBox3.Text = dt.Rows[0][2].ToString();
                    textBox4.Text = dt.Rows[0][3].ToString();
                    if (dt.Rows[0][4].ToString() == "M")
                    {
                        radioButton1.Checked = true;
                    }
                    else
                    {
                        radioButton2.Checked = true;

                    }
                    dateTimePicker1.Value = Convert.ToDateTime(dt.Rows[0][5].ToString());
                    textBox6.Text = dt.Rows[0][6].ToString();
                    maskedTextBox1.Text = dt.Rows[0][7].ToString();
                    textBox8.Text = dt.Rows[0][8].ToString();

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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                U.validar_campos(groupBox2);
                String Mensaje = "";
                P.Cedula = Convert.ToInt32(textBox9.Text);
                P.Nombre = textBox2.Text;
                P.Apellido = textBox3.Text;
                P.Edad = Convert.ToInt32(textBox4.Text);
                if (radioButton1.Checked == true)
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
                Mensaje = P.ModificarPaciente();
                if (Mensaje == "Los datos se han Actualizado Correctamente.")
                {
                    MessageBox.Show(Mensaje, "Sistema de SysLab", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    pn.Controls.Clear();
                }
                else
                {
                    MessageBox.Show("Los Datos no se actualizaron correctamente", "Sistema de SysLab", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pn.Controls.Clear();
        }

        private void CPModificarPacienteC_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MaxDate = DateTime.Now;
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {
            int year, mes, dia, edad;
            year = DateTime.Now.Year;
            mes = DateTime.Now.Month;
            dia = DateTime.Now.Day;
            edad = DateTime.Now.Year - dateTimePicker1.Value.Year - 1;
            if (dateTimePicker1.Value.Month <= mes)
                if (dateTimePicker1.Value.Day <= dia)
                {
                    edad = year - dateTimePicker1.Value.Year;
                }
            textBox4.Text = Convert.ToString(edad);
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

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
