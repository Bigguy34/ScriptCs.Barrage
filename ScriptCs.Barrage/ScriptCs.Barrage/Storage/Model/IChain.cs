using BrightstarDB.EntityFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptCs.Barrage.Storage.Model
{
    [Entity]
    public interface IChain
    {
        String Name { get; set; }
        [Identifier]
        String Id { get; }
        [InverseProperty("Chain")]
        ICollection<IDiagnostic> Requests { get; set; }
    }
}
