using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo10_APIToken.Utility
{
    [AttributeUsage(AttributeTargets.Method)]
    public class FileResultContentTypeAttribute : Attribute
    {
        public FileResultContentTypeAttribute(string contentType)
        {
            ContentType = contentType;
        }
        public string ContentType { get; }
    }
}
