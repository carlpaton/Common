namespace Common.Http.Interface
{
    /// <summary>
    /// Sweet work around to wrap the static methods by stackoverflow.com/users/64750/moribvndvs
    /// stackoverflow.com/questions/9823039/is-it-possible-to-mock-out-a-net-httpwebresponse/9823224
    /// </summary>
    public interface IHttpWebRequestFactory
    {
        IHttpWebRequest Create(string uri);
    }

}
