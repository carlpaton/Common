using Common.DateTime.Interface;
using Common.Encoding.Interface;
using Common.Http.Authorization;
using Common.Http.Authorization.Interface;
using Common.Http.Authorization.Model;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;

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

        [TestCase("username", "")]
        [TestCase("username", null)]
        [TestCase("", "password")]
        [TestCase(null, "password")]
        public void GetBasicAuthModel_given_null_or_empty_parameter_data_and_EnvironmentVariables_not_set_should_throw_Exception(
            string username, string password)
        {
            // Arrange
            IAuthorizationModelService classUnderTest = new AuthorizationModelService();

            // Act
            // Assert
            Assert.Throws<Exception>(() => classUnderTest.GetBasicAuthModel(username, password));
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

        [TestCase("", "consumerSecret", "accessToken", "tokenSecret", 1579220112d, "ShPKxisPFC0")]
        [TestCase("consumerKey", "", "accessToken", "tokenSecret", 1579220112d, "ShPKxisPFC0")]
        [TestCase("consumerKey", "consumerSecret", "", "tokenSecret", 1579220112d, "ShPKxisPFC0")]
        [TestCase("consumerKey", "consumerSecret", "accessToken", "", 1579220112d, "ShPKxisPFC0")]
        [TestCase("consumerKey", "consumerSecret", "accessToken", "tokenSecret", 0d, "ShPKxisPFC0")]
        [TestCase("consumerKey", "consumerSecret", "accessToken", "tokenSecret", 1579220112d, "")]

        [TestCase(null, "consumerSecret", "accessToken", "tokenSecret", 1579220112d, "ShPKxisPFC0")]
        [TestCase("consumerKey", null, "accessToken", "tokenSecret", 1579220112d, "ShPKxisPFC0")]
        [TestCase("consumerKey", "consumerSecret", null, "tokenSecret", 1579220112d, "ShPKxisPFC0")]
        [TestCase("consumerKey", "consumerSecret", "accessToken", null, 1579220112d, "ShPKxisPFC0")]
        [TestCase("consumerKey", "consumerSecret", "accessToken", "tokenSecret", null, "ShPKxisPFC0")]
        [TestCase("consumerKey", "consumerSecret", "accessToken", "tokenSecret", 1579220112d, null)]
        public void GetOAuthModel_given_null_or_empty_parameter_data_and_EnvironmentVariables_not_set_should_throw_Exception(
    string consumerKey, string consumerSecret, string accessToken, string tokenSecret,
    double mockUnixEpoch, string mockToBase64String)
        {
            // Arrange
            var oAuthAppsettingsModel = new OAuthAppsettingsModel()
            {
                ConsumerKey = consumerKey,
                ConsumerSecret = consumerSecret,
                AccessToken = accessToken,
                TokenSecret = tokenSecret
            };
            var dateTimeNow = System.DateTime.Now;
            var mockElapsedTimeService = new Mock<IElapsedTimeService>();
            var mockEncodingService = new Mock<IEncodingService>();
            IAuthorizationModelService classUnderTest = new AuthorizationModelService();

            mockElapsedTimeService
               .Setup(x => x.UnixEpoch(dateTimeNow))
               .Returns(mockUnixEpoch);

            mockEncodingService
               .Setup(x => x.ToBase64String(It.IsAny<string>()))
               .Returns(mockToBase64String);

            // Act
            // Assert
            Assert.Throws<Exception>(() => classUnderTest.GetOAuthModel(
                oAuthAppsettingsModel, 
                dateTimeNow, 
                mockElapsedTimeService.Object, 
                mockEncodingService.Object));
        }
    }
}
