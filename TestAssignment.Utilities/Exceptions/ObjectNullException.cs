using System.Collections.Generic;
using TestAssignment.Utilities.Common.Data;
using TestAssignment.Utilities.Common.Enums;

namespace TestAssignment.Utilities.Exceptions
{
    public class ObjectNullException : ExceptionBase
    {
        public ObjectNullException(string message = ErrorMessages.ObjectNull,
            IList<ErrorDetail> info = null) : base(message, ErrorCodes.ObjectNull, info)
        {
        }
    }
}