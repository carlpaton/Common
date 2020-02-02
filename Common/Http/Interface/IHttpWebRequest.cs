using Common.Http.Authorization.Model;

namespace Common.Http.Interface
{
    public interface IHttpWebRequest
    {
        string Method { get; set; }
        string ContentType { get; set; }
        void SetHeader(HttpHeaderModel httpHeaderModel);

        IHttpWebResponse GetResponse();
    }
}
