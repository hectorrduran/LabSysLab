using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaPresentacion.Reportes;
namespace CapaPresentacion
{
    public partial class CPMenuPrincipal : Form
    {
        public UserControl obj = new UserControl();
        public int usuario;
        public string nombre;
        public CPMenuPrincipal()
        {
            InitializeComponent();
        }

        public void cambiodepantalla(UserControl frm)
        {
            panel1.Controls.Clear();
            frm.Top = (panel1.Height - frm.Height) / 2;
            frm.Left = (panel1.Width - frm.Width) / 2;
            panel1.Controls.Add(frm);

        }

        public void cambiodepantalla2(UserControl frm, Panel panel)
        {

            panel1.Controls.Clear();
            frm.Top = (panel1.Height - frm.Height) / 2;
            frm.Left = (panel1.Width - frm.Width) / 2;
            panel.Controls.Add(frm);
            

        }

        private void ingresarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CPIngresarUsuarioC form = new CPIngresarUsuarioC();
            form.pn = panel1;
            obj = form;
            cambiodepantalla(obj);
        }

        private void CPMenuPrincipal_Load(object sender, EventArgs e)
        {
            toolStripLabel1.Text = nombre;
            toolStripLabel2.Text = DateTime.Now.ToLongDateString();
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CPModificarUsuario form = new CPModificarUsuario();
            form.pn = panel1;
            obj = form;
            cambiodepantalla(obj);
        }

        private void ingresraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CPResulExamen form = new CPResulExamen();
            form.panel = panel1;
            form.pn = panel1;
            obj = form;
            cambiodepantalla(obj);

        }

        private void respaldoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void modificarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CPModificarEmpleadoC form = new CPModificarEmpleadoC();
            form.pn = panel1;
            obj = form;
            cambiodepantalla(obj);
        }

        private void consultarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CPConsultarEmpleadoC form = new CPConsultarEmpleadoC();
            form.pn = panel1;
            obj = form;
            cambiodepantalla(obj);
        }

        private void ingresarToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            CPIngresarEmpleadoC form = new CPIngresarEmpleadoC();
            form.pn = panel1;
            obj = form;
            cambiodepantalla(obj);
        }

        private void ingresarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            CPIngresarPacienteC form = new CPIngresarPacienteC();
            form.pn = panel1;
            obj = form;
            cambiodepantalla(obj);
        }

        private void modificarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            CPModificarPacienteC form = new CPModificarPacienteC();
            form.pn = panel1;
            obj = form;
            cambiodepantalla(obj);
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CPConsultarPacienteC form = new CPConsultarPacienteC();
            form.pn = panel1;
            obj = form;
            cambiodepantalla(obj);
        }

        private void CPMenuPrincipal_Resize(object sender, EventArgs e)
        {
            cambiodepantalla(obj);
        }

        private void ingresarToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            CPTest form = new CPTest();
            form.pn = panel1;
            obj = form;
            cambiodepantalla(obj);
        }

        private void ingresarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            CPTipo_Examen form = new CPTipo_Examen();
            form.pn = panel1;
            obj = form;
            cambiodepantalla(obj);
        }

        private void ingresarToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            CPIngresarOrdenMedica form = new CPIngresarOrdenMedica();
            form.usuario = usuario;
            form.pn = panel1;
            obj = form;
            cambiodepantalla(obj);
        }

        private void consultarToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            CPConsultaOrdenMedica form = new CPConsultaOrdenMedica(panel1);
            form.pn = panel1;
            obj = form;
            cambiodepantalla(obj);
        }

        private void modificarToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            CPModificarOrdenMedica form = new CPModificarOrdenMedica();
            form.pn = panel1;
            obj = form;
            cambiodepantalla(obj);
        }

        private void modificarToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            CPModificarExamen form = new CPModificarExamen();
            form.pn = panel1;
            obj = form;
            cambiodepantalla(obj);
        }

        private void modificarToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            CPModificarTest form = new CPModificarTest();
            form.pn = panel1;
            obj = form;
            cambiodepantalla(obj);
        }

        private void consultarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            CPConsultarUsuario form = new CPConsultarUsuario();
            form.pn = panel1;
            obj = form;
            cambiodepantalla(obj);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
         
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void consultarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ConsultaExamenNum form = new ConsultaExamenNum();
            form.panel = panel1;
            form.pn = panel1;
            obj = form;
            cambiodepantalla(obj);
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pruebaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteHistoricoExamen form = new ReporteHistoricoExamen();
            obj = form;
            cambiodepantalla(obj);
        }

        private void reporte2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteHistPersona form = new ReporteHistPersona();
            obj = form;
            cambiodepantalla(obj);
        }

        private void graficosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerGrafico form = new VerGrafico();
            obj = form;
            cambiodepantalla(obj);
        }

        private void examenesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
