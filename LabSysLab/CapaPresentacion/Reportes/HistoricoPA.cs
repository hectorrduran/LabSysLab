using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Reportes
{
    public partial class HistoricoPA : Form
    {
        public string fecha, fecha1;
        public HistoricoPA()
        {
            InitializeComponent();
        }

        private void HistoricoPA_Load(object sender, EventArgs e)
        {
            HistoricoPaciente aux = new HistoricoPaciente();
            aux.SetParameterValue("@fecha", Convert.ToDateTime(fecha));
            aux.SetParameterValue("@fecha2", Convert.ToDateTime(fecha1));
            crystalReportViewer1.ReportSource = aux;
        }
    }
}
