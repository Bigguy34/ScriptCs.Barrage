using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Barrage.Data;
using Barrage.Storage;
using System.Net.Http;
using System.Net.Http.Headers;
using Barrage.Storage.Model;

namespace Barrage.Service
{
    public class BarrageScenrio 
    {
        private readonly List<BarrageRequest> _barrageCollection;
        private string _baseRoute;
        private readonly IChainStorage _chainStorage;
        private readonly IDiagnosticsStorage _diagnosticStorage;
        public string _name;
        public BarrageScenrio(IChainStorage chainStorage, IDiagnosticsStorage diagnosticStorage)
        {
            _barrageCollection = new List<BarrageRequest>();
            _chainStorage = chainStorage;
            _diagnosticStorage = diagnosticStorage;
        }
        public void Configure(string baseRoute, string name)
        {
            _baseRoute = baseRoute;
            _name = name;
        }
        public void Add(BarrageRequest barrageRequest)
        {
            //Load dependencies here for the sake of syntax
            barrageRequest.LoadDepedencies(_diagnosticStorage,_chainStorage);
            _barrageCollection.Add(barrageRequest);
        }

        public async Task Start(int numberOfUsers = 1)
        {
            if (String.IsNullOrEmpty(_baseRoute)) throw new Exception("You must define a base route");
            if (String.IsNullOrEmpty(_name)) throw new Exception("You must define a name for the newly created scenerio");
            var chain = _chainStorage.Create(_name);
            using (HttpClient client = new HttpClient())
            {

                client.BaseAddress = new Uri(_baseRoute);
                client.Timeout = TimeSpan.FromMilliseconds(10000);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                foreach (var barrageRequest in _barrageCollection)
                {
                    await barrageRequest.Run(client, chain);
                }
            }
        }
    }
}
