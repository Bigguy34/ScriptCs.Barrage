using ScriptCs.Barrage.Data;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace ScriptCs.Barrage.Storage
{
    public class DiagnosticStorage : BaseSql, IDiagnosticsStorage
    {

        public override async Task CreateTables()
        {
            using (var connection = new SQLiteConnection(Connection))
            {
                await connection.ExecuteAsync(@"CREATE TABLE " + TableName + @"
                (
                        Id integer primary key AUTOINCREMENT,
                        RequestInterval real not null,
                        ChainId int not null,
                        UserId int not null,
                        Date text not null,
                        Response text null
                        
                )");
            }
        }

        public async Task<int> Insert(DiagnosticModel diagnostic)
        {
            using (var connection = new SQLiteConnection(Connection))
            {
                diagnostic.Date = DateTime.Now;
                var result = await connection.QueryAsync(@"INSERT INTO " + TableName + @"(RequestInterval,ChainId,UserId, Date, Response) 
                                                    VALUES(@RequestInterval, @ChainId ,@UserId, @Date, @Response);
                                                    select last_insert_rowid() as Id", diagnostic);
                var Id = result.First().Id;
                return Convert.ToInt32(Id);
            }
        }

        public override string TableName
        {
            get { return "Diagnostic"; }
        }
    }
}
