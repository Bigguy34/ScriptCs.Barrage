using ScriptCs.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptCs.Barrage
{
    public class BarrageRequestScriptPack : IScriptPack
    {
        public IScriptPackContext GetContext()
        {
 	        return new BarrageRequestPack();
        }

        public void Initialize(IScriptPackSession session)
        {
            session.AddReference("System.Net.Http");
        }

        public void Terminate()
        {
 	        
        }
    }
}
