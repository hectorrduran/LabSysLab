using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace CapaPresentacion.Reportes
{
    public partial class ReporteHstoricoExam : Form
    {
        public string fecha, fecha1;
        public ReporteHstoricoExam()
        {
            InitializeComponent();
        }

        private void ReporteHstoricoExam_Load(object sender, EventArgs e)
        {
            ReporteHistoricoExa aux = new ReporteHistoricoExa();
            aux.SetParameterValue("@fecha", Convert.ToDateTime(fecha));
            aux.SetParameterValue("@fecha2", Convert.ToDateTime(fecha1));

            crystalReportViewer1.ReportSource = aux;
        }
    }
}
