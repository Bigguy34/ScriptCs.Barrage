using ScriptCs.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptCs.Barrage
{
    public class BarrageScriptPack : IScriptPack
    {
        public IScriptPackContext GetContext()
        {
            return new BarragePack();
        }

        public void Initialize(IScriptPackSession session)
        {
            session.ImportNamespace("ScriptCs.Barrage.Data");
            session.ImportNamespace("ScriptCs.Barrage.Storage");
            session.ImportNamespace("ScriptCs.Barrage.Service");
        }

        public void Terminate()
        {
           
        }
    }
}
