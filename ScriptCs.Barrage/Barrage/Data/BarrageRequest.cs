using Newtonsoft.Json;
using Ninject;
using Barrage.Storage;
using Barrage.Storage.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Barrage.Data
{
    public abstract class BarrageRequest
    {
        protected String Route;
        protected Func<HttpResponseMessage, BarrageRequest> Next;
        private IDiagnosticsStorage _diagnosticStorage;
        private IChainStorage _chainStorage;

        protected BarrageRequest(string route ,Func<HttpResponseMessage, BarrageRequest> next = null)
        {
            Route = route;
            Next = next;
        }


        //Normally this would be constructor injection, however here I have changed it to be Setter Method Injection, for the sake of synatx
        
        public void LoadDepedencies(IDiagnosticsStorage diagnosticStorage, IChainStorage chainStorage)
        {
            _diagnosticStorage = diagnosticStorage;
            _chainStorage = chainStorage;
        }

        protected StringContent CreateJsonContent(dynamic payload)
        {
            var jsonString = JsonConvert.SerializeObject(payload);
            var jsonContent = new StringContent(jsonString, Encoding.Default, "application/json");
            return jsonContent;
        }

        protected abstract Task<HttpResponseMessage> Execute(HttpClient client);

        public async Task Run(HttpClient client, IChain chain)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var response = await Execute(client);
            stopWatch.Stop();
            if(Next != null)
            {
                var nextRequest = Next(response);
                nextRequest.LoadDepedencies(_diagnosticStorage, _chainStorage);
                await nextRequest.Run(client, chain);
            }
            var diagnostic = _diagnosticStorage.Create(stopWatch.Elapsed,DateTime.Now,await response.Content.ReadAsStringAsync());
            _chainStorage.AddRequest(chain,diagnostic);
        }
    }
}
