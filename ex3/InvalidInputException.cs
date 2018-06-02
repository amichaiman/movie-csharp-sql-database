using System;

namespace ex3
{
    internal class InvalidInputException : Exception
    {
        public InvalidInputException(string message) : base(message) { }
    }
}