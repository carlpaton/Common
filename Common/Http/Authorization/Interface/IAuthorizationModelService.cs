using Common.DateTime.Interface;
using Common.Encoding.Interface;
using Common.Http.Authorization.Model;

namespace Common.Http.Authorization.Interface
{
    public interface IAuthorizationModelService
    {
        /// <summary>
        /// Parameters come from `Configuration.GetSection("X").Value` in the consumers `Startup.cs`
        /// If null or empty reads `Environment.GetEnvironmentVariable("X")`
        /// </summary>
        /// <param name="usernameBasic"></param>
        /// <param name="passwordBasic"></param>
        /// <returns></returns>
        BasicAuthModel GetBasicAuthModel(string usernameBasic,  string passwordBasic);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oAuthAppsettingsModel">
        /// Parameter object values come from `Configuration.GetSection("X").Value` in the consumers `Startup.cs`
        /// If null or empty reads `Environment.GetEnvironmentVariable("X")`
        /// </param>
        /// <param name="dateTimeNow"></param>
        /// <param name="elapsedTimeService"></param>
        /// <param name="encodingService"></param>
        /// <returns></returns>
        OAuthModel GetOAuthModel(OAuthAppsettingsModel oAuthAppsettingsModel, System.DateTime dateTimeNow, IElapsedTimeService elapsedTimeService, IEncodingService encodingService);
    }
}
