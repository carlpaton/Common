using Common.Serialization.Interface;
using Newtonsoft.Json;

namespace Common.Serialization
{
    public class JsonConvertService : IJsonConvertService
    {
        public string ToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public T ToObject<T>(string responseString)
        {
            return JsonConvert.DeserializeObject<T>(responseString);
        }
    }
}
