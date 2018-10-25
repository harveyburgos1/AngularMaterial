using System;
using System.Runtime.Serialization;

namespace Day1Grades.Utilities
{
    [Serializable]
    public class InvalidGradeException 
        : ApplicationException
    {
        public InvalidGradeException()
        {
        }

        public InvalidGradeException(string message) : base(message)
        {
        }

        public InvalidGradeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidGradeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}