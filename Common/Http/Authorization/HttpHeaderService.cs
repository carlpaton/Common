using Common.Http.Authorization.Interface;
using Common.Http.Authorization.Model;
using System;

namespace Common.Http.Authorization
{
    public class HttpHeaderService : IHttpHeaderService
    {
        public HttpHeaderModel BasicAuth(string encodedAuthorization)
        {
            return new HttpHeaderModel()
            {
                Name = "Authorization",
                Value = $"Basic {encodedAuthorization}"
            };
        }

        public HttpHeaderModel OAuth(OAuthModel oAuthModel)
        {
            // TODO ~ unit test this path, consider custom exception?
            if (oAuthModel.IsNullOrEmpty())
                throw new Exception("oAuthModel IsNullOrEmpty, check keys in appsettings.json or provide keys in environment variables.");

            return new HttpHeaderModel()
            {
                Name = "Authorization",
                Value = $"OAuth oauth_consumer_key=\"{oAuthModel.ConsumerKey}\",oauth_token=\"{oAuthModel.AccessToken}\",oauth_signature_method=\"{oAuthModel.SignatureMethod}\",oauth_timestamp=\"{oAuthModel.TimeStamp}\",oauth_nonce=\"{oAuthModel.Nonce}\",oauth_version=\"1.0\",oauth_signature=\"{oAuthModel.ConsumerSecret}%26{oAuthModel.TokenSecret}\""
            };
        }
    }
}
