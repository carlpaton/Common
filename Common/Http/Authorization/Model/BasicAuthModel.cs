namespace Common.Http.Authorization.Model
{
    /// <summary>
    /// Basic Auth Model
    /// </summary>
    public class BasicAuthModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public bool IsNullOrEmpty()
        {
            return string.IsNullOrEmpty(Username)
                || string.IsNullOrEmpty(Password);
        }
    }
}
