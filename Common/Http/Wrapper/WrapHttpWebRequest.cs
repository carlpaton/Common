using Common.Http.Authorization.Model;
using Common.Http.Interface;
using System.Net;

namespace Common.Http.Wrapper
{
    public class WrapHttpWebRequest : IHttpWebRequest
    {
        private readonly HttpWebRequest _request;

        public WrapHttpWebRequest(HttpWebRequest request)
        {
            _request = request;
        }

        public string Method
        {
            get { return _request.Method; }
            set { _request.Method = value; }
        }

        public string ContentType
        {
            get { return _request.ContentType; }
            set { _request.ContentType = value; }
        }

        public void SetHeader(HttpHeaderModel httpHeaderModel)
        {
            _request.Headers.Add(httpHeaderModel.Name, httpHeaderModel.Value);
        }

        public IHttpWebResponse GetResponse()
        {
            return new WrapHttpWebResponse((HttpWebResponse)_request.GetResponse());
        }
    }
}
