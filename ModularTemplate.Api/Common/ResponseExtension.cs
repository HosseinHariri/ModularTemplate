using ModularTemplate.Framework;
using System.Linq;

namespace ModularTemplate.Presentation.Server.Common
{
    public static class ResponseExtension
    {
        public static IApiResponse ToApiResponse(this IResponse queryResponse)
        {
            var message = queryResponse.Messages != null && queryResponse.Messages.Any()
                ? queryResponse.Messages.FirstOrDefault()
                : "";

            var response = new ApiResponse()
            {
                isSuccess = true,
                message = message,
            };

            return response;
        }

        public static IApiResponse ToApiResponse<T>(this IResponse<T> queryResponse)
        {
            var message = queryResponse.Messages != null && queryResponse.Messages.Any()
                ? queryResponse.Messages.FirstOrDefault()
                : "";

            var response = new ApiResponse<T>()
            {
                isSuccess = true,
                message = message,
                data = queryResponse.Data
            };

            return response;
        }
    }
}