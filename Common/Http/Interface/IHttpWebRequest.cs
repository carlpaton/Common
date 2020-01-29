namespace Common.Http.Interface
{
    public interface IHttpWebRequest
    {
        // expose the members you need
        string Method { get; set; }

        IHttpWebResponse GetResponse();
    }
}
