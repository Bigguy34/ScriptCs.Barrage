using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScriptCs.Barrage.Data;
using ScriptCs.Barrage.Service;
using ScriptCs.Barrage.Storage;
using System.Net.Http;
using System.Threading.Tasks;
using Ninject;
using System.Reflection;
using ScriptCs.Barrage.Ninject;

namespace Barrage.Tests
{
    [TestClass]
    [DeploymentItem(@"x86\SQLite.Interop.dll", "x86")]
    public class BarrageTest
    {

        private readonly IBarrageScenrioFactory _scenrioFactory;
        private readonly IDiagnosticsStorage _diagnosticStorage;
        private readonly IChainStorage _chainStorage;
        public BarrageTest()
        {
            IKernel kernel = new StandardKernel( new Bindings());
            //Service locator pattern is stupid, but this is a unit test.
            _scenrioFactory = kernel.Get<IBarrageScenrioFactory>();
            SqlManager.CreateTables(kernel.Get<IDiagnosticsStorage>() as BaseSql, kernel.Get<IChainStorage>() as BaseSql);
        }
        
        [TestMethod]
        public async Task TestBarrageGet()
        {
            var scenrio = _scenrioFactory.CreateBarrageScenrio();
            scenrio.Configure("http://localhost:8080", "test get");
            scenrio.Add(new Get("/product/1"));
            await scenrio.Start();
        }

        [TestMethod]
        public async Task TestBarragePost()
        {
            var scenerio = _scenrioFactory.CreateBarrageScenrio();
            scenerio.Configure("http://localhost:8080", "test post");
            scenerio.Add(new Post("/product", new { Name = "TomIsAwesome" }));
            await scenerio.Start();
        }
        [TestMethod]
        public async Task TestBarragePut()
        {
            var scenerio = _scenrioFactory.CreateBarrageScenrio();
            scenerio.Configure("http://localhost:8080", "test put");
            scenerio.Add(new Put("/product", new { Name = "TomIsAwesome" }));
            await scenerio.Start();
        }
        [TestMethod]
        public async Task TestBarrageDelete()
        {
            var scenerio = _scenrioFactory.CreateBarrageScenrio();
            scenerio.Configure("http://localhost:8080", "test Delete");
            scenerio.Add(new Delete("/product/1"));
            await scenerio.Start();
        }

        [TestMethod]
        public async Task TestBarrageChainPostGet()
        {
            var scenerio = _scenrioFactory.CreateBarrageScenrio();
            scenerio.Configure("http://localhost:8080", "test Chain");
            scenerio.Add(new Get("/product/1",
                (requestResponse)=>{
                    return new Post("/product/", new { Name = "TomIsAwesome" });
                }));
        }
    }
}
