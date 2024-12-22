using MiniHTTP.HTTP.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniHTTP.HTTP.Headers
{
    public class HttpHeader
    {
        public HttpHeader(string key, string value) 
        {
            CoreValidator.ThrowIfNullOrEmpty(text: key, name: nameof(key));
            CoreValidator.ThrowIfNullOrEmpty(text: value, name: nameof(value));

            this.Key = key;
            this.Value = value;
        }

        public static string ContentType { get; set; }
        public string Key { get; }
        public string Value { get; }
        public override string ToString()
        {
            return $"{this.Key}:{this.Value}";
        }

    }
}
