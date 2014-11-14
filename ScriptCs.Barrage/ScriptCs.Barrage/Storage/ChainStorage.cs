using ScriptCs.Barrage.Storage.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptCs.Barrage.Storage
{
    public class ChainStorage : DataManager, IChainStorage
    {

        public ChainStorage(IStorageConfig config) : base(config) { }

        public IChain Create(String Name)
        {
            using(var ctx = new MyEntityContext(_config.ConnectionString))
            {
                var chain = ctx.Chains.Create();
                chain.Name = Name;
                ctx.SaveChanges();
                return chain;
            }
        }

        public void AddRequest(IChain chain,IDiagnostic diagnostic)
        {
            using (var ctx = new MyEntityContext(_config.ConnectionString))
            {
                var chainResult = ctx.Chains.First(x => x.Id == chain.Id.ToString());
                chainResult.Requests.Add(diagnostic);
                ctx.SaveChanges();
            }
        }
       
    }
}
