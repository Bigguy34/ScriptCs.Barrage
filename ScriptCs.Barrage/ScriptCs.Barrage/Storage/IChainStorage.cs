using ScriptCs.Barrage.Storage.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptCs.Barrage.Storage
{
    public interface IChainStorage
    {
        Task<int> Insert(ChainModel chain);
    }
}
