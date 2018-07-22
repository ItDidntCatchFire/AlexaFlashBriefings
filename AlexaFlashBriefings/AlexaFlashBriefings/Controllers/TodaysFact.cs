using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AlexaFlashBriefings.Controllers
{
    [Route("api/AlexaFlashBriefings/[controller]")]
    public class TodaysFact : BaseController
    {
        private const string URL = "http://numbersapi.com/";

        [HttpGet]
        public override async Task<IActionResult> Get()
        {
            DateTime dateTime = DateTime.Now;

            var result = await GetJson<Models.TodaysFact.JsonObj>($"{URL}{dateTime.Month}/{dateTime.Day}/date?json");

            var fact = result;

            return Ok(await GetResponse("Todays Fact", fact.text, null));
        }
    }
}