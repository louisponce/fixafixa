using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Reflection;

namespace Api
{
    public static class DemoFunction
    {
        [FunctionName("DemoFunction")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var binpath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var roothpath = Path.GetFullPath(Path.Combine(binpath, ".."));

            var people = JsonConvert.DeserializeObject<SharedGlobal.Person[]>(File.ReadAllText(Path.Combine(roothpath, "people-sample.json")));
            return new OkObjectResult(people);
        }
    }
}
