using Common.DateTime.Interface;
using Common.Encoding.Interface;
using Common.Http.Authorization.Interface;
using Common.Http.Authorization.Model;
using System;

namespace Common.Http.Authorization
{
    public class AuthorizationModelService : IAuthorizationModelService
    {
        public BasicAuthModel GetBasicAuthModel(string username, string password)
        {
            var _username = !string.IsNullOrEmpty(username) ? username : Environment.GetEnvironmentVariable("USERNAME");
            var _password = !string.IsNullOrEmpty(password) ? password : Environment.GetEnvironmentVariable("PASSWORD");

            return new BasicAuthModel() 
            { 
                Password = _password,
                Username = _username
            };
        }

        public OAuthModel GetOAuthModel(OAuthAppsettingsModel oAuthAppsettingsModel, System.DateTime dateTimeNow, IElapsedTimeService elapsedTimeService, IEncodingService encodingService)
        {
            var consumerKey = !string.IsNullOrEmpty(oAuthAppsettingsModel.ConsumerKey) ? oAuthAppsettingsModel.ConsumerKey : Environment.GetEnvironmentVariable("CONSUMER_KEY");
            var consumerSecret = !string.IsNullOrEmpty(oAuthAppsettingsModel.ConsumerSecret) ? oAuthAppsettingsModel.ConsumerSecret : Environment.GetEnvironmentVariable("CONSUMER_SECRET");
            var accessToken = !string.IsNullOrEmpty(oAuthAppsettingsModel.AccessToken) ? oAuthAppsettingsModel.AccessToken : Environment.GetEnvironmentVariable("ACCESS_TOKEN");
            var tokenSecret = !string.IsNullOrEmpty(oAuthAppsettingsModel.TokenSecret) ? oAuthAppsettingsModel.TokenSecret : Environment.GetEnvironmentVariable("TOKEN_SECRET");
            
            var timeStamp = elapsedTimeService
                .UnixEpoch(dateTimeNow)
                .ToString();
            
            var nonce = encodingService
                .ToBase64String(timeStamp);

            return new OAuthModel() 
            { 
                ConsumerKey = consumerKey,
                ConsumerSecret = consumerSecret,
                AccessToken = accessToken,
                TokenSecret = tokenSecret,
                TimeStamp = timeStamp,
                Nonce = nonce
            };
        }
    }
}
