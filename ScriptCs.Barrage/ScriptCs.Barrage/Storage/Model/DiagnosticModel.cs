using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptCs.Barrage.Data
{
    public class DiagnosticModel
    {
        public TimeSpan RequestInterval { get; set; }
        public int ChainId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public String Response { get; set; }
    }
}
