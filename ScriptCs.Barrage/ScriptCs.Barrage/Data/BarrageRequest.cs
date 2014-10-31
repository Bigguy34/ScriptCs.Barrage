using Newtonsoft.Json;
using Ninject;
using ScriptCs.Barrage.Storage;
using ScriptCs.Barrage.Storage.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ScriptCs.Barrage.Data
{
    public abstract class BarrageRequest
    {
        protected String Route;
        protected Func<HttpResponseMessage, BarrageRequest> Next;
        private IDiagnosticsStorage _diagnosticStorage;

        protected BarrageRequest(string route, Func<HttpResponseMessage, BarrageRequest> next = null)
        {
            Route = route;
            Next = next;
        }


        //Normally this would be constructor injection, hoever here I have changed it to be Setter Method Injection, for the sake of synatx
        [Inject]
        public void Load(IDiagnosticsStorage diagnosticStorage)
        {
            _diagnosticStorage = diagnosticStorage;
        }

        protected StringContent CreateJsonContent(dynamic payload)
        {
            var jsonString = JsonConvert.SerializeObject(payload);
            var jsonContent = new StringContent(jsonString, Encoding.Default, "application/json");
            return jsonContent;
        }

        protected abstract Task<HttpResponseMessage> Execute(HttpClient client);

        public async Task Run(HttpClient client, ChainModel chain, UserModel user)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var response = await Execute(client);
            stopWatch.Stop();
            if(Next != null)
            {
                Next(response).Run(client,chain,user);
            }

            _diagnosticStorage.Insert(new DiagnosticModel
            {
                Date = DateTime.Now,
                RequestInterval = stopWatch.Elapsed,
                Response = await response.Content.ReadAsStringAsync(),
                ChainId = chain.Id,
                UserId = user.Id 
            });
        }
    }
}
