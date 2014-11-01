﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScriptCs.Barrage.Data;
using ScriptCs.Barrage.Storage;
using System.Net.Http;
using System.Net.Http.Headers;
using ScriptCs.Barrage.Storage.Model;

namespace ScriptCs.Barrage.Service
{
    public class BarrageScenrio 
    {
        private readonly List<BarrageRequest> _barrageCollection;
        private string _baseRoute;
        private readonly IChainStorage _chainStorage;
        private readonly IDiagnosticsStorage _diagnosticStorage;
        private string _name;
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
            barrageRequest.LoadDepedencies(_diagnosticStorage);
            _barrageCollection.Add(barrageRequest);
        }

        public async Task Start(int numberOfUsers = 1)
        {
            if (String.IsNullOrEmpty(_baseRoute)) throw new Exception("You must define a base route");
            if (String.IsNullOrEmpty(_name)) throw new Exception("You must define a name for the newly created scenerio");
            var chain =  new ChainModel
            {
                Name = _name
            };
            var chainId = await _chainStorage.Insert(chain);
            chain.Id = chainId;
            using (HttpClient client = new HttpClient())
            {

                client.BaseAddress = new Uri(_baseRoute);
                client.Timeout = TimeSpan.FromMilliseconds(10000);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                foreach (var barrageRequest in _barrageCollection)
                {
                    await barrageRequest.Run(client, chain, new UserModel { Name = "Test", Id = 1 });
                }
            }
        }
    }
}
