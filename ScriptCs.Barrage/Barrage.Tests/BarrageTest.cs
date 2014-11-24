using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Barrage.Data;
using Barrage.Service;
using Barrage.Storage;
using System.Net.Http;
using System.Threading.Tasks;
using Ninject;
using System.Reflection;
using Barrage.Ninject;
using Barrage.Utils;

namespace Barrage.Tests
{
    [TestClass]
    public class BarrageTest
    {

        private readonly IBarrageScenrioFactory _scenarioFactory;
        private readonly IDiagnosticsStorage _diagnosticStorage;
        private readonly IChainStorage _chainStorage;
        public BarrageTest()
        {
            IKernel kernel = new StandardKernel( new Bindings());
            kernel.Bind<IStorageConfig>().ToConstant(new StorageConfig
            {
                DbDirectory = @"C:\data",

            });
            //Service locator pattern is stupid, but this is a unit test.
            _scenarioFactory = kernel.Get<IBarrageScenrioFactory>();
        }
        
        [TestMethod]
        public async Task TestBarrageGet()
        {
            var scenario = _scenarioFactory.CreateBarrageScenrio();
            scenario.Configure("http://localhost:8080", "test get");
            scenario.Add(new Get("/product/1"));
            await scenario.Start();
        }

        [TestMethod]
        public async Task TestBarragePost()
        {
            var scenario = _scenarioFactory.CreateBarrageScenrio();
            scenario.Configure("http://localhost.fiddler:8080", "test post");
            scenario.Add(new Post("/product/1", new { Name = "TomIsAwesome" }));
            await scenario.Start();
        }
        [TestMethod]
        public async Task TestBarragePut()
        {
            var scenario = _scenarioFactory.CreateBarrageScenrio();
            scenario.Configure("http://localhost:8080", "test put");
            scenario.Add(new Put("/product/1", new { Name = "TomIsAwesome" }));
            await scenario.Start();
        }
        [TestMethod]
        public async Task TestBarrageDelete()
        {
            var scenario = _scenarioFactory.CreateBarrageScenrio();
            scenario.Configure("http://localhost:8080", "test Delete");
            scenario.Add(new Delete("/product/1"));
            await scenario.Start();
        }

        [TestMethod]
        public async Task TestBarrageChainPostGet()
        {
            var scenario = _scenarioFactory.CreateBarrageScenrio();
            scenario.Configure("http://localhost.fiddler:8080", "test Chain Get then Post");
            scenario.Add(new Get("/product/1",
                (requestResponse)=>{
                    var response = ResponseContent.Convert(requestResponse.Content).Result;
                    return new Post("/product/", new{ Id = response.Id });
                }));
            await scenario.Start();
        }
    }
}
