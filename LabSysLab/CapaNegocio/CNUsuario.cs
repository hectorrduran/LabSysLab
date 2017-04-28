using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class CNUsuario
    {
        Manejador M = new Manejador();

        public int Cedula { get; set; }
        public string Usuario { get; set; }
        public String Contrasena { get; set; }
        public String pregunta { get; set; }

        public String respuesta { get; set; }
        public String pregunta1 { get; set; }

        public String respuesta1 { get; set; }

        public String RegistraUsuarios()
        {
            List<Parametros> lst = new List<Parametros>();
            String Mensaje = "";

            try
            {
                lst.Add(new Parametros("@Cedula ", Cedula));
                lst.Add(new Parametros("@Usuario", Usuario));
                lst.Add(new Parametros("@Contrasena", Contrasena));
                lst.Add(new Parametros("@pregunta", pregunta));
                lst.Add(new Parametros("@respuesta", respuesta));
                lst.Add(new Parametros("@pregunta1", pregunta1));
                lst.Add(new Parametros("@respuesta1", respuesta1));
                lst.Add(new Parametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("RegistrarUsuario", ref lst);
                Mensaje = lst[7].Valor.ToString();
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
            List<Parametros> lst = new List<Parametros>();
            try
            {
                lst.Add(new Parametros("@Datos", objDatos));
                dt = M.Listado("FiltrarDatosProducto", lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable IniciarSesion()
        {
            DataTable dt = new DataTable();
            List<Parametros> lst = new List<Parametros>();
            String Mensaje = "";
            try
            {
                lst.Add(new Parametros("@Usuario", Usuario));
                lst.Add(new Parametros("@Contrasena", Contrasena));
                lst.Add(new Parametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                dt = M.ListadoSet("IniciarSesion", ref lst);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.NewRow();
                    row["Usuario"] = lst[2].Valor.ToString();
                    row["Contrasena"] = "";
                    row["CedulaEmpleado"] = 0;
                    dt.Rows.InsertAt(row, 0);   
                }
                else
                {
                    dt.Columns.Add("Usuario", typeof(string));
                    DataRow row = dt.NewRow();
                    row["Usuario"] = lst[2].Valor.ToString();
                    dt.Rows.InsertAt(row, 0);
                }
             return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<string> RecuperarContrasena()
        {
            DataTable dt = new DataTable();
            List<string> datos = new List<string>();
            List<Parametros> lst = new List<Parametros>();
            try
            {
                lst.Add(new Parametros("@Usuario", Usuario));
                lst.Add(new Parametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                dt=M.Listado("RecuperarContrasena", lst);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        datos.Add(row["Usuario"].ToString());
                        datos.Add(row["pregunta"].ToString());
                        datos.Add(row["respuesta"].ToString());
                        datos.Add(row["pregunta2"].ToString());
                        datos.Add(row["respuesta2"].ToString());
                    }
                }

                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public String UpdatePassword()
        {
            List<Parametros> lst = new List<Parametros>();
            String Mensaje = "";
            try
            {
                lst.Add(new Parametros("@Usuario", Usuario));
                lst.Add(new Parametros("@Contraseña", Contrasena));
                lst.Add(new Parametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("updateContrasena", ref lst);
                return Mensaje = lst[2].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable BusquedaUsuario()
        {

            List<Parametros> lst = new List<Parametros>();
            lst.Add(new Parametros("@Cedula ", Cedula));
            lst.Add(new Parametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
            return M.Listado("BuscarUsuario", lst);

        }

        public String ModificarUsuario()
        {
            List<Parametros> lst = new List<Parametros>();
            String Mensaje = "";
          
            try
            {
                lst.Add(new Parametros("@Cedula ", Cedula));
                lst.Add(new Parametros("@pregunta", pregunta));
                lst.Add(new Parametros("@respuesta", respuesta));
                lst.Add(new Parametros("@pregunta1", pregunta1));
                lst.Add(new Parametros("@respuesta1", respuesta1));
                lst.Add(new Parametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("ModificarUsuario", ref lst);
                Mensaje = lst[5].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }
    }
}
