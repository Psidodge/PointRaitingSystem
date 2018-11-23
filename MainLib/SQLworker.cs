using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace MainLib
{
    public class SQLworker
    {
        // NOTUSE: serverName, databaseName not use
        private string connectionString,
                       serverName, 
                       databaseName;

        private SqlConnection sqlConnection;
        private ErrorLogger loggerRef;

        public SQLworker(ref ErrorLogger errLogger)
        {
            this.connectionString = null;
            this.sqlConnection = null;
            this.loggerRef = errLogger;
        }
        public SQLworker(string _connectionString, ref ErrorLogger errLogger)
        {
            this.connectionString = _connectionString;
            this.sqlConnection = new SqlConnection(_connectionString);
            this.loggerRef = errLogger;
            OpenConnection();
        }


        public bool OpenConnection()
        {
            try
            {
                sqlConnection.Open();
                return true;
            }
            catch(Exception ex)
            {
                this.loggerRef.ErrorStackTrace(ex.StackTrace);
                this.loggerRef.Error(this, ex.Message);
                return false;
            }
        }
        public void CloseConnection()
        {
            try
            {
                this.sqlConnection.Close();
            }
            catch (Exception ex)
            {
                this.loggerRef.ErrorStackTrace(ex.StackTrace);
                this.loggerRef.Error(this, ex.Message);
            }
        }
        public void CreateConnection(string _serverName, string _databaseName)
        {
            this.connectionString = CreateConnectionString(_serverName, _databaseName);
            this.sqlConnection = new SqlConnection(this.connectionString);
            if (!CheckConnection())
                throw new ConnectionSetupError();
        }
        public bool CheckConnection()
        {
            try
            {
                if(this.IsAlive)
                    return true;
            }catch(Exception ex)
            {
                this.loggerRef.ErrorStackTrace(ex.StackTrace);
                this.loggerRef.Error(this, ex.Message);
            }
            return false;
        }
        public List<string> GetListOfServers()
        {
            List<string> listOfServerNames = new List<string>();
            DataTable dt = SqlDataSourceEnumerator.Instance.GetDataSources();
            //Handler here
            foreach(DataRow row in dt.Rows)
            {
                listOfServerNames.Add(string.Format("{0}\\{1}", row[0], row[1]));
            }
            return listOfServerNames;
        }
        public List<string> GetListOfDatabases(string _serverName)
        {
            List<string> listOfDatabases = new List<string>();
            SqlConnection connection = new SqlConnection(string.Format("Data Source={0};Integrated Security=True", _serverName));
            connection.Open();
            SqlCommand query = new SqlCommand("SELECT name FROM sys.databases", connection);
            SqlDataReader sqlReader = query.ExecuteReader();

            //Handler here
            while(sqlReader.Read())
            {
                listOfDatabases.Add(sqlReader["name"].ToString());
            }
            connection.Close();
            return listOfDatabases;
        }
        public DataTable ExecuteQuery(string _query)
        {
            SqlCommand query = new SqlCommand(_query, this.sqlConnection);
            SqlDataReader dataReader = query.ExecuteReader();

            DataRow dRow;
            DataTable queryResult = DataTableCreator(dataReader);

            while (dataReader.Read())
            {
                dRow = queryResult.NewRow();
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    dRow[i] = dataReader.GetValue(i);
                }
                queryResult.Rows.Add(dRow);
            }
            dataReader.Close();
            return queryResult;
        }


        private DataTable DataTableCreator(SqlDataReader sqlDR)
        {
            DataTable dt = new DataTable();
            DataColumn dColumn;
            for(int i = 0; i < sqlDR.FieldCount; i++)
            {
                dColumn = new DataColumn();
                dColumn.DataType = sqlDR.GetFieldType(i);
                dColumn.ColumnName = sqlDR.GetName(i);
                dt.Columns.Add(dColumn);
            }
            return dt;
        }
        private string CreateConnectionString(string _serverName, string _databaseName)
        {
            return string.Format("Data Source={0};Initial Catalog={1};Integrated Security=True", _serverName, _databaseName);
        }
        private string CreateConnectionString(string _serverName)
        {
            return string.Format("Data Source={0};Integrated Security=True", _serverName);
        }


        public string GetServerName { get => this.serverName; }
        public string GetDBName { get => this.databaseName; }
        public string GetConnectionString { get => this.connectionString; }
        public bool IsAlive { get => (sqlConnection.State == ConnectionState.Open); }

        [Serializable]
        public class ConnectionSetupError : Exception
        {
            public ConnectionSetupError() { }
            public ConnectionSetupError(string message) : base(message) { }
            public ConnectionSetupError(string message, Exception inner) : base(message, inner) { }
            protected ConnectionSetupError(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }
    }
}


// TOREF: GetTables() not use
//public List<string> GetTables()
//{
//    if (!this.IsAlive)
//        return null;
//    List<string> tableNames = new List<string>();
//    DataTable dt = this.sqlConnection.GetSchema("Tables");
//    foreach(DataRow row in dt.Rows)
//    {
//        tableNames.Add(row[2].ToString());
//    }
//    return tableNames;
//}