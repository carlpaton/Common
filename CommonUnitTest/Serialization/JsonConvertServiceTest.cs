using Common.Serialization;
using Common.Serialization.Interface;
using CommonUnitTest.Serialization.Model;
using FluentAssertions;
using Microsoft.AspNetCore.Http.Internal;
using NUnit.Framework;
using System.IO;

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

        [Test]
        public void XmlFileToObject_given_valid_FormFile_should_deserialize_to_object()
        {
            // Arrange
            IJsonConvertService classUnderTest = new JsonConvertService();

            var content = "<?xml version=\"1.0\" encoding=\"utf-8\"?>";
            content += "<packages>";
            content += "<package id =\"BeITMemcached\" version=\"1.4.0\" targetFramework=\"net461\" />";
            content += "<package id =\"Castle.Core\" version=\"3.2.0\" targetFramework=\"net45\" />";
            content += "</packages>";
            
            var fileName = "packages.config";
            var memoryStream = new MemoryStream();
            var streamWriter = new StreamWriter(memoryStream);
            streamWriter.Write(content);
            streamWriter.Flush();
            memoryStream.Position = 0;

            var formFile = new FormFile(memoryStream, 0, memoryStream.Length, "name", fileName);
            var expected = new PackagesConfigFileModel()
            {
                packages = new Packages() 
                { 
                    package = new System.Collections.Generic.List<Package>() 
                    {
                        new Package()
                        {
                            id = "BeITMemcached",
                            version = "1.4.0"
                        },
                        new Package()
                        {
                            id = "Castle.Core",
                            version = "3.2.0"
                        }
                    }
                }
            };

            // Act
            var actual = classUnderTest.XmlFileToObject<PackagesConfigFileModel>(formFile);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }
    }
}
