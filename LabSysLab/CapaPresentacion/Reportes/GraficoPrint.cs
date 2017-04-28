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
    public partial class GraficoPrint : Form
    {
        public string fecha, fecha1;
        public GraficoPrint()
        {
            InitializeComponent();
        }

        private void GraficoPrint_Load(object sender, EventArgs e)
        {
            Grafico aux = new Grafico();
            aux.SetParameterValue("@fecha", Convert.ToDateTime(fecha));
            aux.SetParameterValue("@fecha2", Convert.ToDateTime(fecha1));

            crystalReportViewer1.ReportSource = aux;
        }
    }
}
