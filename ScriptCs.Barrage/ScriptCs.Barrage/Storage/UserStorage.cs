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
    public class UserStorage:BaseSql, IUserStorage
    {
        public override Task CreateTables()
        {
            using (var connection = new SQLiteConnection(Connection))
            {
                return connection.ExecuteAsync(@"CREATE TABLE" + TableName + @"
                (
                        Id  integer identity primary key AUTOINCREMENT,
                        Name text not null
                        
                )");
            }
        }

        public override string TableName
        {
            get { return "User"; }
        }

        public async Task<int> Insert(UserModel user)
        {
            using (var connection = new SQLiteConnection(Connection))
            {
                var result = await connection.QueryAsync<int>(@"INSERT INTO User(Name) 
                                                    VALUES(@Name);
                                                    select last_insert_rowid()", user);
                return result.First();
            }
        }
    }
}
