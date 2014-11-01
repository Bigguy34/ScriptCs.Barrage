using Ninject;
using ScriptCs.Barrage.Ninject;
using ScriptCs.Barrage.Service;
using ScriptCs.Barrage.Storage;
using ScriptCs.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptCs.Barrage
{
    public class BarragePack : IScriptPackContext
    {
        private IKernel _kernel;
        private readonly IBarrageScenrioFactory _scenarioFactory;
        public BarragePack()
        {
            _kernel = new StandardKernel(new Bindings());
            _scenarioFactory = _kernel.Get<IBarrageScenrioFactory>();
            SqlManager.CreateTables(_kernel.Get<IDiagnosticsStorage>() as BaseSql, _kernel.Get<IChainStorage>() as BaseSql);
        }

        public BarrageScenrio CreateScenario()
        {
            return _scenarioFactory.CreateBarrageScenrio();
        }
    }
}
