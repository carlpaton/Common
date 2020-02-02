using Common.Http.Interface;
using Common.Http.Wrapper;
using System.Net;

namespace Common.Http
{
    public class HttpWebRequestFactory : IHttpWebRequestFactory
    {
        public IHttpWebRequest Create(string uri)
        {
            return new WrapHttpWebRequest((HttpWebRequest)WebRequest.Create(uri));
        }
    }
}
