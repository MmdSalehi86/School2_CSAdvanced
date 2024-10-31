using System;
using System.Data.SqlClient;
using System.Data;

namespace School.DataAccess
{
    public class DbSqlCommands
    {
        protected int ExcuteProc(string proc, SqlParameter[] ps = null)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(Connections.SchoolCS))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = con,
                    CommandText = proc,
                    CommandType = CommandType.StoredProcedure
                };
                if (ps != null)
                {
                    foreach (var p in ps)
                    {
                        cmd.Parameters.Add(p);
                    }
                }
                try
                {
                    con.Open();
                    result = cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    ex.AddLog();
                    throw;
                }
            }
            return result;
        }

        protected DataTable SelectDataTable(string procName, SqlParameter[] ps = null)
        {
            DataTable dataTable = null;
            using (SqlConnection con = new SqlConnection(Connections.SchoolCS))
            {
                dataTable = new DataTable();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = con,
                    CommandText = procName,
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);

                try
                {
                    con.Open();
                    sqlDataAdapter.Fill(dataTable);
                    con.Close();
                }
                catch (Exception ex)
                {
                    ex.AddLog();
                    throw;
                }
            }
            return dataTable;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="funcName">must have schema</param>
        /// <param name="ps"></param>
        /// <returns></returns>
        protected T SelectFunc<T>(string funcName, SqlParameter[] ps = null)
        {
            SqlConnection con = new SqlConnection(Connections.SchoolCS);
            SqlCommand cmd = new SqlCommand();
            string commandText = "select " + funcName + "(";
            if (ps != null)
            {
                foreach (var p in ps)
                {
                    cmd.Parameters.Add(p);
                    commandText += p.ParameterName + ",";
                }
            }
            commandText = commandText.Remove(commandText.Length - 1, 1);
            commandText += ")";
            cmd.Connection = con;
            cmd.CommandText = commandText;

            T result;
            try
            {
                con.Open();
                result = (T)cmd.ExecuteScalar();
                con.Close();
            }
            catch (Exception ex)
            {
                ex.AddLog();
                throw;
            }

            return result;
        }
    }
}
