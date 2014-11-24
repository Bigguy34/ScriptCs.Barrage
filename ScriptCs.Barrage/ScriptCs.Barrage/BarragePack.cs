using System;
using Ninject;
using Barrage.Data;
using Barrage.Ninject;
using Barrage.Service;
using Barrage.Storage;
using ScriptCs.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ScriptCs.Barrage
{
    public class BarragePack : IScriptPackContext
    {
        private IKernel _kernel;
        private StorageConfig configuration;
        private IBarrageScenrioFactory _scenarioFactory;
        public BarragePack()
        {
            _kernel = new StandardKernel(new Bindings());
        }
        public BarrageScenrio CreateScenario(string baseRoute, string name)
        {
            if (_scenarioFactory == null) throw new Exception("Make sure to call the Load method on the instance of BarragePack, this will create the proper variables");
            var scenario = _scenarioFactory.CreateBarrageScenrio();
            scenario.Configure(baseRoute, name);
            return scenario;

        }
      

        public void Load(StorageConfig storageConfig)
        {
            _kernel.Bind<IStorageConfig>().ToConstant(storageConfig);
            //In general I am not a fan of the service locator pattern, but scriptcs is an oddity in of it's self.
            _scenarioFactory = _kernel.Get<IBarrageScenrioFactory>();
        }
    }
}
