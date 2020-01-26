namespace Common.Http.Interface
{
    public interface IHttpService
    {
        T Get<T>(string endPoint);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="endPoint"></param>
        /// <param name="payLoad">
        /// `payLoad` parameter is serialized with `JsonConvert`
        /// </param>
        /// <returns></returns>
        T Post<T>(string endPoint, object payLoad);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="endPoint"></param>
        /// <param name="serializedPayLoad">
        /// `serializedPayLoad` parameter needs to be serialized with `DataContractJsonSerializer`
        /// </param>
        /// <returns></returns>
        T Post<T>(string endPoint, string serializedPayLoad);
    }
}
