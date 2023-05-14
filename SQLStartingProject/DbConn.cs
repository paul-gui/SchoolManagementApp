using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLStartingProject
{
	public static class DbConn
	{
		private static readonly ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["connStr"];
		public static SqlConnection sqlConnection = new SqlConnection(settings.ConnectionString);
		static SqlCommand cmd;
		static SqlDataReader dataReader;
		public static int UserID { get; set; }
		public static int RoleID { get; set; }

        #region InsertData Method
        /// <summary>
        /// Inserts data into SQL database using the specified parameters. Parameter naming rule: @[index]
        /// </summary>
        /// <param name="sql">SQL command</param>
        /// <param name="parameterCount">number of parameters</param>
        /// <param name="parameters">list containing the parameters to be used</param>
        /// <returns>ID of the inserted entry</returns>
        public static int InsertData(string sql, int parameterCount, List<object> parameters)
        {
			try
			{
				if (sqlConnection.State != ConnectionState.Open)
				{
					sqlConnection.Open();
				}
				string parameterName;
				cmd = new SqlCommand
				{
					CommandType = CommandType.Text,
					CommandText = sql,
					Connection = sqlConnection,
				};
				for (int i = 0; i < parameterCount; i++)
				{
					parameterName = $"@{i}";
					cmd.Parameters.AddWithValue(parameterName, parameters[i]);
				}
				int id = (int)cmd.ExecuteScalar();
				return id;
			}
			catch (Exception ex)
            {
				throw ex;
            }
        }

		public static void InsertAverageData(string sql, int parameterCount, List<object> parameters)
		{
			try
			{
				if (sqlConnection.State != ConnectionState.Open)
				{
					sqlConnection.Open();
				}
				string parameterName;
				cmd = new SqlCommand
				{
					CommandType = CommandType.Text,
					CommandText = sql,
					Connection = sqlConnection,
				};
				for (int i = 0; i < parameterCount; i++)
				{
					parameterName = $"@{i}";
					cmd.Parameters.AddWithValue(parameterName, parameters[i]);
				}
				int id = (int)cmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		public static void ExecuteStoredProcedure(string sql)
		{
			try
            {
				if (sqlConnection.State != ConnectionState.Open)
				{
					sqlConnection.Open();
				}
				cmd = new SqlCommand
				{
					CommandType = CommandType.Text,
					CommandText = sql,
					Connection = sqlConnection
				};
				cmd.ExecuteNonQuery();
			}
			catch
            {
				throw;
            }
		}

		#region GetData Methods
		/// <summary>
		/// Gets data from SQL database using the specified parameters. Parameter naming rule: @[index]
		/// </summary>
		/// <param name="sql">SQL command</param>
		/// <param name="parameterCount">number of parameters</param>
		/// <param name="parameters">list containing the parameters to be used</param>
		/// <returns>DataTable containing the data</returns>
		public static DataTable GetData(string sql, int parameterCount, List<object> parameters)
        {
			try
			{
				if (sqlConnection.State != ConnectionState.Open)
				{
					sqlConnection.Open();
				}
				string parameterName;
				cmd = new SqlCommand
				{
					CommandType = CommandType.Text,
					CommandText = sql,
					Connection = sqlConnection
				};
				for (int i = 0; i < parameterCount; i++)
				{
					parameterName = $"@{i}";
					cmd.Parameters.AddWithValue(parameterName, parameters[i]);
				}
				dataReader = cmd.ExecuteReader();
				DataTable dt = new DataTable();
				dt.Load(dataReader);
				return dt;
			}
			catch(Exception ex)
            {
				throw ex;
            }
		}

		/// <summary>
		/// Gets data from SQL database.
		/// </summary>
		/// <param name="sql">SQL command</param>
		/// <returns>DataTable containing the data</returns>
		/// 
		public static DataTable GetData(string sql)
        {
			try
			{
				if (sqlConnection.State != ConnectionState.Open)
				{
					sqlConnection.Open();
				}
				cmd = new SqlCommand
				{
					CommandType = CommandType.Text,
					CommandText = sql,
					Connection = sqlConnection
				};
				dataReader = cmd.ExecuteReader();
				DataTable dt = new DataTable();
				dt.Clear();
				dt.Load(dataReader);
				return dt;
			}
			catch(Exception ex)
            {
				throw ex;
            }
		}
        #endregion

        #region UpdateData Method
        /// <summary>
        /// Updates data in SQL database with the specified parameters. Parameter naming rule: @[index]
        /// </summary>
        /// <param name="sql">SQL command</param>
        /// <param name="parameterCount">number of parameters</param>
        /// <param name="parameters">list containing the parameters to be used</param>
        public static void UpdateData(string sql, int parameterCount, List<object> parameters)
        {
			try
			{
				if (sqlConnection.State != ConnectionState.Open)
				{
					sqlConnection.Open();
				}
				string parameterName;
				cmd = new SqlCommand
				{
					CommandType = CommandType.Text,
					CommandText = sql,
					Connection = sqlConnection
				};
				for (int i = 0; i < parameterCount; i++)
				{
					parameterName = $"@{i}";
					cmd.Parameters.AddWithValue(parameterName, parameters[i]);
				}
				cmd.ExecuteNonQuery();
			}
			catch(Exception ex)
            {
				throw ex;
            }
        }
        #endregion
    }
}
