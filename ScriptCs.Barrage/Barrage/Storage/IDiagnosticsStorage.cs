using Barrage.Data;
using Barrage.Storage.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barrage.Storage
{
    public interface IDiagnosticsStorage
    {
        IDiagnostic Create(TimeSpan requestInterval, DateTime date, String response);
    }
}
