using Barrage.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Barrage.Service
{
    public interface IBarrageScenrioFactory
    {
        BarrageScenrio CreateBarrageScenrio();
    }
}
