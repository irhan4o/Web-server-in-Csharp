using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniHTTP.HTTP.Exceptions
{
    public class InternalServerErrorException:Exception
    {
        public InternalServerErrorException()
            :base("The Server has encountered an error.") { }

        public InternalServerErrorException(string message) : base(message) { }
    }
}
