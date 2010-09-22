using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Reserva.Banco;

namespace Reserva.Modelos
{
    public class Usuario : Dao<Usuario>
    {
        #region Propriedades

        private int id_usuario {get; set;}
        public string nm_nome { get; set; }
        public string nm_login { get; set; }
        public string nm_senha { get; set; }
        public string id_tp_usuario { get; set; }

        #endregion
    }
}
