using ScriptCs.Barrage.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SQLite;
using System.Configuration;

namespace ScriptCs.Barrage.Storage
{
    public abstract class BaseSql 
    {
        private readonly String _databaseLocation;

        public BaseSql(StorageConfig config)
        {
            _databaseLocation = config.ConnectionString;
        }

        public abstract Task CreateTables();
        
        public abstract String TableName { get; }

        public bool TableExist()
        {
            using(var connection = new SQLiteConnection(Connection))
            {
                var numberOfTables = connection.Query(@"SELECT name FROM sqlite_master WHERE type='table' AND name='"+TableName+@"'");
                return numberOfTables.Count() > 0;
            }
           
        }

        protected String Connection
        {
            get
            {
                return _databaseLocation;
            }
        }
    }

   
}
