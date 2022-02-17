namespace Client.Services
{
    public class BaseEncodingService
    {
        public BaseEncodingService()
        {

        }
        public async Task<string> ToBase64String(Stream stream)
        {
            MemoryStream memoryStream = new();
            await stream.CopyToAsync(memoryStream);
            return Convert.ToBase64String(memoryStream.ToArray());
        }

    }
}
