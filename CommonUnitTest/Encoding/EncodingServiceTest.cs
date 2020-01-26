using Common.Encoding;
using Common.Encoding.Interface;
using NUnit.Framework;

namespace CommonUnitTest.Encoding
{
    public class EncodingServiceTest
    {
        [Test]
        public void ToBase64String_given_valid_data_should_return_base64_encoded_value()
        {
            // Arrange
            var expected = "dXNlcm5hbWU6cGFzc3dvcmQ=";
            var textToEncode = "username:password";
            IEncodingService classUnderTest = new EncodingService();

            // Act
            var actual = classUnderTest.ToBase64String(textToEncode);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
