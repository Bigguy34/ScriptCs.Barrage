ScriptCs.Barrage
================

Barrage is a framework for testing restful api's, written in C#, with support for ScriptCs.

Barrage and ScriptCs.Barrage is also out on Nuget.

There are several goals of Barrage, Firstly Barrage strives for an elegant syntax for the user. Secondly Barrage although currently doesn't support reports, in the coming future will support html report generation (As of right Barrage is storing information on requests in a BrightStarDB). Thridly Barrage also stresses support for ScriptCs as a scripting solution to be able to quickly write api tests.

In a unit test Barrage can be used like this:

``` C#
var scenario = _scenarioFactory.CreateBarrageScenrio();
scenario.Configure("http://localhost:8080", "test Chain Get then Post");
scenario.Add(new Get("/product/1",
                    (requestResponse)=>{
                      var response = ResponseContent.Convert(requestResponse.Content).Result;
                      return new Post("/product/", new{ Id = response.Id });
            }));
  await scenario.Start();
```
If you require more examples there are several simple unit tests, and a sample api to test them out on included.


Barrage can also be used in a ScriptCs context:

```C#
  var barragePack = Require<BarragePack>();
  var http = Require<BarrageRequestPack>();
  var storageConfig = new StorageConfig{
    DbDirectory = @"C:\data",
  };
  barragePack.Load(storageConfig);

  var scenario = barragePack.CreateScenario("http://localhost:8080", "test Chain");
  scenario.Add(http.Get("/product/1"));
  scenario.Start().Wait();
```
Barrage of the Future (Features will be coming in this order):
1. Html Report Generation
2. Html Report Hooks to allow users
3. Load testing support(meaning introducing the idea of users into Barrage)
