using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;
using System.Text.RegularExpressions;

namespace CapaNegocio
{
    public class CNEmpleado
    {

        Manejador M = new Manejador();

        public int Cedula { get; set; }
        public string Nombre { get; set; }
        public String Apellido { get; set; }
        public String Correo { get; set; }
        public String Telefono { get; set; }
        public string Cargo { get; set; }
       

        public String RegistrarProductos()
        {
            List<Parametros> lst = new List<Parametros>();
            String Mensaje = "";

            try
            {
                lst.Add(new Parametros("@Cedula ", Cedula));
                lst.Add(new Parametros("@Nombre", Nombre));
                lst.Add(new Parametros("@Apellido", Apellido));
                lst.Add(new Parametros("@Correo", Correo));
                lst.Add(new Parametros("@Telefono", Telefono));
                lst.Add(new Parametros("@Cargo", Cargo));
                lst.Add(new Parametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("RegistrarEmpleado", ref lst);
                Mensaje = lst[6].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }

       

        public String ModificarEmpleado()
        {
            List<Parametros> lst = new List<Parametros>();
            String Mensaje = "";

            try
            {
                lst.Add(new Parametros("@Cedula ", Cedula));
                lst.Add(new Parametros("@Nombre", Nombre));
                lst.Add(new Parametros("@Apellido", Apellido));
                lst.Add(new Parametros("@Correo", Correo));
                lst.Add(new Parametros("@Telefono", Telefono));
                lst.Add(new Parametros("@Cargo", Cargo));
                lst.Add(new Parametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("ModificarEmpleado", ref lst);
                Mensaje = lst[6].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }

        public DataTable BusquedaProductos(String objDatos)
        {
            DataTable dt = new DataTable();
            string mensaje="";
            List<Parametros> lst = new List<Parametros>();
            try
            {
                lst.Add(new Parametros("@Datos", objDatos));
                lst.Add(new Parametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                dt = M.Listado("FiltrarDatosProducto", lst);
                mensaje = lst[1].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable ListarEmpleado()
        {
         
            List<Parametros> lst = new List<Parametros>();
            lst.Add(new Parametros("@Cedula ", Cedula));
            lst.Add(new Parametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
            return M.Listado("BuscarEmpleado", lst);
            
        }

    }
}
