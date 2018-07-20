using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AlexaFlashBriefings.Controllers
{
    public interface IController
    {
        Task<IActionResult> Get();
    }
}