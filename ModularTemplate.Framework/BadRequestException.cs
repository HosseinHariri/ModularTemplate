using System;

namespace ModularTemplate.Framework
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {
        }
    }
}