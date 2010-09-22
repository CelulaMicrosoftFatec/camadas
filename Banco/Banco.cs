using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Reserva.Banco
{
    public static class BD
    {
        public static string CONNECTION_STRING = "Data Source=.;Initial Catalog=db_reserva;Persist Security Info=True;User ID=sa; Password=sadministrador";
        private static SqlConnection conn = new SqlConnection(CONNECTION_STRING);
        private static SqlCommand cmd = Connection.CreateCommand();

        public static SqlCommand Command
        {
            get { return BD.cmd; }
            set { BD.cmd = value; }
        }

        public static SqlConnection Connection
        {
            get { return BD.conn; }
            set { BD.conn = value; }
        }

        public static SqlDataReader Reader(string query)
        {
            if (Connection.State.Equals(ConnectionState.Open)) Connection.Close();
            Connection.Open();

            Command.CommandText = query;

            return Command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public static DataTable DataTable(string query)
        {
           SqlDataAdapter adapter = new SqlDataAdapter(Connection.CreateCommand());
           adapter.SelectCommand.CommandText = query;

           var dt = new DataTable();
           adapter.Fill(dt);
           return dt;
        }
    }
}
