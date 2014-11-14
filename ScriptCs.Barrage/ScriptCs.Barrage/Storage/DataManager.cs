using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptCs.Barrage.Storage
{
    public abstract class DataManager
    {
        protected readonly IStorageConfig _config;
        public DataManager(IStorageConfig config)
        {
            _config = config;
        }

    }
}
