using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Modules;
using Barrage.Storage;
using Barrage.Service;
using Barrage.Data;

namespace Barrage.Ninject
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
