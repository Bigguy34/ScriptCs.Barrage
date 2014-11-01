using ScriptCs.Barrage.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptCs.Barrage.Service
{
    public class SqlManager
    {
        public static void CreateTables(params BaseSql[] storageInstances)
        {
            foreach(var storageInstance in storageInstances)
            {
                if(!storageInstance.TableExist()){
                    storageInstance.CreateTables();
                }
            }
        }
    }
}
