using System;
using System.IO;

namespace Common.Http.Interface
{
    public interface IHttpWebResponse : IDisposable
    {
        // expose the members you need
        Stream GetResponseStream();
    }
}
