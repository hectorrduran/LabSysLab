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
using System.Runtime.InteropServices;

namespace CapaPresentacion
{
    public partial class CPModificarUsuario : UserControl
    {
        Utilidades U = new Utilidades();

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
       (
           int nLeftRect, // x-coordinate of upper-left corner
           int nTopRect, // y-coordinate of upper-left corner
           int nRightRect, // x-coordinate of lower-right corner
           int nBottomRect, // y-coordinate of lower-right corner
           int nWidthEllipse, // height of ellipse
           int nHeightEllipse // width of ellipse
        );
            
        CNUsuario P = new CNUsuario();
        public Panel pn;
        public CPModificarUsuario()
        {
            InitializeComponent();
            this.BorderStyle = BorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

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
                    MessageBox.Show("Ingrese Campo Cedula", "Sistema de SysLab", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch { }
        }

        private void CPModificarUsuario_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            pn.Controls.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                U.validar_campos(groupBox1);
                String Mensaje = "";
                P.Cedula = Convert.ToInt32(textBox1.Text);
                P.pregunta = comboBox1.Text;
                P.respuesta = textBox5.Text;
                P.pregunta1 = comboBox2.Text;
                P.respuesta1 = textBox6.Text;
                Mensaje = P.ModificarUsuario();
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            U.validar_Campo_num(e);
        }
    }
}
