ScriptCs.Barrage
================

Barrage is a framework for testing restful api's, written in C#.

In a unit test Barrage can be used like this:

``` 
var scenario = _scenarioFactory.CreateBarrageScenrio();
scenario.Configure("http://localhost.fiddler:8080", "test Chain Get then Post");
scenario.Add(new Get("/product/1",
(requestResponse)=>{
  var response = ResponseContent.Convert(requestResponse.Content).Result;
  return new Post("/product/", new{ Id = response.Id });
  }));
  await scenario.Start();
```
