using MiniHTTP.HTTP.Common;
using MiniHTTP.HTTP.Enums;
using MiniHTTP.HTTP.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace MiniHTTP.HTTP.Responses
{
    public class HttpResponse : IHttpResponse
    {
        public HttpResponse(System.Net.HttpStatusCode statusCode)
        {
            this.Headers = new HttpHeaderCollection();
            this.Content = new byte[0];
        }
        public HttpResponse(HttpResponseStatusCode statusCode) : base()
        {
            CoreValidator.ThrowIfNull(statusCode, name: nameof(statusCode));
            this.StatusCode = statusCode;
        }
        public HttpResponseStatusCode StatusCode { get; set; }

        public IHttpHeaderCollection Headers {  get; }

        public byte[] Content { get; set; }

        public void AddHeader(HttpHeader header)
        {
            CoreValidator.ThrowIfNull(header, name: nameof(header));
            this.Headers.AddHeader(header);
        }

        public byte[] GetBytes()
        {
            // Конвертиране на ToString() в байтове
            byte[] headerBytes = System.Text.Encoding.UTF8.GetBytes(this.ToString() + "\r\n");

            // Обединяване на headerBytes и content
            byte[] responseBytes = new byte[headerBytes.Length + Content.Length];
            Buffer.BlockCopy(headerBytes, 0, responseBytes, 0, headerBytes.Length);
            Buffer.BlockCopy(Content, 0, responseBytes, headerBytes.Length, Content.Length);

            return responseBytes;
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result
                .Append($"{GlobalConstants.HttpOneProtocolFragment}{(int)this.StatusCode}{this.StatusCode.ToString()}")
                .Append(GlobalConstants.HttpNewLine)
                .Append(this.Headers)
                .Append(GlobalConstants.HttpNewLine);
                
                result.Append(GlobalConstants.HttpNewLine);

            return result.ToString();
        }
    }
}
