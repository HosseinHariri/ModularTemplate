namespace ModularTemplate.Framework
{
    public class ResponseFactory
    {
        public static IResponse Success(string message = "")
        {
            return new Response
            {
                Messages = message.ToEnumerable()
            };
        }

        public static IResponse<T> Success<T>(T data, string message = "")
        {
            return new Response<T>
            {
                Messages = message.ToEnumerable(),
                Data = data
            };
        }
    }
}