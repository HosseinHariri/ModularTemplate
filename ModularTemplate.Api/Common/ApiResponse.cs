using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ModularTemplate.Presentation.Server.Common
{
    public class ApiResponse : IApiResponse
    {
        public bool isSuccess { get; set; } 

        public string message { get; set; }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            ObjectResult actionResult = new ObjectResult(this);
            await actionResult.ExecuteResultAsync(context);
        }
    }

    public class ApiResponse<T> : ApiResponse, IApiResponse<T>
    {
        public T data { get; set; }

        public static implicit operator ActionResult(ApiResponse<T> data)
        {
            return new ObjectResult(data);
        }

        public static implicit operator ObjectResult(ApiResponse<T> data)
        {
            return new ObjectResult(data);
        }
    }

}
