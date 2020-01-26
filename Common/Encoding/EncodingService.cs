using Common.Encoding.Interface;

namespace Common.Encoding
{
    public class EncodingService : IEncodingService
    {
        public string ToBase64String(string text)
        {
            var byteArray = System.Text.Encoding.ASCII.GetBytes(text);
            return System.Convert.ToBase64String(byteArray);
        }
    }
}
