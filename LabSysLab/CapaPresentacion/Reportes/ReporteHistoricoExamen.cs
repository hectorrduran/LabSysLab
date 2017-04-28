using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaPresentacion.Reportes;
namespace CapaPresentacion.Reportes
{
    public partial class ReporteHistoricoExamen : UserControl
    {
        public ReporteHistoricoExamen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReporteHstoricoExam frm = new ReporteHstoricoExam();
            frm.fecha = dateTimePicker2.Value.ToShortDateString();
            frm.fecha1 = dateTimePicker1.Value.ToShortDateString();
            frm.Show();

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
           
            
            

        }

        private void ReporteHistoricoExamen_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
