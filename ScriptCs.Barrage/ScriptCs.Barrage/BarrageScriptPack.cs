﻿using ScriptCs.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptCs.Barrage
{
    public class BarrageScriptPack : IScriptPack
    {
        public IScriptPackContext GetContext()
        {
            return new BarragePack();
        }

        public void Initialize(IScriptPackSession session)
        {
          
            session.ImportNamespace("Barrage.Data");
            session.ImportNamespace("Barrage.Storage");
            session.ImportNamespace("Barrage.Service");
        }

        public void Terminate()
        {
           
        }
    }
}
