using Million.Properties.Domain.Entities;
using Million.Properties.Domain.Interfaces;
using Million.Properties.Domain.Ports;

namespace Application.Services
{
    public class PropertiesService(IDbRepository dBRepository, IUnsplashService unsplashService) : IPropertiesService
    {
        public async Task<List<Property>> GetProperties()
        {
            var properties = await dBRepository.GetPropertiesWithDetailsAsync();
            
            return properties;
        }
        
        public async Task<List<Property>> PopulateProperties()
        {
            var (owners, properties, images, traces) = await DataGeneratorService.GenerateRandomDataAsync(10, unsplashService);
            
            await dBRepository.InsertManyOwnersAsync(owners);
            await dBRepository.InsertManyPropertiesAsync(properties);
            await dBRepository.InsertManyPropertyImagesAsync(images);
            await dBRepository.InsertManyPropertyTracesAsync(traces);

            var result = await GetProperties();
            
            return result;
        }
    }
}
