using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace MedStock.API.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("/error")]
    public class ErrorController : ControllerBase
    {
        [HttpGet]
        public IActionResult HandleError()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context?.Error;

            return Problem(
                title: "An unexpected error occurred.",
                detail: null, // ❌ jangan tampilkan detail error
                statusCode: 500
            );
        }
    }
}