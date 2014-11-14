using ScriptCs.Barrage.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScriptCs.Barrage.Storage.Model;

namespace ScriptCs.Barrage.Storage
{
    public class DiagnosticStorage : DataManager, IDiagnosticsStorage
    {
        public DiagnosticStorage(IStorageConfig config) : base(config) { }
        public IDiagnostic Create(TimeSpan requestInterval, DateTime date, String response)
        {
            using (var ctx = new MyEntityContext(_config.ConnectionString))
            {

                var diagnostics = ctx.Diagnostics.Create();
                diagnostics.RequestInterval = requestInterval.Ticks;
                diagnostics.Response = response;
                diagnostics.Date = date;
                ctx.SaveChanges();
                return diagnostics;
            }
        }
    }
}
