using MiniHTTP.HTTP.Common;
using MiniHTTP.HTTP.Enums;
using MiniHTTP.HTTP.Exceptions;
using MiniHTTP.HTTP.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace MiniHTTP.HTTP.Requests
{
    internal class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString) 
        {
            CoreValidator.ThrowIfNullOrEmpty(text: requestString, name: nameof(requestString));

            this.FormData = new Dictionary<string, object>();
            this.QueryData = new Dictionary<string, object>();
            this.Headers = new HttpHeaderCollection();
            CoreValidator.ThrowIfNullOrEmpty(requestString, nameof(requestString));
            // Логика за парсване на заявката
            this.ParseRequest(requestString);
        }
            
        

        public string Path { get; private set; }

        public string Url { get; private set; }

        public Dictionary<string, object> FormData { get; }

        public Dictionary<string, object> QueryData { get; }

        public IHttpHeaderCollection Headers { get; }


        public HttpRequestMethod RequestMethod { get; private set; }

        private bool IsValidRequestLine(string[] requestLine)
        {
            throw new NotImplementedException();
        }
        private bool IsValidRequestQueryString(string queryString, string[] quertParameters)
        {
            throw new NotImplementedException();
        }
        private void ParseRequestMethod(string[] requestLine)
        {
            throw new NotImplementedException();
        }
        private void ParseRequestUrl(string[] requestLine)
        {
        throw new NotImplementedException();
        }
        private void ParseRequestPath()
        {
            throw new NotImplementedException();
        }
        private void ParseHeaders(string[] requestContent)
        {
                throw new NotImplementedException();
        }
        private void ParseCookies() 
        {  throw new NotImplementedException(); }
        private void ParseQueryParameters()
        {

        throw new NotImplementedException(); 
        }
        private void ParseFromDataParameters(string fromData)
        {

        throw new NotImplementedException(); 
        }
        private void ParseRequestParameters(string formData)
        {
            throw new NotImplementedException();
        }
        private void PareRequest(string requestString)
        {
            throw new NotImplementedException();
        }
        private void ParseRequest(string requestString)
        {
            string[]splitRequest= requestString.Split(separator:new[] { GlobalConstants.HttpNewLine },StringSplitOptions.None);
            string[] requestLine = splitRequest[0].Trim().Split(separator: new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

            if (!this.IsValidRequestLine(requestLine))
            {
                throw new BadRequestException();
            }
            this.ParseRequestMethod(requestLine);
            this.ParseRequestUrl(requestLine);
            this.ParseRequestPath();

            this.ParseHeaders(splitRequest.Skip(1).ToArray());
            this.ParseCookies();

            this.ParseRequestParameters(splitRequest[splitRequest.Length - 1]);
        }

        
    }
}
