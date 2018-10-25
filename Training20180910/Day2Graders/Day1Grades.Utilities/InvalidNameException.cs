using System;
using System.Runtime.Serialization;

namespace Day1Grades.Utilities
{
    [Serializable]
    public class InvalidNameException 
        : ApplicationException
    {
        public InvalidNameException()
        {
        }

        public InvalidNameException(string message) : base(message)
        {
        }

        public InvalidNameException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidNameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}