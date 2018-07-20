using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AlexaFlashBriefings.Controllers
{
    public abstract class BaseController : Controller, IController
    {
        private readonly HttpClient client;

        public abstract Task<IActionResult> Get();

        public BaseController()
        {
            client = new HttpClient();
        }

        protected async Task<T> GetJson<T>(string url)
        {
            var HttpResult = await client.GetAsync(url);

            string json = await HttpResult.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(json);
        }

        public async Task<Models.AlexaResponse> GetResponse(string title, string main, string url)
        {
            main = main.Replace("&#8217;", "'");
            main = main.Replace("&#8220;", "\"");
            main = main.Replace("&#8211;", "–");
            main = main.Replace("&#8230;", "...");

            Models.AlexaResponse response =
                new Models.AlexaResponse()
                {
                    uid = "urn:uuid:1335c695-cfb8-4ebb-abbd-80da344efa6b",
                    updateDate = DateTime.Now,
                    titleText = title,
                    mainText = main,
                    redirectionUrl = url
                };

            return response;
        }
    }
}