using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlexaFlashBriefings.Controllers
{
    [Route("api/AlexaFlashBriefings/[controller]")]
    public class EthereumValue : BaseController
    {
        private const string URL = "https://cex.io/api/last_price/ETH/USD";

        [HttpGet]
        public override async Task<IActionResult> Get()
        {
            var result = await GetJson<Models.EthereumValue.JsonObj>(URL);

            var currencyPair = result;
            
            return Ok(await GetResponse("Price of Ethereum in USD", $"One {currencyPair.curr1} is {currencyPair.lprice} {currencyPair.curr2}", null));
        }
    }
}