using MiniHTTP.HTTP.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MiniServer.WebServer.Results
{
    internal class RedirectResult : HttpResponse
    {
        public RedirectResult(string location) : base(MiniHTTP.HTTP.Enums.HttpResponseStatusCode.SeeOther)
        {
            this.Headers.AddHeader(new MiniHTTP.HTTP.Headers.HttpHeader("Location", location));
        }
    }
}
