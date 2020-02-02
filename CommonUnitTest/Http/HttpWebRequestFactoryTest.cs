using Common.Http.Interface;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.IO;
using System.Net;

namespace CommonUnitTest.Http
{
    public class HttpWebRequestFactoryTest
    {
        [Test]
        public void Create_with_valid_endpoint_should_create_request_and_respond_with_stream()
        {
            // Arrange
            var expected = "[{\"AllTheInts\":123,\"AllTheStrings\":\"I love christmas\"}]";
            var expectedBytes = System.Text.Encoding.UTF8.GetBytes(expected);
            
            var responseStream = new MemoryStream();
            responseStream.Write(expectedBytes, 0, expectedBytes.Length);
            responseStream.Seek(0, SeekOrigin.Begin);

            var mockResponse = new Mock<IHttpWebResponse>();
            var mockRequest = new Mock<IHttpWebRequest>();
            var mockFactory = new Mock<IHttpWebRequestFactory>();

            mockResponse
                .Setup(c => c.GetResponseStream())
                .Returns(responseStream);

            mockRequest
                .Setup(c => c.GetResponse())
                .Returns(mockResponse.Object);

            mockFactory
                .Setup(c => c.Create(It.IsAny<string>()))
                .Returns(mockRequest.Object);

            // Act
            var actualRequest = mockFactory.Object.Create("https://foo.com/");
            actualRequest.Method = WebRequestMethods.Http.Get;

            var actual = "";

            using (var httpWebResponse = actualRequest.GetResponse())
            {
                using (var streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    actual = streamReader.ReadToEnd();
                }
            }

            // Assert
            actual.Should().Be(expected);
        }
    }
}
