using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ScriptCs.Barrage.Data
{
    public class Put : BarrageRequest
    {
        private dynamic _payload;

        public Put(String route, dynamic payload, Func<HttpResponseMessage, BarrageRequest> next = null)
            : base(route, next)
        {
            _payload = payload;
        }

        protected override async Task<HttpResponseMessage> Execute(HttpClient client)
        {
            return await client.PutAsync(Route, CreateJsonContent(_payload));
          
        }
    }
}
