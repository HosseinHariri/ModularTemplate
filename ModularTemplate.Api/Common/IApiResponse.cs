using Microsoft.AspNetCore.Mvc;

namespace ModularTemplate.Presentation.Server.Common
{
    public interface IApiResponse : IActionResult
    {
        bool isSuccess { get; set; }

        string message { get; set; }
    }

    public interface IApiResponse<out T> : IApiResponse
    {
        T data { get; }
    }
}