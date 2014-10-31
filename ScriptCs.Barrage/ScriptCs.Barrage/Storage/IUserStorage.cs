using ScriptCs.Barrage.Storage.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptCs.Barrage.Storage
{
    public interface IUserStorage
    {
        Task<int> Insert(UserModel user);
    }
}
