using Ninject;
using ScriptCs.Barrage.Data.ScriptCs;
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
        private Config configuration;
        private IBarrageScenrioFactory _scenarioFactory;
        public BarragePack()
        {
            _kernel = new StandardKernel(new Bindings());
        }
        public BarrageScenrio CreateScenario()
        {
            return _scenarioFactory.CreateBarrageScenrio();
        }

        public void Load(Config config)
        {
            _kernel.Bind<IStorageConfig>().ToConstant(config.StorageConfig);
            _scenarioFactory = _kernel.Get<IBarrageScenrioFactory>();
        }
    }
}
