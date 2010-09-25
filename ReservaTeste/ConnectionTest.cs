using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Banco;
using System.Data.SqlClient;
using System.Data;

namespace ReservaTeste
{
    [TestClass]
    public class ConnectionTest
    {
        Connection conn;
        
        [TestInitialize]
        public void deveria_instancias_conexao()
        {
            conn = Connection.GetInstance();
        }


        [TestMethod]
        public void deveria_ter_o_mesmo_hash()
        {
            Connection CONN2 = Connection.GetInstance();
            Assert.AreEqual(conn.GetHashCode(), CONN2.GetHashCode());
        }

        [TestMethod]
        public void deveria_trazer_conexao()
        {
            Assert.IsNotNull(conn);
        }

        [TestMethod]
        public void deveria_instanciar_uma_conexao_com_o_banco()
        {
            Assert.IsInstanceOfType(conn.Command, typeof(SqlCommand));
        }


        [TestMethod]
        public void deveria_buscar_usuario_pelo_Command()
        {
            object resultado = null;
            
            conn.Execute(delegate(SqlCommand cmd){
                cmd.CommandText = "select * from usuario";
                resultado = cmd.ExecuteScalar();
            });

            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        public void deveria_buscar_usuario_pelo_Command_denovo()
        {
            object resultado = null;

            conn.Execute(delegate(SqlCommand cmd)
            {
                cmd.CommandText = "select * from usuario";
                resultado = cmd.ExecuteScalar();
            });

            Assert.IsNotNull(resultado);
        }
    }
}
