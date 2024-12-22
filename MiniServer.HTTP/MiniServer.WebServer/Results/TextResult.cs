using MiniHTTP.HTTP.Enums;
using MiniHTTP.HTTP.Headers;
using MiniHTTP.HTTP.Responses;
using System;
using System.Net;
using System.Text;

namespace MiniServer.WebServer.Results
{
    public class TextResult : HttpResponse
    {
        private string v;
        private HttpResponseStatusCode badRequest;

        // Конструктор със string съдържание
        public TextResult(string content, HttpStatusCode responseStatusCode, string contentType = "text/plain; charset=utf-8")
            : base(responseStatusCode)
        {
            // Добавяне на Content-Type хедър
            this.Headers.AddHeader(new HttpHeader("Content-Type", contentType));

            // Конвертиране на съдържанието в байтове
            this.Content = Encoding.UTF8.GetBytes(content);
        }

        // Конструктор с byte[] съдържание
        public TextResult(byte[] content, HttpStatusCode statusCode)
            : base(statusCode)
        {
            // Добавяне на Content-Type хедър по подразбиране
            this.Headers.AddHeader(new HttpHeader("Content-Type", "text/plain; charset=utf-8"));

            // Задаване на байтовото съдържание
            this.Content = content;
        }

        public TextResult(string v, HttpResponseStatusCode badRequest)
        {
            this.v = v;
            this.badRequest = badRequest;
        }
    }
}
