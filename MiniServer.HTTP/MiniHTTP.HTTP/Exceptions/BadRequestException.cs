using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniHTTP.HTTP.Exceptions
{
    public class BadRequestException:Exception
    {
        public BadRequestException()
            : base("The Request was malformed or contains unsupported elements.")
        {
        }
        public BadRequestException(string message) : base(message) { }
    }
}
