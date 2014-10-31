using ScriptCs.Barrage.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptCs.Barrage.Storage
{
    public interface IDiagnosticsStorage
    {
        Task<int> Insert(DiagnosticModel result);
    }
}
