using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


namespace webbackend3.Modelos
{
    public class PersonaFisica 
    {

        public int IdPersonaFisica { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string RFC { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int UsuarioAgrega { get; set; }
        public bool Activo { get; set; }
        public int id { get; set; }
        public string mensaje { get; set; }

        private string Cadena = System.Configuration.ConfigurationManager.ConnectionStrings["CadConec"].ConnectionString;

        public PersonaFisica()
        {
        }

        public void InsertarPersona()
        {
            SqlConnection con = null;
            SqlTransaction transaction = null;
            DataTable datos = new DataTable();
            try {
                using (con = new SqlConnection(Cadena)) {
                    try {
                        con.Open();
                        string Sp = "sp_AgregarPersonaFisica";
                        transaction = con.BeginTransaction();
                        SqlCommand cmd = new SqlCommand(Sp, con, transaction);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.NVarChar, 50) { Value=this.Nombre,Direction = ParameterDirection.Input});
                        cmd.Parameters.Add(new SqlParameter("@ApellidoPaterno", SqlDbType.NVarChar, 50) { Value = this.ApellidoPaterno, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter("@ApellidoMaterno", SqlDbType.NVarChar, 50) { Value = this.ApellidoMaterno, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter("@RFC", SqlDbType.NVarChar, 13) { Value = this.RFC, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter("@FechaNacimiento", SqlDbType.DateTime) { Value = this.FechaNacimiento, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter("@UsuarioAgrega", SqlDbType.Int) { Value = this.UsuarioAgrega, Direction = ParameterDirection.Input });
                        //cmd.ExecuteNonQuery();
                        datos.Load(cmd.ExecuteReader());
                        transaction.Commit();
                        if (con.State == ConnectionState.Open)
                            con.Close();
                        this.id = Convert.ToInt32(datos.Rows[0][0].ToString());
                        this.mensaje = datos.Rows[0][1].ToString();
                    }catch(Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("ocurrio el siguiente error: " + ex.Message);
                    }
                }
            }
            catch(SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {

            }
        }

        public void ActualizarPersona()
        {
            SqlConnection con = null;
            SqlTransaction transaction = null;
            DataTable datos = new DataTable();
            try
            {
                using (con = new SqlConnection(Cadena))
                {
                    try
                    {
                        con.Open();
                        string Sp = "sp_ActualizarPersonaFisica";
                        transaction = con.BeginTransaction();
                        SqlCommand cmd = new SqlCommand(Sp, con, transaction);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@IdPersonaFisica", SqlDbType.Int) { Value = this.IdPersonaFisica, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.NVarChar, 50) { Value = this.Nombre, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter("@ApellidoPaterno", SqlDbType.NVarChar, 50) { Value = this.ApellidoPaterno, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter("@ApellidoMaterno", SqlDbType.NVarChar, 50) { Value = this.ApellidoMaterno, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter("@RFC", SqlDbType.NVarChar, 13) { Value = this.RFC, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter("@FechaNacimiento", SqlDbType.DateTime) { Value = this.FechaNacimiento, Direction = ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter("@UsuarioAgrega", SqlDbType.Int) { Value = this.UsuarioAgrega, Direction = ParameterDirection.Input });
                        //cmd.ExecuteNonQuery();
                        datos.Load(cmd.ExecuteReader());
                        transaction.Commit();
                        if (con.State == ConnectionState.Open)
                            con.Close();
                        this.id = Convert.ToInt32(datos.Rows[0][0].ToString());
                        this.mensaje = datos.Rows[0][1].ToString();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("ocurrio el siguiente error: " + ex.Message);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {

            }
        }

        public void EliminarPersona()
        {
            SqlConnection con = null;
            DataTable datos = new DataTable();
            try
            {
                using (con = new SqlConnection(Cadena))
                {
                    try
                    {
                        con.Open();
                        string Sp = "sp_EliminarPersonaFisica";
                        SqlCommand cmd = new SqlCommand(Sp, con);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@IdPersonaFisica", SqlDbType.Int) { Value = this.IdPersonaFisica, Direction = ParameterDirection.Input });
                        //cmd.ExecuteNonQuery();
                        datos.Load(cmd.ExecuteReader());
                        if (con.State == ConnectionState.Open)
                            con.Close();
                        this.id = Convert.ToInt32(datos.Rows[0][0].ToString());
                        this.mensaje = datos.Rows[0][1].ToString();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("ocurrio el siguiente error: " + ex.Message);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {

            }
        }
    }
}