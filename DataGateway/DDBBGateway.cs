using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataGateway
{
    public class DDBBGateway
    {
        private SqlConnection connection = new SqlConnection();
        private SqlCommand command = new SqlCommand();
        private SqlDataReader reader;
        private int affectedRows;

        private string connectionString;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public DDBBGateway()
        {
            // ---------------------------- Desktop-PC ----------------------------
            // connectionString = "data source=DESKTOP-BA6HNP1\\SQLEXPRESS01; integrated security=sspi; initial catalog=EasyFitness;";
            // ---------------------------- Notebook-PC ----------------------------
            connectionString = "data source=DESKTOP-SI2UFE1\\SQLEXPRESS; integrated security=sspi; initial catalog=EasyFitness;";

            connection.ConnectionString = connectionString;
            command.Connection = connection;
            command.Parameters.Clear();
            affectedRows = 0;
        }

        /// <summary>
        /// Devuelve un Int32 con la cantidad de registros afectados luego del sendStatement()
        /// </summary>
        public int getAffectedRows()
        {
            return affectedRows;
        }

        /// <summary>
        /// Obtiene el SqlDataReader luego de ejecutado el sendQuery
        /// </summary>
        public SqlDataReader getReader()
        {
            return reader;
        }

        /// <summary>
        /// Prepara la query que se pasa por parámetro. Se debe ejecutar previo al sendQuery()
        /// </summary>
        public void prepareQuery(string query)
        {
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = query;
        }

        /// <summary>
        /// Prepara la sentencia que se pasa por parámetro. Se debe ejecutar previo al sendStatement()
        /// </summary>
        public void prepareStatement(string statement)
        {
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = statement;
        }

        /// <summary>
        /// Agrega el valor value al parámetro name
        /// </summary>
        public void addParameter(object name, object value)
        {
            try
            {
                command.Parameters.AddWithValue(name.ToString(), value.ToString());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Envía la query a la DDBB. Posterior a prepareQuery().
        /// </summary>
        public void sendQuery()
        {
            try
            {
                connection.Open();
                reader = command.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Envía la query a la DDBB de modo scalar. Posterior a prepareQuery().
        /// </summary>
        public int sendScalarQuery()
        {
            try
            {
                connection.Open();
                return (int)command.ExecuteScalar();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Envía la sentencia a la DDBB. Posterior a prepareStatement().
        /// </summary>
        public void sendStatement()
        {
            try
            {
                connection.Open();
                affectedRows = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Libera la conexión contra la DDBB
        /// </summary>
        public void closeConnection()
        {
            try
            {
                if (reader != null && !reader.IsClosed)
                {
                    reader.Close();
                }
                connection.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
