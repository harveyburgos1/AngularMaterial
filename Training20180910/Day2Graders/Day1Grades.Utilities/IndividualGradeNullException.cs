using System;
using System.Runtime.Serialization;

namespace Day1Grades.Utilities
{
    [Serializable]
    public class IndividualGradeNullException : ApplicationException
    {
        public IndividualGradeNullException()
        {
        }

        public IndividualGradeNullException(string message) : base(message)
        {
        }

        public IndividualGradeNullException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected IndividualGradeNullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}