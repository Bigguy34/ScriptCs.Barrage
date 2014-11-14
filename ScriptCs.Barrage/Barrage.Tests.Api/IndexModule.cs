namespace Barrage.Tests.Api
{
    using Barrage.Tests.Api.Models;
    using Nancy;
    using System.Collections.Generic;
    using System.Threading;
    using Nancy.ModelBinding;
    using System;

    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/product"] = parameters =>
            {
                //simulate long running app
                Thread.Sleep(500);
                this.Context.Trace.TraceLog.WriteLog(x=>x.AppendLine(string.Format("Get /product Called at {0} with parameters {1}", DateTime.Now, parameters.Id)));
                return new List<Product>{
                    new Product{Name ="beta",Id = 1},
                    new Product{Name = "alpha",Id=2}
                };
            };

            Get["/product/{id}"] = parameters =>
            {
                Thread.Sleep(1000);
                this.Context.Trace.TraceLog.WriteLog(x=>x.AppendLine(string.Format("Get /product/{id} Called at {0} with parameters {1}", DateTime.Now, parameters.Id)));
                return new Product { Name = "beta", Id = parameters.Id };
            };

            Delete["/product/{id}"] = parameters =>
            {
                Thread.Sleep(500);
                return HttpStatusCode.NoContent;
            };

            Post["/product/{id}"] = parameters =>
            {
                var product = this.Bind<Product>();
                Thread.Sleep(500);
                this.Context.Trace.TraceLog.WriteLog(x=>x.AppendLine(string.Format("Post Called at {0} with parameters {1}", DateTime.Now, product.Name)));
                if (string.IsNullOrEmpty(product.Name))
                {
                    return HttpStatusCode.NotAcceptable;
                }
                else
                {
                    return HttpStatusCode.NoContent;
                }
            };

            Put["product/{id}"] = parameters =>
            {
                var product = this.Bind<Product>();
                Thread.Sleep(500);
                this.Context.Trace.TraceLog.WriteLog(x=>x.AppendLine(string.Format("Put Called at {0} with parameters {1}", DateTime.Now, product.Name)));
                if (string.IsNullOrEmpty(product.Name))
                {
                    return HttpStatusCode.NotAcceptable;
                }
                else
                {
                    return HttpStatusCode.NoContent;
                }
            };
        }
    }
}