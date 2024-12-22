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
    internal class ServerRoutingTable : IServerRoutingTable
    {
        private readonly Dictionary<HttpRequestMethod, Dictionary<string, Func<IHttpRequest, IHttpResponse>>> roites;
        public ServerRoutingTable()
        {
            this.roites = new Dictionary<HttpRequestMethod, Dictionary<string, Func<IHttpRequest, IHttpResponse>>>
            {
                [HttpRequestMethod.Get]= new Dictionary<string, Func<IHttpRequest, IHttpResponse>>(),
                [HttpRequestMethod.Post]=new Dictionary<string, Func<IHttpRequest, IHttpResponse>>(),
                [HttpRequestMethod.Put]=new Dictionary<string, Func<IHttpRequest, IHttpResponse>>(),
                [HttpRequestMethod.Delete]=new Dictionary<string, Func<IHttpRequest, IHttpResponse>>()
            };
        }
        public void Add(HttpRequestMethod method, string path, Func<IHttpRequest, IHttpResponse> func)
        {
            throw new NotImplementedException();
        }

        public bool Contains(HttpRequestMethod requestMethod, string path)
        {
            throw new NotImplementedException();
        }

        public Func<IHttpRequest, IHttpResponse> Get(HttpRequestMethod requestMethod, string path)
        {
            throw new NotImplementedException();
        }
    }
}
