using ModularTemplate.Framework;
using Microsoft.AspNetCore.Mvc;

namespace ModularTemplate.Presentation.Server.Common
{
    public class BaseController : Controller
    {
        protected IActionResult ResponseFrom(IResponse queryResponse)
        {
            return queryResponse.ToApiResponse();
        }

        protected IActionResult ResponseFrom<T>(IResponse<T> queryResponse)
        {
            return queryResponse.ToApiResponse();
        }
    }
}