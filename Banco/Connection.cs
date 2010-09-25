using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Data.Common;

namespace Banco
{
    public class Connection
    {
        static Connection singleton_conn;
        public delegate void ExecCommand(SqlCommand cmd);
        public delegate void ExecAdapter(SqlDataAdapter cmd);

        SqlCommand cmd = new SqlCommand();
        SqlConnection conn;

        public SqlConnection Conexao
        {
            get { return conn; }
            private set { conn = value; }
        }

        public SqlCommand Command
        {
            get { return cmd; }
            private set { cmd = value; }
        }

        public ConnectionState State
        {
            get { return conn.State; }
        }

        private Connection(String connection_string)
        {
            Conexao = new SqlConnection(connection_string);
            Command = Conexao.CreateCommand();
        }

        public static Connection GetInstance()
        {
            if (singleton_conn == null) singleton_conn = new Connection("Data Source=.;Initial Catalog=db_reserva;Persist Security Info=True;User ID=sa; Password=sadministrador");

            return singleton_conn;
        }

        public static Connection GetInstance(String connection_string)
        {
            if (singleton_conn == null) singleton_conn = new Connection(connection_string);

            return singleton_conn;
        }

        private DbTransaction Open()
        {
            if (conn.State.Equals(ConnectionState.Open))
            {
                conn.Close();
                if (Command.Transaction != null) Command.Transaction.Commit();
            }

            conn.Open();

            return conn.BeginTransaction();
        }

        public SqlCommand Execute(ExecCommand cmd)
        {

            Command.Transaction = (SqlTransaction)Open();
            cmd(Command);

            return Command;
        }

        public SqlCommand Execute(ExecAdapter adapter)
        {
            using (DbTransaction trans = Open())
            {
                Command.Transaction = (SqlTransaction)trans;
                adapter(new SqlDataAdapter(Command)); ;
            }

            return Command;
        }
    }
}
