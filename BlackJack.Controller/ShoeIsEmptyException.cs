using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Controller
{
    public class ShoeIsEmptyException : Exception
    {
        public ShoeIsEmptyException()
        {
        }

        public ShoeIsEmptyException(string? message) : base(message)
        {
        }

        public ShoeIsEmptyException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ShoeIsEmptyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
