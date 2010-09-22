using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Reserva.Banco;
using System.Reflection;
using System.Data;
using System.Data.SqlClient;

namespace Reserva.Modelos
{
    public struct Column
    {
        public Type type;
        public String nome;
        public Boolean permite_null;
    }

    public abstract class Dao<T> where T : class
    {
        Type klass;
        protected Dictionary<String, Column> colunas;

        private String class_name = string.Empty;

        public String ClassName
        {
            get { return class_name; }
            set { class_name = value.ToLower(); }
        }

        protected Dao()
        {
            klass = typeof(T);
            GetProperts();
        }

        private void GetProperts()
        {
            ClassName = klass.Name;

            PropertyInfo[] infos = klass.GetProperties(BindingFlags.Public);
            Array.Sort(infos);
        }

    }
}


