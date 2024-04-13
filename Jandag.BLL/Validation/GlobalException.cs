using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Jandag.BLL.Validation
{
    public class GlobalException : Exception
    {
        public GlobalException()
        {
        }

        public GlobalException(string? message) : base(message)
        {
        }

        public GlobalException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected GlobalException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
