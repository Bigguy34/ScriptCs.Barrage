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

        public override Task CreateTables()
        {
            using (var connection = new SQLiteConnection(Connection))
            {
                return connection.ExecuteAsync(@"CREATE TABLE" + TableName + @"
                (
                        Id  integer identity primary key AUTOINCREMENT,
                        RequestInterval real not null,
                        ChainId int not null,
                        UserId int not null,
                        Date text not null
                        
                )");
            }
        }

        public async Task<int> Insert(DiagnosticModel diagnostic)
        {
            using (var connection = new SQLiteConnection(Connection))
            {
                diagnostic.Date = DateTime.Now;
                var result = await connection.QueryAsync<int>(@"INSERT INTO DIAGNOSTIC(RequestInterval,RequestName,RequestId,UserId, Date) 
                                                    VALUES(@RequestInterval, @ChainId, @UserId, @Date);
                                                    select last_insert_rowid()", diagnostic);
                return result.First();
            }
        }

        public override string TableName
        {
            get { return "Diagnostic"; }
        }
    }
}
