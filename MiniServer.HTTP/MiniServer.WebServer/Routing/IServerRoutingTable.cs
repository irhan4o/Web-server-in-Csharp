using MiniHTTP.HTTP.Enums;
using MiniHTTP.HTTP.Requests;
using MiniHTTP.HTTP.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniServer.WebServer.Routing
{
    public interface IServerRoutingTable
    {
        void Add(HttpRequestMethod method, string path, Func<IHttpRequest,IHttpResponse> func);
        bool Contains(HttpRequestMethod requestMethod,string path);

        Func<IHttpRequest, IHttpResponse> Get(HttpRequestMethod requestMethod, string path);
    }
}
