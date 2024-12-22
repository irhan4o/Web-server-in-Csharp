using MiniHTTP.HTTP.Enums;
using MiniHTTP.HTTP.Requests;
using MiniHTTP.HTTP.Responses;
using MiniServer.WebServer.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniHTTP.Demo
{
    public class HomeController
    {
        public IHttpResponse Index(IHttpRequest request)
        {
            string content = "<h1>Hello World</h1>";
            return new HtmlResult(content, HttpResponseStatusCode.Ok);
        }
    }
}
