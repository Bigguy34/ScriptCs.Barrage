using ScriptCs.Barrage.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptCs.Barrage.Service
{
    public class BarrageScenrioFactory
    {
        private readonly IChainStorage _chainStorage;
        public BarrageScenrioFactory(IChainStorage chainStorage)
        {
            _chainStorage = chainStorage;
        }
        
        public BarrageScenrio BarrageScenrioCreate(){
            return new BarrageScenrio(_chainStorage);
        }
    }
}
