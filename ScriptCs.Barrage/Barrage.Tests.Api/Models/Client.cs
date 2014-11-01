using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Barrage.Tests.Api.Models
{
    public class Client
    {
        public String Name { get; set; }
        public int Id { get; set; }
        public List<Product> Products { get; set; }
    }
}
