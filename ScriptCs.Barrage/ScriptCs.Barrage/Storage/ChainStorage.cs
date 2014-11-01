using ScriptCs.Barrage.Storage.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace ScriptCs.Barrage.Storage
{
    public class ChainStorage : BaseSql, IChainStorage
    {
        public override async Task CreateTables()
        {
            using (var connection = new SQLiteConnection(Connection))
            {
                await connection.ExecuteAsync(@"CREATE TABLE "+TableName+@"
                (
                        Id  integer primary key AUTOINCREMENT,
                        Name text not null
                        
                )");
            }
        }
        
        public async Task<int> Insert(ChainModel chain)
        {
            using (var connection = new SQLiteConnection(Connection))
            {
                var result = await connection.QueryAsync(@"INSERT INTO Chain(Name) 
                                                    VALUES(@Name);
                                                    select last_insert_rowid() as Id", chain);
                var Id = result.First().Id;
                return Convert.ToInt32(Id);
            }
        }

        public override string TableName
        {
            get { return "Chain"; }
        }
    }
}
