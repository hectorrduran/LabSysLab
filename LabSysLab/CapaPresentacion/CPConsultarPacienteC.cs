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
    public partial class CPConsultarPacienteC : UserControl
    {
        Utilidades U = new Utilidades();
        private CNPaciente P = new CNPaciente();
        public Panel pn;
        public CPConsultarPacienteC()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                U.validar_campos(groupBox1);
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
                        textBox5.Text = "Masculino";
                    }
                    else
                    {
                        textBox5.Text = "Femenino";
                    }
                    
                    dateTimePicker1.Value = Convert.ToDateTime(dt.Rows[0][5].ToString());
                    textBox6.Text = dt.Rows[0][6].ToString();
                    textBox7.Text = dt.Rows[0][7].ToString();
                    textBox8.Text = dt.Rows[0][8].ToString();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cedula no se encuentra Registrada");
                }
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pn.Controls.Clear();
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            U.validar_Campo_num(e);
        }
    }
}
