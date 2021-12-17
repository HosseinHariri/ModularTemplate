using System.Collections.Generic;

namespace ModularTemplate.Framework
{
    public class Response : IResponse
    {
        public IEnumerable<string> Messages { get; internal set; }
    }

    public class Response<T> : Response, IResponse<T>
    {
        public T Data { get; internal set; }
    }
}