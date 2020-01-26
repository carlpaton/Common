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
        /// Serialized with `JsonConvert`
        /// </param>
        /// <returns></returns>
        T Post<T>(string endPoint, object payLoad);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="endPoint"></param>
        /// <param name="serializedPayLoad">
        /// Serialized with `DataContractJsonSerializer`
        /// </param>
        /// <returns></returns>
        T Post<T>(string endPoint, string serializedPayLoad);
    }
}
