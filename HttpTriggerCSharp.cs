
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using System.Net.Http;

namespace microsoft.jcfaas.eventgridproxy
{
    public static class HttpTriggerCSharp
    {
        [FunctionName("HttpTriggerCSharp")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequest req, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];
            string url = req.Query["url"];

            string requestBody = new StreamReader(req.Body).ReadToEnd();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;
            url = url ?? data?.url;

            string proxy_respose =  $"User:{name}\nSent {requestBody}\nTo: {url}";

            HttpClient client = new HttpClient();
            if (!string.IsNullOrEmpty(url))
            {
                client.PostAsync(url, new StringContent(proxy_respose));
            }
            
            return name != null
                ? (ActionResult)new OkObjectResult(proxy_respose)
                : new BadRequestObjectResult("Please pass a &name= and &url on the query string or in the request body");
        }
    }
}
