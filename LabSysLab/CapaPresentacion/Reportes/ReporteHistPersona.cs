using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Reportes
{
    public partial class ReporteHistPersona : UserControl
    {
        public ReporteHistPersona()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            HistoricoPA frm = new HistoricoPA();
            frm.fecha = dateTimePicker2.Value.ToShortDateString();
            frm.fecha1 = dateTimePicker1.Value.ToShortDateString();
            frm.Show();
        }
    }
}
