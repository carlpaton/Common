using Common.Serialization;
using Common.Serialization.Interface;
using CommonUnitTest.Serialization.Model;
using FluentAssertions;
using NUnit.Framework;

namespace CommonUnitTest.Serialization
{
    public class JsonConvertServiceTest
    {
        [Test]
        public void ToJson_given_valid_data_should_return_json()
        {
            // Arrange
            var expected = "{\"AllTheInts\":123,\"AllTheStrings\":\"I love my family\"}";
            var dummyClassModel = new DummyClassModel()
            {
                AllTheInts = 123,
                AllTheStrings = "I love my family"
            };
            IJsonConvertService classUnderTest = new JsonConvertService();

            // Act
            var actual = classUnderTest.ToJson(dummyClassModel);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToObject_given_valid_json_should_deserialize_to_object()
        {
            // Arrange
            var responseString = "{\"AllTheInts\":123,\"AllTheStrings\":\"I love christmas\"}";
            var expected = new DummyClassModel()
            {
                AllTheInts = 123,
                AllTheStrings = "I love christmas"
            };
            IJsonConvertService classUnderTest = new JsonConvertService();

            // Act
            var actual = classUnderTest.ToObject<DummyClassModel>(responseString);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }
    }
}
