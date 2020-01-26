using Common.Serialization.Interface;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Common.Serialization
{
    public class DataContractJsonSerializerService : IDataContractJsonSerializerService
    {
        public string ToJson<T>(object obj)
        {
            var json = "[]";
            var dataContractJsonSerializer = new DataContractJsonSerializer(typeof(T));
            using (var memoryStream = new MemoryStream())
            {
                dataContractJsonSerializer.WriteObject(memoryStream, obj);
                memoryStream.Position = 0;
                using (var streamReader = new StreamReader(memoryStream))
                {
                    json = streamReader.ReadToEnd();
                    streamReader.Close();
                }
                memoryStream.Close();
            }
            return json;
        }
    }
}
