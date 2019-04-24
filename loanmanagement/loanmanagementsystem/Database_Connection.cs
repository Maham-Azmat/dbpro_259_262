using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace loanmanagementsystem
{
    public class Database_Connection
    {
        private static Database_Connection instance;
        public string connectionstring;
        private SqlConnection connection;

        Database_Connection()
        {

        }

        public static Database_Connection get_instance()
        {
            if (instance == null)
            {
                instance = new Database_Connection();
            }
            return instance;
        }


        public SqlConnection Getconnection()
        {
            connection = new SqlConnection(connectionstring);
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
            return connection;
        }

        public void close()
        {
            if (connection != null)
            {
                connection.Close();
            }
        }

        public SqlDataReader Getdata(string query)
        {
            connection = Getconnection();
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader data = cmd.ExecuteReader();
            return data;

        }

        public int Executequery(string query)
        {
            connection = Getconnection();
            SqlCommand cmd = new SqlCommand(query, connection);
            int row = cmd.ExecuteNonQuery();
            return row;
        }
    }
}