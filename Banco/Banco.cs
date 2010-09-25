using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Banco
{
    public static class BD
    {
        public static string CONNECTION_STRING = "Data Source=.;Initial Catalog=db_reserva;Persist Security Info=True;User ID=sa; Password=sadministrador";

        public static Connection Conexao
        {
            get { return Connection.GetInstance(); }
        }

        public static SqlDataReader Reader(string query)
        {
            SqlDataReader reader = null;
            Conexao.Execute(delegate(SqlCommand cmd) {
                cmd.CommandText = query;
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            });

            return reader;
        }

        public static DataTable DataTable(string query)
        {
            DataTable dt = new DataTable();

            Conexao.Execute(delegate(SqlDataAdapter adpter) {
                adpter.SelectCommand.CommandText = query;
                adpter.Fill(dt);
            });
            
           return dt;
        }

        public static Int32 ExecuteNonQuery(string query)
        {
            Int32 result = 0;
            Conexao.Execute(delegate(SqlCommand cmd)
            {
                cmd.CommandText = query;
                result = cmd.ExecuteNonQuery();
                cmd.Transaction.Commit();
            });

            return result;
        }

    }
}
