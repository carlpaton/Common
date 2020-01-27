using Common.DateTime.Interface;
using Common.Encoding.Interface;
using Common.Http.Authorization.Interface;
using Common.Http.Authorization.Model;
using System;

namespace Common.Http.Authorization
{
    public class AuthorizationModelService : IAuthorizationModelService
    {
        public BasicAuthModel GetBasicAuthModel(string usernameBasic, string passwordBasic)
        {
            var username = !string.IsNullOrEmpty(usernameBasic) ? usernameBasic : Environment.GetEnvironmentVariable("USERNAME_BASIC");
            var password = !string.IsNullOrEmpty(passwordBasic) ? passwordBasic : Environment.GetEnvironmentVariable("PASSWORD_BASIC");

            var basicAuthModel = new BasicAuthModel() 
            { 
                Password = password,
                Username = username
            };

            if (basicAuthModel.IsNullOrEmpty())
                throw new Exception("BasicAuthModel IsNullOrEmpty, check keys in appsettings.json or provide keys in environment variables.");

            return basicAuthModel;
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

            var oAuthModel = new OAuthModel() 
            { 
                ConsumerKey = consumerKey,
                ConsumerSecret = consumerSecret,
                AccessToken = accessToken,
                TokenSecret = tokenSecret,
                TimeStamp = timeStamp,
                Nonce = nonce
            };

            if (oAuthModel.IsNullOrEmpty())
                throw new Exception("OAuthModel IsNullOrEmpty, check keys in appsettings.json or provide keys in environment variables.");

            return oAuthModel;
        }
    }
}
