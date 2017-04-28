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
    public partial class CPIngresarResultados : UserControl
    {
        public CNPaciente paciente;
        CNTest T = new CNTest();
        public int NroOrden;
        public string Examen;
        public int nroExamen;
        public Panel pn;
        public CPIngresarResultados()
        {
            InitializeComponent();
        }

        private void CPIngresarResultados_Load(object sender, EventArgs e)
        {
            int test=0;
            label2.Text = "Nombre: " + paciente.Nombre;
            label3.Text = "Apellido: " + paciente.Apellido;
            label4.Text = "Fecha: " + DateTime.Now.ToLongDateString();
            label5.Text = "Tipo Examen: " + Examen;
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Font = new Font(DgvSubTest.Font, FontStyle.Bold);
            DataTable list = new DataTable();
            T.Id = nroExamen;
            list = T.MostrarItemExamen();
            foreach(DataRow row in list.Rows)
            {
                if(row[3]!=null)
                    if(row[3].ToString().Length>0)
                {
                    if (Convert.ToInt32(row[0]) != test)
                    {
                        DgvSubTest.Rows.Add(row[0].ToString(),row[1].ToString());
                        DgvSubTest.Rows[DgvSubTest.Rows.Count-1].DefaultCellStyle = style;
                        test = Convert.ToInt32(row[0]);
                        DgvSubTest.Rows[DgvSubTest.Rows.Count - 1].ReadOnly = true;
                    }
                    else
                    {
                        DgvSubTest.Rows.Add(row[3].ToString(),row[4].ToString(),"","", row[5].ToString());
                    }
                  
                }
                else
                {
                    DgvSubTest.Rows.Add(row[0].ToString(), row[1].ToString(),"","", row[2].ToString());
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string Mensaje = "";
                Mensaje = T.IngresarResultados(DgvSubTest, NroOrden.ToString(), nroExamen.ToString(), textBox1.Text);
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
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pn.Controls.Clear();
        }
    }
}
