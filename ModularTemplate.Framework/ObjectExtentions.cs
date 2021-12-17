using System.Collections.Generic;

namespace ModularTemplate.Framework
{
    public static class ObjectExtentions
    {
        public static IEnumerable<T> ToEnumerable<T>(this T value)
        {
            yield return value;
        }
    }
}