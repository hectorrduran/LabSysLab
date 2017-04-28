using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class CNPaciente
    {
        Manejador M = new Manejador();

        public int Cedula { get; set; }
        public string Nombre { get; set; }
        public String Apellido { get; set; }
        public int Edad { get; set; }
        public char Sexo { get; set; }
        public DateTime Fecha { get; set; }
        public string Direccion { get; set; }
        public String Telefono { get; set; }
        public string Correo { get; set; }


        public String RegistrarPaciente()
        {
            List<Parametros> lst = new List<Parametros>();
            String Mensaje = "";

            try
            {
                lst.Add(new Parametros("@Cedula ", Cedula));
                lst.Add(new Parametros("@Nombre", Nombre));
                lst.Add(new Parametros("@Apellido", Apellido));
                lst.Add(new Parametros("@Edad", Edad));
                lst.Add(new Parametros("@Sexo", Sexo));
                lst.Add(new Parametros("@Fecha", Fecha));
                lst.Add(new Parametros("@Direccion", Direccion));
                lst.Add(new Parametros("@Telefono", Telefono));
                lst.Add(new Parametros("@Correo", Correo));
                lst.Add(new Parametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("RegistrarPaciente", ref lst);
                Mensaje = lst[9].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }

        public String ModificarPaciente()
        {
            List<Parametros> lst = new List<Parametros>();
            String Mensaje = "";

            try
            {
                lst.Add(new Parametros("@Cedula ", Cedula));
                lst.Add(new Parametros("@Nombre", Nombre));
                lst.Add(new Parametros("@Apellido", Apellido));
                lst.Add(new Parametros("@Edad", Edad));
                lst.Add(new Parametros("@Sexo", Sexo));
                lst.Add(new Parametros("@Fecha", Fecha));
                lst.Add(new Parametros("@Direccion", Direccion));
                lst.Add(new Parametros("@Telefono", Telefono));
                lst.Add(new Parametros("@Correo", Correo));
                lst.Add(new Parametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("ModificarPaciente", ref lst);
                Mensaje = lst[9].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }

        public DataTable BusquedaPaciente()
        {

            List<Parametros> lst = new List<Parametros>();
            lst.Add(new Parametros("@Cedula ", Cedula));
            lst.Add(new Parametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
            return M.Listado("BuscarPaciente", lst);

        }

        public void validar_Campo_num(KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }


        public void validar_campos(GroupBox panel)
        {
            foreach (Control c in panel.Controls)
            {
                if (c is TextBox & c.Text.Trim() == "")
                {
                    MessageBox.Show("Faltan campos por Completar", "ITC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    throw new ArgumentNullException();

                }
            }
        }
    }
}
