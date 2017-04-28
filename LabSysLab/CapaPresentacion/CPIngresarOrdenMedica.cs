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
    public partial class CPIngresarOrdenMedica : UserControl
    {
        Utilidades U = new Utilidades();
        CNPaciente P = new CNPaciente();
        CNTest T = new CNTest();
        public Panel pn;
        public int usuario;
        public CPIngresarOrdenMedica()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    DataTable dt = new DataTable();
                    P.Cedula = Convert.ToInt32(textBox1.Text);
                    dt = P.BusquedaPaciente();
                    try
                    {
                        textBox2.Text = dt.Rows[0][1].ToString();
                        textBox3.Text = dt.Rows[0][2].ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Paciente no se encuentra Registrado");
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese Campo Cedula");
                }
            }
            catch { }
        }

        private void CPIngresarOrdenMedica_Load(object sender, EventArgs e)
        {
           
            nro_orden.Text = DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            DataTable dt = new DataTable();
            dt = T.MostrarExamenes();
            if (dt.Rows.Count > 0)
            {
                comboBox1.ValueMember = "id";
                comboBox1.DisplayMember = "Nombre";
                comboBox1.DataSource = dt;
            }
            else { comboBox1.Text = "No Disponible"; }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = T.VerificarTestPaciente(Convert.ToInt32(comboBox1.SelectedValue), Convert.ToInt32(textBox1.Text));
            if (dt.Rows.Count > 0)
            {
                if (MessageBox.Show("El Paciente tiene un test igual en Fecha"+ Convert.ToDateTime(dt.Rows[0][1].ToString()).ToShortDateString() +" con Nro de Orden: "+ dt.Rows[0][0].ToString(), "Ingresar Test", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ingresarTestTabla();
                }
                
            }
            else
            {
                ingresarTestTabla();
            }
        }

        public void ingresarTestTabla()
        {
            bool bandera = false;
            for (int rows = 0; rows < DgvSubTest.RowCount; rows++)
            {
                if (Convert.ToInt32(DgvSubTest.Rows[rows].Cells[0].Value) == Convert.ToInt32(comboBox1.SelectedValue))
                {
                    MessageBox.Show("Examen se Encuentra Agregado");
                    bandera = true;
                    break;
                }
            }
            if (bandera == false)
                DgvSubTest.Rows.Add(comboBox1.SelectedValue, comboBox1.Text);
        }
        private void DgvSubTest_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DgvSubTest.Rows.RemoveAt(DgvSubTest.CurrentRow.Index);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvSubTest.RowCount > 0)
                {
                    String Mensaje = "";
                    var dataTable = new DataTable();
                    dataTable.Columns.Add("id_examen", typeof(string));
                    for (int a = 0; a < DgvSubTest.RowCount; a++)
                    {
                        dataTable.Rows.Add(DgvSubTest.Rows[a].Cells[0].Value);
                    }

                    Mensaje = T.IngresarOrdenExamen(dataTable, DateTime.Now.Date, Convert.ToInt32(nro_orden.Text), Convert.ToInt32(textBox1.Text), usuario);
                    if (Mensaje == "Registrado Correctamente.")
                    {
                        MessageBox.Show(Mensaje, "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        pn.Controls.Clear();
                    }
                    else
                    {
                        MessageBox.Show(Mensaje, "Sistema de SysLab", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                else
                {
                    MessageBox.Show("Ingrese Examenes para la Orden", "Sistema de SysLab", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch {

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            pn.Controls.Clear();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            U.validar_Campo_num(e);
        }
    }
}
