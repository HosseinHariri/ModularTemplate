using System.Collections.Generic;

namespace ModularTemplate.Framework
{
    public interface IResponse
    {
        IEnumerable<string> Messages { get; }
    }

    public interface IResponse<out T> : IResponse
    {
        T Data { get; }
    }
}