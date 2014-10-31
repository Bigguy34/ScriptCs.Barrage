using ScriptCs.Barrage.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SQLite;

namespace ScriptCs.Barrage.Storage
{
    public abstract class BaseSql 
    {
        public abstract Task CreateTables();

        public abstract String TableName { get; }

        public bool DoesTableExsist()
        {
            using(var connection = new SQLiteConnection(Connection))
            {
                var numberOfTables = connection.Query<int>("SELECT name FROM sqlite_master WHERE type='table' AND name='" + TableName + "';").First();
                return numberOfTables > 0;
            }
           
        }

        protected String Connection
        {
            get
            {
                return "Data Source=" + Environment.CurrentDirectory + "\\Barrage.sqlite";
            }
        }
    }

   
}
