using System;
using System.Data.SqlClient;

namespace Negocio
{
    public class AccesoBD
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;
        private SqlTransaction transaccion;

        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public AccesoBD()
        {
            conexion = new SqlConnection("server=(local)\\SQLEXPRESS; database=TPC_DB; integrated security=true");
            comando = new SqlCommand();
        }

        public void setearQuery(string query)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = query;
        }

        public void setearParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        public void iniciarLectura()
        {
            comando.Connection = conexion;
            conexion.Open();
            lector = comando.ExecuteReader();
        }

        public void ejecutarLectura()
        {
            iniciarLectura();
        }

        public void ejecutarAccion()
        {
            comando.Connection = conexion;
            conexion.Open();
            comando.ExecuteNonQuery();
        }

        public object ejecutarScalar()
        {
            return comando.ExecuteScalar();
        }

        public void cerrarLector()
        {
            if (lector != null)
                lector.Close();
        }

        public void cerrarConexion()
        {
            if (conexion.State == System.Data.ConnectionState.Open)
                conexion.Close();

            comando.Parameters.Clear();
        }


        public void iniciarTransaccion()
        {
            conexion.Open();
            transaccion = conexion.BeginTransaction();
            comando.Connection = conexion;
            comando.Transaction = transaccion;
        }

        public void commitTransaccion()
        {
            transaccion.Commit();
        }

        public void rollbackTransaccion()
        {
            transaccion.Rollback();
        }
    }
}
