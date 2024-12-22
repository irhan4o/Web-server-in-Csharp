using MiniHTTP.HTTP.Common;
using MiniHTTP.HTTP.Enums;
using MiniHTTP.HTTP.Exceptions;
using MiniHTTP.HTTP.Requests;
using MiniHTTP.HTTP.Responses;
using MiniServer.WebServer.Results;
using MiniServer.WebServer.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MiniServer.WebServer
{
    public class ConnectionHandler
    {
        private readonly Socket client;
        private readonly IServerRoutingTable table;
        public ConnectionHandler(Socket client, IServerRoutingTable table)
        {
            CoreValidator.ThrowIfNull(client, nameof(client));
            CoreValidator.ThrowIfNull(table, nameof(table));

            this.client = client;
            this.table = table;
        }
        private async Task<IHttpRequest> ReadRequest()
        {
            var result = new StringBuilder();
            var buffer = new byte[1024];

            while (true)
            {
                int numberOfBytesRead = await this.client.ReceiveAsync(new ArraySegment<byte>(buffer), SocketFlags.None);
                if (numberOfBytesRead == 0)
                {
                    break;
                }

                var bytesAsString = Encoding.UTF8.GetString(buffer, 0, numberOfBytesRead);
                result.Append(bytesAsString);

                if (numberOfBytesRead < buffer.Length)
                {
                    break;
                }
            }

            if (result.Length == 0)
            {
                return null;
            }

            return new HttpRequest(result.ToString());
        }

        public async Task ProcessRequestAsync()
        {
            try
            {
                var request = await ReadRequest();
                if(request != null)
                {
                    Console.WriteLine($"Processing:{request.RequestMethod} {request.Path}");
                    IHttpResponse response = HandleRequest(request);
                    PrepareResponse(response);
                }
            }
            catch(BadRequestException e)
            {
                PrepareResponse(new TextResult(e.ToString(), HttpResponseStatusCode.BadRequest));

            }
            catch(Exception e)
            {
                PrepareResponse(new TextResult(e.ToString(), HttpResponseStatusCode.InternalServerError));

            }
            client.Shutdown(SocketShutdown.Both);
        }
        private IHttpResponse HandleRequest(IHttpRequest request) 
        {
            if (!table.Contains(request.RequestMethod, request.Path))
            {
                return new TextResult($"Route with method {request.RequestMethod} and path {request.Path} not found.", HttpResponseStatusCode.NotFound);
            }
            return table.Get(request.RequestMethod, request.Path).Invoke(request);
        }
        private async Task PrepareResponse(IHttpResponse response)
        {
            byte[] bytes = response.GetBytes();
            await client.SendAsync(bytes, SocketFlags.None);
        }

    }
}
