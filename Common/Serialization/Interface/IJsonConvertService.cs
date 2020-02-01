using Microsoft.AspNetCore.Http;

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

        /// <summary>
        /// Newtonsoft.Json.JsonConvert
        /// 
        /// This was useful when converting XML files (packages.config, [x].csproj) to object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="postedFile">
        /// IFormFile used in .net core 2x MVC project
        /// </param>
        /// <returns></returns>
        T XmlFileToObject<T>(IFormFile postedFile);
    }
}
