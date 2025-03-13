using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;

namespace LN
{
    public class csConexion
    {
        public static string Cadena = "";
        public static SqlConnection SqlCnn;
        public static OdbcConnection HanaCnn;

        public static void IniciarConexionHANA(string servidor, string user, string pw, string bd)
        {
            try
            {
                Cadena = "DRIVER={HDBODBC};UID=" + user + ";PWD=" + pw + ";SERVERNODE=" + servidor + ";CS=" + bd;

                HanaCnn = new OdbcConnection(Cadena);

                try
                {
                    HanaCnn.Open();

                    if(HanaCnn.State.Equals(0))
                    {
                        throw new Exception("ERROR DE CONEXION HANA");
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void IniciarConexionSQL(string servidor, string user, string pw, string bd)
        {
            try
            {
                Cadena = "Data Source=" + servidor + ";initial catalog=" + bd + ";user id=" + user + ";password=" + pw;

                SqlCnn = new SqlConnection(Cadena);

                try
                { 
                    SqlCnn.Open();

                    if (SqlCnn.State.Equals(0))
                    {
                        throw new Exception("ERROR DE CONEXION HANA");
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable EjecutarSQL(string query)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(query, SqlCnn);

                SqlDataAdapter dad = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                dad.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable EjecutarHANA(string query)
        {
            try
            {
                OdbcCommand cmd = new OdbcCommand(query, HanaCnn);

                OdbcDataAdapter dad = new OdbcDataAdapter(cmd);

                DataTable dt = new DataTable();
                dad.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex; 
            }
        }
    }
}
