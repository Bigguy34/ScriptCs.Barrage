using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ScriptCs.Barrage.Data
{
    public class Delete : BarrageRequest
    {
        public Delete(String route, Func<HttpResponseMessage, BarrageRequest> next = null)
            : base(route, next)
        {

        }

        protected override Task<HttpResponseMessage> Execute(HttpClient client)
        {
            return client.DeleteAsync(Route);
        }
    }
}
