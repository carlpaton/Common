using Common.Http.Authorization.Model;

namespace Common.Http.Authorization.Interface
{
    public interface IHttpHeaderService
    {
        /// <summary>
        /// OAuth is an authorization method used to provide access to resources over the HTTP protocol.
        /// 
        /// https://oauth.net/core/1.0/
        /// </summary>
        /// <param name="oAuthModel"></param>
        /// <returns></returns>
        HttpHeaderModel OAuth(OAuthModel oAuthModel);


        /// <summary>
        /// The Basic authentication is a common method to provide a username and password to a service.
        /// </summary>
        /// <param name="encodedAuthorization">
        /// Base64 Encoded string in format `username:password`
        /// </param>
        /// <returns></returns>
        HttpHeaderModel BasicAuth(string encodedAuthorization);
    }
}
