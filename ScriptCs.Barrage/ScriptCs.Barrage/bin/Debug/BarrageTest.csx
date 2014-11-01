var barragePack = Require<BarragePack>();
var scenario = barragePack.CreateScenario();
 scenario.Configure("http://localhost:8080", "test Chain");
            scenario.Add(new Get("/product/1",
                (requestResponse)=>{
                    return new Post("/product/", new { Name = "TomIsAwesome" });
                }));
