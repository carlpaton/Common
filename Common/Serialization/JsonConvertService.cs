using Common.Serialization.Interface;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.IO;
using System.Xml;

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

        public T XmlFileToObject<T>(IFormFile postedFile)
        {
            using (var memoryStream = new MemoryStream())
            {
                postedFile.CopyTo(memoryStream);
                var xml = System.Text.Encoding.ASCII.GetString(memoryStream.ToArray());

                // HACK
                // `packages.config` starts with `???` which upsets things
                while (!xml.StartsWith("<"))
                {
                    xml = xml.Substring(1, xml.Length - 1);
                }

                var doc = new XmlDocument();
                doc.LoadXml(xml);
                var json = JsonConvert.SerializeXmlNode(doc);

                // HACK
                // `packages.config` had invalid @ prefix on properties
                if (json.Contains('@'))
                {
                    json = json.Replace("@", "");
                }

                return JsonConvert.DeserializeObject<T>(json);
            }
        }
    }
}
