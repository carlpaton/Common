using Common.Serialization;
using Common.Serialization.Interface;
using CommonUnitTest.Serialization.Model;
using NUnit.Framework;

namespace CommonUnitTest.Serialization
{
    public class DataContractJsonSerializerServiceTest
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
            IDataContractJsonSerializerService classUnderTest = new DataContractJsonSerializerService();

            // Act
            var actual = classUnderTest.ToJson<DummyClassModel>(dummyClassModel);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
