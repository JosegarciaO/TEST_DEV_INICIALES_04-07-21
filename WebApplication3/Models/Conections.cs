using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace webbackend3.Modelos
{
    public class Conections
    {
       private string cadena = System.Configuration.ConfigurationManager.ConnectionStrings["CadConec"].ConnectionString;

        private SqlConnection cn;

        public  Conections()
        {
            try
            {
                cn = new SqlConnection(cadena);
                if(cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
            }catch(SqlException sqexc)
            {
                throw new Exception("Error de conexion--- no fue posible establecer una conexion."+
                                    "Revise la Cadena de conexion :"+sqexc.Message);
            }
            
        }

        public void cerrarCon()
        {
            if (cn.State == ConnectionState.Closed)
                cn.Close();
        }

        public DataTable getDataTable(string qry, SqlParameterCollection parametros)
        {
            DataTable dt = null;
            try
            {
                dt = new DataTable();
                SqlTransaction transaction = cn.BeginTransaction();
                dt = GetDatos(qry,parametros,transaction);
            }catch(SqlException exsq)
            {
                throw new Exception("Ocurrio un error al obtener la informacion. " + exsq.Message);
            }
            return dt;
        }


        private DataTable GetDatos(string query,SqlParameterCollection param, SqlTransaction tran)
        {
            DataTable datos;
            try
            {
                SqlCommand comand = new SqlCommand(query, cn, tran);
                comand.Parameters.Add(param);
                datos = new DataTable();
                datos.Clear();
                datos.Load(comand.ExecuteReader());
            }catch(SqlException exSq)
            {
                throw new Exception("Ocurrio un error al obtener los datos." + exSq.Message);
            }
            finally
            {
                cn.Close();
            }
            return datos;
        }
    }
}