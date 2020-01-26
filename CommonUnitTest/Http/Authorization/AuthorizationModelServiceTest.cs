using Common.DateTime.Interface;
using Common.Encoding.Interface;
using Common.Http.Authorization;
using Common.Http.Authorization.Interface;
using Common.Http.Authorization.Model;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace CommonUnitTest.Http.Authorization
{
    public class AuthorizationModelServiceTest
    {
        [Test]
        public void GetBasicAuthModel_given_valid_data_should_return_valid_BasicAuthModel()
        {
            // Arrange
            var username = "username";
            var password = "password";
            var expected = new BasicAuthModel()
            {
                Username = username,
                Password = password
            };
            IAuthorizationModelService classUnderTest = new AuthorizationModelService();

            // Act
            var actual = classUnderTest.GetBasicAuthModel(username, password);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void GetOAuthModel_given_valid_data_should_return_valid_OAuthModel()
        {
            // Arrange
            var consumerKey = "consumerKey";
            var consumerSecret = "consumerSecret";
            var accessToken = "accessToken";
            var tokenSecret = "tokenSecret";
            var timeStamp = 1579220112d;
            var nonce = "ShPKxisPFC0";
            var dateTimeNow = System.DateTime.Now;

            var oAuthAppsettingsModel = new OAuthAppsettingsModel() 
            {
                AccessToken = accessToken,
                ConsumerKey = consumerKey,
                ConsumerSecret = consumerSecret,
                TokenSecret = tokenSecret
            };

            var expected = new OAuthModel()
            {
                ConsumerKey = consumerKey,
                ConsumerSecret = consumerSecret,
                AccessToken = accessToken,
                TokenSecret = tokenSecret,
                TimeStamp = timeStamp.ToString(),
                Nonce = nonce
            };

            IAuthorizationModelService classUnderTest = new AuthorizationModelService();
            var mockElapsedTimeService = new Mock<IElapsedTimeService>();
            var mockEncodingService = new Mock<IEncodingService>();

            mockElapsedTimeService
               .Setup(x => x.UnixEpoch(dateTimeNow))
               .Returns(timeStamp);

            mockEncodingService
               .Setup(x => x.ToBase64String(timeStamp.ToString()))
               .Returns(nonce);

            // Act
            var actual = classUnderTest.GetOAuthModel(
                oAuthAppsettingsModel,
                dateTimeNow,
                mockElapsedTimeService.Object,
                mockEncodingService.Object);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }
    }
}
