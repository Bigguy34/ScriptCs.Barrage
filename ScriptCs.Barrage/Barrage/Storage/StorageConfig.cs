using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barrage.Storage
{
    public class StorageConfig : IStorageConfig
    {
        public String StoreName { get { return "Barrage"; } }

        public String DbDirectory { get; set; }

        public String ConnectionString { get { return String.Format("type=embedded;storesdirectory={0};storename={1}", DbDirectory, StoreName); } }
    }
}
