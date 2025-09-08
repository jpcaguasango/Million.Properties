namespace Million.Properties.Domain.Ports
{
    public interface IUnsplashService
    {
        Task<string> SearchImagenAsync(string query);
    }
}