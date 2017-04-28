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
    public partial class CPVerResultado : UserControl
    {
        public CNPaciente paciente;
        public Panel pn;
        CNTest T = new CNTest();
        public int NroOrden;
        public string Examen;
        public int nroExamen;

        public CPVerResultado()
        {
            InitializeComponent();
        }

        private void CPVerResultado_Load(object sender, EventArgs e)
        {
            int test = 0;
            label2.Text = "Nombre: " + paciente.Nombre;
            label3.Text = "Apellido: " + paciente.Apellido;
            label4.Text = "Fecha: " + DateTime.Now.ToLongDateString();
            label5.Text = "Tipo Examen: " + Examen;
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Font = new Font(DgvSubTest.Font, FontStyle.Bold);
            DataTable list = new DataTable();
            T.Id = nroExamen;
            list = T.MostrarItemExamen();
            foreach (DataRow row in list.Rows)
            {
                if (row[3] != null)
                    if (row[3].ToString().Length > 0)
                    {
                        if (Convert.ToInt32(row[0]) != test)
                        {
                            DgvSubTest.Rows.Add(row[0].ToString(), row[1].ToString());
                            DgvSubTest.Rows[DgvSubTest.Rows.Count - 1].DefaultCellStyle = style;
                            test = Convert.ToInt32(row[0]);
                            DgvSubTest.Rows[DgvSubTest.Rows.Count - 1].ReadOnly = true;
                        }
                        else
                        {
                            DgvSubTest.Rows.Add(row[3].ToString(), row[4].ToString(), "", "", row[5].ToString());
                        }

                    }
                    else
                    {
                        DgvSubTest.Rows.Add(row[0].ToString(), row[1].ToString(), "", "", row[2].ToString());
                    }
            }

                T.MostrarResultadoTest(nroExamen, NroOrden, DgvSubTest, textBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pn.Controls.Clear();
        }
    }
}
