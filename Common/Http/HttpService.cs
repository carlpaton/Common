using Common.Http.Authorization.Interface;
using Common.Http.Authorization.Model;
using Common.Http.Interface;
using Common.Serialization.Interface;
using System;
using System.IO;
using System.Net;

namespace Common.Http
{
    [Obsolete(message: "Please use `HttpWebRequestFactory`")]
    public class HttpService : IHttpService
    {
        private readonly string _contentType = "application/json; charset=utf-8";
        private readonly HttpHeaderModel _httpHeaderModel;

        private readonly IJsonConvertService _jsonConvertService;

        public HttpService(OAuthModel authModel, IHttpHeaderService httpHeaderService, IJsonConvertService jsonConvertService) 
        {
            _httpHeaderModel = httpHeaderService.OAuth(authModel);
            _jsonConvertService = jsonConvertService;
        }

        public T Get<T>(string endPoint)
        {
            var responseString = "";

            var request = (HttpWebRequest)WebRequest.Create(endPoint);
            request.Method = "GET";
            request.ContentType = _contentType;
            request.Headers.Add(_httpHeaderModel.Name, _httpHeaderModel.Value);

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                using (var dataStream = response.GetResponseStream())
                {
                    using (var streamReader = new StreamReader(dataStream))
                    {
                        responseString = streamReader.ReadToEnd();
                        streamReader.Close();
                    }
                }
            }

            return _jsonConvertService.ToObject<T>(responseString);
        }

        public T Post<T>(string endPoint, object payLoad)
        {
            var serializedPayLoad = _jsonConvertService.ToJson(payLoad);
            var data = System.Text.Encoding.ASCII.GetBytes(serializedPayLoad);
            var responseString = "";

            var request = (HttpWebRequest)WebRequest.Create(endPoint);
            request.Method = "POST";
            request.ContentType = _contentType;
            request.Headers.Add(_httpHeaderModel.Name, _httpHeaderModel.Value);
            request.ContentLength = data.Length;

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(serializedPayLoad);
            }

            var response = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                responseString = streamReader.ReadToEnd().ToString();
                streamReader.Close();
            }

            return _jsonConvertService.ToObject<T>(responseString);
        }

        public T Post<T>(string endPoint, string serializedPayLoad)
        {
            var data = System.Text.Encoding.ASCII.GetBytes(serializedPayLoad);
            var responseString = "";

            var request = (HttpWebRequest)WebRequest.Create(endPoint);
            request.Method = "POST";
            request.ContentType = _contentType;
            request.Headers.Add(_httpHeaderModel.Name, _httpHeaderModel.Value);
            request.ContentLength = data.Length;

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(serializedPayLoad);
            }

            var response = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                responseString = result.ToString();
            }

            return _jsonConvertService.ToObject<T>(responseString);
        }
    }
}
