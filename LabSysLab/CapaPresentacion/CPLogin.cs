using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using System.Threading;

namespace CapaPresentacion
{
    public partial class CPLogin : Form
    {
        DataTable usuario = new DataTable();
        CNUsuario U = new CNUsuario();
        List<string> datos = new List<string>();
        public CPLogin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CPLogin_Load(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
            if (textBox1.Text.Trim() != "")
            {
                if (textBox2.Text.Trim() != "")
                {
                    String Mensaje = "";
                    U.Usuario = textBox1.Text;
                    U.Contrasena = textBox2.Text;
                    usuario = U.IniciarSesion();
                    if (usuario.Rows[0][0].ToString() == "Su Contraseña es Incorrecta.")
                    {
                       MessageBox.Show(usuario.Rows[0][0].ToString(), "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        textBox2.Clear();
                        textBox2.Focus();
                    }
                    else
                        if (usuario.Rows[0][0].ToString() == "El Nombre de Usuario no Existe.")
                    {
                        MessageBox.Show(usuario.Rows[0][0].ToString(), "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox1.Focus();
                    }
                    else
                    {
                        MessageBox.Show(usuario.Rows[0][0].ToString(), "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        Thread NuevoHilo = new System.Threading.Thread(new System.Threading.ThreadStart(runprincipal));
                        this.Close();
                        NuevoHilo.SetApartmentState(System.Threading.ApartmentState.STA);
                        NuevoHilo.Start();
                    }
                }
                else
                {
                   MessageBox.Show("Por Favor Ingrese su Contraseña.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox2.Focus();
                }
            }
            else
            {
                MessageBox.Show("Por Favor Ingrese Nombre de Usuario.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }
        }

        private void runprincipal()
        {
            CPMenuPrincipal frm = new CPMenuPrincipal();
            frm.usuario = Convert.ToInt32(usuario.Rows[1][2]);
            frm.nombre = usuario.Rows[0][0].ToString();
            frm.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            groupBox1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            U.Usuario = textBox3.Text;
            datos = U.RecuperarContrasena();
            if (datos.Count < 1)
            {
                MessageBox.Show("Usuario No se Encuentra Registrado");
            }
            else
            {
                groupBox2.Visible = false;
                groupBox3.Visible = true;
                textBox4.Text = datos[1];
                textBox6.Text = datos[3];
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (datos[2]==textBox5.Text && datos[4]==textBox7.Text)
            {
                groupBox4.Visible = true;
                groupBox3.Visible = false;

            }
            else
            {
                MessageBox.Show("Algunas Respuestas son incorrectas");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
            if (textBox10.Text == textBox11.Text)
            {
                string Mensaje;
                U.Usuario = datos[0];
                U.Contrasena = textBox10.Text;
                Mensaje=U.UpdatePassword();
                MessageBox.Show(Mensaje);
            }
            else
            {
                MessageBox.Show("Las contraseñas no son iguales");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox4.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox3.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox2.Visible = false;
        }
    }
}
