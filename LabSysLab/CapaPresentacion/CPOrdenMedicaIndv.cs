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
    public partial class CPOrdenMedicaIndv : UserControl
    {
        public Panel pn;
        CNTest T = new CNTest();
        public int nro_ord=0;
        int a = 0;
        public CPOrdenMedicaIndv()
        {
            InitializeComponent();
        }

        private void CPOrdenMedicaIndv_Load(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table = T.MostrarOrdenExamen(nro_ord);
            foreach(DataRow row in table.Rows)
            {
                a = a + 1;
                DgvSubTest.Rows.Add(a, row[0]);
            }
            nro_orden.Text = nro_ord.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pn.Controls.Clear();
        }
    }
}
