
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace microsoft.jcfaas
{
    public static class eventgrid
    {
        [FunctionName("eventgrid")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequest req, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string validationCode = req.Query["validationCode"];

            string requestBody = new StreamReader(req.Body).ReadToEnd();
            dynamic payload = JsonConvert.DeserializeObject(requestBody);
            validationCode = validationCode ?? payload[0]?.data?.validationCode;

            return validationCode != null
                ? (ActionResult)new OkObjectResult("{\"validationResponse\": \"" + validationCode + "\" }") : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }
    }
}
