using Million.Properties.Domain.Entities;

namespace Million.Properties.Domain.Ports
{
    public interface IDbRepository
    {
        Task<List<Property>> GetPropertiesWithDetailsAsync();
        Task InsertManyOwnersAsync(IEnumerable<Owner> owners);
        Task InsertManyPropertiesAsync(IEnumerable<Property> properties);
        Task InsertManyPropertyImagesAsync(IEnumerable<PropertyImage> images);
        Task InsertManyPropertyTracesAsync(IEnumerable<PropertyTrace> traces);
    }
}