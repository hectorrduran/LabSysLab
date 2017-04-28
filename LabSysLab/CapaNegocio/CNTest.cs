using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
using System.Windows.Forms;

namespace CapaNegocio
{
   public class CNTest
    {
        Manejador M = new Manejador();

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Parametro { get; set; }
        public bool Alerta { get; set; }

        public string IngresarTest(DataTable dataTable)
        {
            List<Parametros> lst = new List<Parametros>();
            String Mensaje = "";

            try
            {
                lst.Add(new Parametros("@Nombre", Nombre));
                lst.Add(new Parametros("@Parametro", Parametro));
                lst.Add(new Parametros("@param", dataTable));
                lst.Add(new Parametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("IngresarTest", ref lst);
                Mensaje = lst[3].Valor.ToString(); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }

        public string IngresarExamen(DataTable dataTable)
        {
           
            List<Parametros> lst = new List<Parametros>();
            String Mensaje = "";

            try
            {
                lst.Add(new Parametros("@Nombre", Nombre));
                lst.Add(new Parametros("@alerta", Alerta.ToString()));
                lst.Add(new Parametros("@param", dataTable));
                lst.Add(new Parametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("IngresarExamen", ref lst);
                Mensaje = lst[3].Valor.ToString(); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }
        public DataTable MostrarTest()
        {
           
            DataTable dt = new DataTable();
            List<Parametros> lst = new List<Parametros>();
            try
            {
                dt = M.Listado("MostrarTest", lst);
                DataRow row = dt.NewRow();
                row["id"] = 0;
                row["Nombre"] = "-Seleccione-";
                dt.Rows.InsertAt(row,0);

            }

            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable MostrarTestExamen()
        {

            DataTable dt = new DataTable();
            List<Parametros> lst = new List<Parametros>();
            try
            {
                lst.Add(new Parametros("@examen", Id));
                lst.Add(new Parametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                dt = M.Listado("BuscarTestExamen", lst);

            }

            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable MostrarSubTest()
        {

            DataTable dt = new DataTable();
            List<Parametros> lst = new List<Parametros>();
            try
            {
                lst.Add(new Parametros("@test", Id));
                lst.Add(new Parametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                dt = M.Listado("BuscarSubTest", lst);

            }

            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable VerificarTestPaciente(int Id, int Cedula)
        {

            DataTable dt = new DataTable();
            List<Parametros> lst = new List<Parametros>();
            try
            {
                lst.Add(new Parametros("@nro", Id));
                lst.Add(new Parametros("@cedula", Cedula));
                lst.Add(new Parametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                dt = M.Listado("BuscarExamenRealizados", lst);
            }

            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable MostrarItemExamen()
        {

            DataTable dt = new DataTable();
            List<Parametros> lst = new List<Parametros>();
            try
            {
                lst.Add(new Parametros("@nro", Id));
                dt = M.Listado("BuscarExamenItem", lst);

            }

            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable MostrarExamenes()
        {

            DataTable dt = new DataTable();
            List<Parametros> lst = new List<Parametros>();
            try
            {
               
                dt = M.Listado("MostrarTExamen", lst);
                DataRow row = dt.NewRow();
                row["id"] = 0;
                row["Nombre"] = "-Seleccione-";
                dt.Rows.InsertAt(row, 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }


        public DataTable MostrarOrdenMedicas(int Cedula)
        {

            DataTable dt = new DataTable();
            List<Parametros> lst = new List<Parametros>();
            try
            {
                lst.Add(new Parametros("@cedula", Cedula));
                lst.Add(new Parametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                dt = M.Listado("BuscarOrdenMedica", lst);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        //
        public DataTable MostrarOrdenExamen(int nro)
        {

            DataTable dt = new DataTable();
            List<Parametros> lst = new List<Parametros>();
            try
            {
                lst.Add(new Parametros("@nro", nro));
                dt = M.Listado("BuscarOrdenExamen", lst);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public void MostrarResultadoTest(int nro, int orden, DataGridView tabla, TextBox caja)
        {

            DataTable dt = new DataTable();
            List<Parametros> lst = new List<Parametros>();
            try
            {
                lst.Add(new Parametros("@nro", nro));
                lst.Add(new Parametros("@nroOrden", orden));
                dt = M.Listado("MostarResultadoTest1", lst);

                foreach(DataRow row in dt.Rows)
                {
                    for(int a =0; a<tabla.RowCount;a++)
                    {
                        var test= row[1];
                        var resul = row[2];
                        if (tabla.Rows[a].Cells[0].Value.ToString()==Convert.ToString(test))
                        {
                            tabla.Rows[a].Cells[2].Value = resul;
                        }
                        caja.Text = row[0].ToString();
                    }
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        public DataTable MostrarExamenesResul(int nro)
        {

            DataTable dt = new DataTable();
            List<Parametros> lst = new List<Parametros>();
            try
            {
                lst.Add(new Parametros("@nro", nro));
                dt = M.Listado("BuscarExamenRes", lst);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public string IngresarOrdenExamen(DataTable dataTable, DateTime fecha, params int[] datos)
        {

            List<Parametros> lst = new List<Parametros>();
            String Mensaje = "";

            try
            {
                lst.Add(new Parametros("@nro_orden", datos[0]));
                lst.Add(new Parametros("@p_cedula", datos[1]));
                lst.Add(new Parametros("@e_cedula", datos[2]));
                lst.Add(new Parametros("@fecha", fecha));
                lst.Add(new Parametros("@param", dataTable));
                lst.Add(new Parametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("IngresarOrden", ref lst);
                Mensaje = lst[5].Valor.ToString(); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }

        public string IngresarResultados(DataGridView grid, params string[] datos)
        {


            var dataTable1 = new DataTable();
            dataTable1.Columns.Add("id", typeof(int));
            dataTable1.Columns.Add("resultado", typeof(string));
            for (int a = 0; a < grid.RowCount; a++)
            {
                if (grid.Rows[a].Cells[2].Value!= null)
                {
                    if (grid.Rows[a].Cells[2].Value.ToString() != "")
                    {
                        dataTable1.Rows.Add(grid.Rows[a].Cells[0].Value, grid.Rows[a].Cells[2].Value);
                    }
                }
            }

            List<Parametros> lst = new List<Parametros>();
            string Mensaje = "";
            DateTime fecha = DateTime.Now.Date;
            try
            {
                lst.Add(new Parametros("@nro_orden", Convert.ToInt32(datos[0])));
                lst.Add(new Parametros("@nro_Examen", Convert.ToInt32(datos[1])));
                lst.Add(new Parametros("@resultado", datos[2]));
                lst.Add(new Parametros("@fecha", fecha));
                lst.Add(new Parametros("@param", dataTable1));
                lst.Add(new Parametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("IngresarResultados", ref lst);
                Mensaje = lst[5].Valor.ToString(); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }

        public string ModificarOrdenExamen(DataTable datatable, int nro)
        {

            List<Parametros> lst = new List<Parametros>();
            String Mensaje = "";

            try
            {
                lst.Add(new Parametros("@Nro", nro));
                lst.Add(new Parametros("@param", datatable));
                lst.Add(new Parametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("ModificarOrdenMedica", ref lst);
                Mensaje = lst[2].Valor.ToString(); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }

        public string ModificarTestExamen(DataTable datatable)
        {

            List<Parametros> lst = new List<Parametros>();
            String Mensaje = "";

            try
            {
                lst.Add(new Parametros("@Nro", Id));
                lst.Add(new Parametros("@alerta", Alerta.ToString()));
                lst.Add(new Parametros("@param", datatable));
                lst.Add(new Parametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("ModificarExamen", ref lst);
                Mensaje = lst[3].Valor.ToString(); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }

        public string ModificarSubTest(DataTable datatable)
        {

            List<Parametros> lst = new List<Parametros>();
            String Mensaje = "";

            try
            {
                lst.Add(new Parametros("@Nro", Id));
                lst.Add(new Parametros("@parametro", Parametro));
                lst.Add(new Parametros("@param", datatable));
                lst.Add(new Parametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("ModificarTest", ref lst);
                Mensaje = lst[3].Valor.ToString(); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }
    }
}
