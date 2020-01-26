namespace Common.Serialization.Interface
{
    public interface IJsonConvertService
    {
        /// <summary>
        /// Newtonsoft.Json.JsonConvert
        /// 
        /// Serializes the specified object to a JSON string.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        string ToJson(object obj);

        /// <summary>
        /// Newtonsoft.Json.JsonConvert
        /// 
        /// Deserializes the JSON to the specified .NET type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="responseString"></param>
        /// <returns></returns>
        T ToObject<T>(string responseString);
    }
}
