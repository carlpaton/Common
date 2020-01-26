using Common.Http.Authorization;
using Common.Http.Authorization.Interface;
using Common.Http.Authorization.Model;
using FluentAssertions;
using NUnit.Framework;

namespace CommonUnitTest.Http.Authorization
{
    public class HttpHeaderServiceTest
    {
        [Test]
        public void BasicAuth_given_valid_data_should_return_valid_HttpHeaderModel()
        {
            // Arrange
            var encodedAuthorization = "dXNlcm5hbWU6cGFzc3dvcmQ=";
            var expected = new HttpHeaderModel() 
            {
                Name = "Authorization",
                Value = $"Basic {encodedAuthorization}"
            };
            IHttpHeaderService classUnderTest = new HttpHeaderService();

            // Act
            var actual = classUnderTest.BasicAuth(encodedAuthorization);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void OAuth_given_valid_data_should_return_valid_HttpHeaderModel()
        {
            // Arrange
            var consumerKey = "ConsumerKey";
            var consumerSecret = "ConsumerSecret";
            var accessToken = "AccessToken";
            var tokenSecret = "TokenSecret";
            var timeStamp = "1579220112";
            var nonce = "ShPKxisPFC0";

            var expected = new HttpHeaderModel()
            {
                Name = "Authorization",
                Value = $"OAuth oauth_consumer_key=\"{consumerKey}\",oauth_token=\"{accessToken}\",oauth_signature_method=\"PLAINTEXT\",oauth_timestamp=\"{timeStamp}\",oauth_nonce=\"{nonce}\",oauth_version=\"1.0\",oauth_signature=\"{consumerSecret}%26{tokenSecret}\""
            };
            var oAuthModel = new OAuthModel()
            {
                ConsumerKey = consumerKey,
                ConsumerSecret = consumerSecret,
                AccessToken = accessToken,
                TokenSecret = tokenSecret,
                TimeStamp = timeStamp,
                Nonce = nonce
            };
            IHttpHeaderService classUnderTest = new HttpHeaderService();

            // Act
            var actual = classUnderTest.OAuth(oAuthModel);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }
    }
}
