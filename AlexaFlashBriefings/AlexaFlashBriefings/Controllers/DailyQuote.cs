using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlexaFlashBriefings.Controllers
{
    [Route("api/[controller]")]
    public class DailyQuoteController : BaseController
    {
        private const string URL = "http://quotesondesign.com/wp-json/posts?filter[orderby]=rand&filter[posts_per_page]=1";

        [HttpGet]
        public override async Task<IActionResult> Get()
        {
            var result = await GetJson<List<Models.DailyQuote.JsonObj>>(URL);

            if (result.Count == 0)
                return NotFound();
            
            var quote = result[0];

            quote.content = quote.content.Replace("<p>","");
            quote.content = quote.content.Replace("</p>\n", "");
            
            return Ok(await GetResponse("DailyQuote", $"{quote.content} - {quote.title}", null));
        }
    }
}