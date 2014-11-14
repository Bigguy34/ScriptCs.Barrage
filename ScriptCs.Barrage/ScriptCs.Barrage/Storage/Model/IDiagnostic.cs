using BrightstarDB.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptCs.Barrage.Storage.Model
{
    [Entity]
    public interface IDiagnostic
    {
        long RequestInterval { get; set; }
        DateTime Date { get; set; }
        String Response { get; set; }
        IChain Chain { get; set; }
    }
}
