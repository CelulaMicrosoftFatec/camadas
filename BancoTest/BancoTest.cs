using Reserva.Banco;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.SqlClient;

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
        public void deveria_instanciar()
        {
            BD bd = new BD();
            Assert.IsNotNull(bd);
        }

        [TestMethod]
        public void deveria_ter_comand()
        {
            BD bd = new BD();
            Assert.IsNotNull(bd.Comand);
        }

        [TestMethod]
        public void deveria_validar_connection_string()
        {
            BD bd = new BD();
            Assert.AreEqual(1, bd.DataTable("select * from usuario").Rows.Count);
        }

        [TestMethod]
        public void deveria_retornar_um_data_reader()
        {
            BD bd = new BD();
            SqlDataReader reader = bd.Reader("select * from usuario");
            Assert.IsNotNull(reader);
        }

        [TestMethod]
        public void deveria_trazer_o_primeiro_usuario()
        {
            BD bd = new BD();
            SqlDataReader reader = bd.Reader("select top  1 * from usuario");
            if (reader.Read())
            {
                String nome = reader["nm_nome"].ToString();
                Assert.AreEqual("Jesus", nome);
            }
        }

    }
}
