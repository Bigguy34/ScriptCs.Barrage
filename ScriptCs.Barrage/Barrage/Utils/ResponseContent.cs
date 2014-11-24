using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Barrage.Utils
{
    public class ResponseContent
    {
        public static async Task<dynamic> Convert(HttpContent content)
        {
            var responseContent = await content.ReadAsStringAsync();
            //This is done for syntax sake, because async on a func is funky.
            return JsonConvert.DeserializeObject(responseContent);
        }

        public static async Task<T> ConvertTo<T>(HttpContent content)
        {
            var responseContent = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseContent);
        }
    }
}
