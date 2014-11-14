using ScriptCs.Barrage.Data;
using ScriptCs.Barrage.Storage.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptCs.Barrage.Storage
{
    public interface IDiagnosticsStorage
    {
        IDiagnostic Create(TimeSpan requestInterval, DateTime date, String response);
    }
}
