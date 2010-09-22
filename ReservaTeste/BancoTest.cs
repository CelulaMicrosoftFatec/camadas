using Reserva.Banco;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Xml;
namespace BancoTest
{
    
    
    /// <summary>
    ///This is a test class for BancoTest and is intended
    ///to contain all BancoTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BancoTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        [TestMethod]
        public void deveria_trazer_uma_string_de_conexao_valida()
        {
            String string_conexao = "Data Source=.;Initial Catalog=db_reserva;Persist Security Info=True;User ID=sa; Password=sadministrador";
            Assert.AreEqual(string_conexao, BD.CONNECTION_STRING);
        }

        [TestMethod]
        public void deveria_retornar_um_objeto_SqlConnection()
        {
            Assert.IsNotNull(BD.Connection);
        }

        [TestMethod]
        public void deveria_trazer_um_elemento_SqlCommand()
        {
            Assert.IsNotNull(BD.Command);
        }

        [TestMethod]
        public void deveria_trazer_um_objeto_SqlDataReader()
        {
            Assert.IsInstanceOfType(BD.Reader("select * from usuario"), typeof(SqlDataReader));
        }

        [TestMethod]
        public void deveria_ler_um_objeto_sqldatareade()
        {
            SqlDataReader dr = BD.Reader("select * from usuario");
            String nome = String.Empty;
            while (dr.Read())
            {
                nome = dr["nm_nome"].ToString();
            }

            Assert.AreEqual("Jesus", nome);
        }

        [TestMethod]
        public void deveria_ler_um_objeto_sqldatareader_duas_vezes()
        {
            SqlDataReader dr = BD.Reader("select * from usuario");
            String nome = String.Empty;
            while (dr.Read())
            {
                nome = dr["nm_nome"].ToString();
            }
            
            Assert.AreEqual("Jesus", nome);

            SqlDataReader dr2 = BD.Reader("select * from usuario");
            String nome2 = String.Empty;
            while (dr2.Read())
            {
                nome2 = dr2["nm_nome"].ToString();
            }

            Assert.AreEqual("Jesus", nome2);
        }

        [TestMethod]
        public void deveria_trazer_um_DataTable()
        {
            Assert.IsInstanceOfType(BD.DataTable("select * from usuario"), typeof(DataTable));
        }
        
        [TestMethod]
        public void deveria_trazer_um_DataTable_com_contedo()
        {
            DataTable dt = BD.DataTable("select * from usuario");

            Assert.IsNotNull(dt);
            Assert.AreEqual(1, dt.Rows.Count);
        }


    }
}
