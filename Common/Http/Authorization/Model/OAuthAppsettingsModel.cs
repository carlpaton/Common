namespace Common.Http.Authorization.Model
{
    public class OAuthAppsettingsModel
    {
        /// <summary>
        /// The Consumer Key.
        /// </summary>
        public string ConsumerKey { get; set; }

        /// <summary>
        /// oauth_signature - https://oauth.net/core/1.0/#signing_process
        /// </summary>
        public string ConsumerSecret { get; set; }

        /// <summary>
        /// The Request Token obtained previously.
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// oauth_signature - https://oauth.net/core/1.0/#signing_process
        /// </summary>
        public string TokenSecret { get; set; }
    }
}
