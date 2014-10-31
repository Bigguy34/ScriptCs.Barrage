using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ScriptCs.Barrage.Data
{
    public class Post : BarrageRequest
    {

        private dynamic _payload;
        public Post(String route, dynamic payload, Func<HttpResponseMessage, BarrageRequest> next = null)
            : base(route, next)
        {
            _payload = payload;
        }

        protected override Task<HttpResponseMessage> Execute(HttpClient client)
        {
            return client.PostAsync(Route, CreateJsonContent(_payload));
        }
    }
}
