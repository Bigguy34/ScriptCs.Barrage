using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Modules;
using ScriptCs.Barrage.Storage;
using ScriptCs.Barrage.Service;
using ScriptCs.Barrage.Data.ScriptCs;

namespace ScriptCs.Barrage.Ninject
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IChainStorage>().To<ChainStorage>();
            Bind<IDiagnosticsStorage>().To<DiagnosticStorage>();
            Bind<IBarrageScenrioFactory>().To<BarrageScenrioFactory>();
        }
    }
}
