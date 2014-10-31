namespace Barrage.Tests.Api
{
    using Barrage.Tests.Api.Models;
    using Nancy;
    using System.Collections.Generic;
    using System.Threading;

    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/product"] = parameters =>
            {
                //simulate long running app
                Thread.Sleep(500);
                return new List<Product>{
                    new Product{Name ="beta",Id = 1},
                    new Product{Name = "alpha",Id=2}
                };
            };

            Get["/product/{id}"] = parameters =>
            {
                Thread.Sleep(1000);
                return new Product { Name = "beta", Id = parameters.Id };
            };
        }
    }
}