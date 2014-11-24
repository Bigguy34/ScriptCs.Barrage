using Barrage.Data;
using ScriptCs.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ScriptCs.Barrage
{
    public class BarrageRequestPack : IScriptPackContext
    {
        /// <summary>
        /// Wrapper method for Get Requests
        /// </summary>
        /// <param name="route"> sub route of the base route passed into the scenario</param>
        /// <param name="next">next http method to call</param>
        /// <returns></returns>
        public Get Get(string route, Func<HttpResponseMessage, BarrageRequest> next = null)
        {
            return new Get(route, next);
        }

        /// <summary>
        /// Wrapper method for the Post Requests
        /// </summary>
        /// <param name="route"> sub route of the base route passed into the scenario</param>
        /// <param name="next">next http method to call</param>
        /// <param name="payload">possible payload to pass to insert into the body of the request</param>
        /// <returns></returns>
        public Post Post(String route, dynamic payload, Func<HttpResponseMessage, BarrageRequest> next = null)
        {
            return new Post(route, payload, next);
        }

        /// <summary>
        /// wrapper method for the Delete Requests
        /// </summary>
        /// <param name="route"> sub route of the base route passed into the scenario</param>
        /// <param name="next">next http method to call</param>
        /// <returns></returns>
        public Delete Delete(String route, Func<HttpResponseMessage, BarrageRequest> next = null)
        {
            return new Delete(route, next);
        }

        /// <summary>
        /// wrapper method for the Put Requests
        /// </summary>
        /// <param name="route"> sub route of the base route passed into the scenario</param>
        /// <param name="next">next http method to call</param>
        /// <param name="payload">possible payload to pass to insert into the body of the request</param>
        /// <returns></returns>
        public Put Put(String route, dynamic payload, Func<HttpResponseMessage, BarrageRequest> next = null)
        {
            return new Put(route, payload, next);
        }
    }
}
