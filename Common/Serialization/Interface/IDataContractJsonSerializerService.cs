namespace Common.Serialization.Interface
{
    public interface IDataContractJsonSerializerService
    {
        /// <summary>
        /// System.Runtime.Serialization.Json.DataContractJsonSerializer
        /// 
        /// An older, Microsoft-developed serializer that was integrated in previous ASP.NET versions until Newtonsoft.Json replaced it.
        /// 
        /// https://docs.microsoft.com/en-us/dotnet/framework/wcf/samples/json-serialization
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        string ToJson<T>(object obj);
    }
}
