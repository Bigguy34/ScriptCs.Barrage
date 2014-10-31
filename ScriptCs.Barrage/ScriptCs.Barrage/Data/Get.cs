using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ScriptCs.Barrage.Data
{
    public class Get : BarrageRequest
    {

        public Get(string route, Func<HttpResponseMessage, BarrageRequest> next = null)
            : base(route, next)
        {

        }

        protected override Task<HttpResponseMessage> Execute(HttpClient client)
        {
            return client.GetAsync(Route);
        }
    }
}
