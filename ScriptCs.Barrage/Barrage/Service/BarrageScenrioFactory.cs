using Barrage.Service;
using Barrage.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barrage.Service
{
    public class BarrageScenrioFactory : IBarrageScenrioFactory
    {
        private readonly IChainStorage _chainStorage;
        private readonly IDiagnosticsStorage _diagnosticStorage;
        public BarrageScenrioFactory(IChainStorage chainStorage,IDiagnosticsStorage diagnosticStorage)
        {
            _chainStorage = chainStorage;
            _diagnosticStorage = diagnosticStorage;
        }
        
        public BarrageScenrio CreateBarrageScenrio(){
            return new BarrageScenrio(_chainStorage, _diagnosticStorage);
        }
    }
}
