using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScriptCs.Barrage.Data;
using ScriptCs.Barrage.Service;
using ScriptCs.Barrage.Storage;
using System.Net.Http;

namespace Barrage.Tests
{
    [TestClass]
    public class BarrageTest
    {
        
        private readonly BarrageScenrioFactory _scenrioFactory;
        private readonly IDiagnosticsStorage _diagnosticStorage;
        private readonly IChainStorage _chainStorage;
        public BarrageTest()
        {
            _scenrioFactory = new BarrageScenrioFactory(new ChainStorage());
            _diagnosticStorage = new DiagnosticStorage();
            _chainStorage = new ChainStorage();
            SqlManager.CreateTables(_diagnosticStorage as BaseSql, _chainStorage as BaseSql);
        }
        
        [TestMethod]
        public void TestBarrageCreation()
        {
            var scenrio = _scenrioFactory.BarrageScenrioCreate();
            scenrio.Configure("http://localhost:8080", "The Test");
            scenrio.Add(new Get("/product"));
            scenrio.Start();
            
        }
    }
}
