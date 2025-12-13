using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace ClinicalExamination.Classes
{
    internal class DBWorker
    {
        static private SqlConnection connection;
        public DBWorker(string connection_string)
        {
            connection = new SqlConnection(connection_string);
        }

        public string ExecStorageProcedure(string name_procedure, int answer_size = 1)
        {
            string answer = string.Empty;
            SqlCommand command = new SqlCommand(name_procedure, connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlParameter result = new SqlParameter
            {
                ParameterName = "@result",
                SqlDbType = SqlDbType.NVarChar,
                Size = answer_size,
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(result);
            connection.Open();
            try
            {
                int count_row = command.ExecuteNonQuery();
                answer = command.Parameters["@result"].Value.ToString() + ((count_row < 0) ? "" : count_row.ToString());
            }
            catch (Exception ex)
            {
                answer = ex.Message;
            }
            finally
            { 
                connection.Close();
            }
            return answer;
        }
    }
}
