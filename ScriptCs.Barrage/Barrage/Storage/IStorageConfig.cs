using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barrage.Storage
{
    public interface IStorageConfig
    {
        String StoreName { get; }

        String DbDirectory { get; }

        String ConnectionString { get; }
    }
}
