namespace Common.Http.Authorization.Model
{
    /// <summary>
    /// OAuth 1.0 Model
    /// 
    /// https://oauth.net/core/1.0/
    /// </summary>
    public class OAuthModel : OAuthAppsettingsModel
    {
        /// <summary>
        /// The signature method the Consumer used to sign the request.
        /// 
        /// Example: PLAINTEXT
        /// </summary>
        public string SignatureMethod { get; private set; }

        /// <summary>
        /// Unless otherwise specified by the Service Provider, the timestamp is expressed in the number of seconds since January 1, 1970 00:00:00 GMT. The timestamp value MUST be a positive integer and MUST be equal or greater than the timestamp used in previous requests.
        /// 
        /// Example: 1579220112
        /// </summary>
        public string TimeStamp { get; set; }

        /// <summary>
        /// The Consumer SHALL then generate a Nonce value that is unique for all requests with that timestamp. A nonce is a random string, uniquely generated for each request. The nonce allows the Service Provider to verify that a request has never been made before and helps prevent replay attacks when requests are made over a non-secure channel (such as HTTP).
        /// 
        /// Example: ShPKxisPFC0
        /// </summary>
        public string Nonce { get; set; }

        public OAuthModel() 
        {
            SignatureMethod = "PLAINTEXT";
        }

        public bool IsNullOrEmpty()
        {
            return string.IsNullOrEmpty(ConsumerKey)
                || string.IsNullOrEmpty(ConsumerSecret)
                || string.IsNullOrEmpty(AccessToken)
                || string.IsNullOrEmpty(TokenSecret)
                || string.IsNullOrEmpty(SignatureMethod)
                || string.IsNullOrEmpty(TimeStamp)
                || string.IsNullOrEmpty(Nonce);
        }
    }
}
