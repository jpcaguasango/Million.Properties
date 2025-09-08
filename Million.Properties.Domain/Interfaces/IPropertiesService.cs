using Million.Properties.Domain.Entities;

namespace Million.Properties.Domain.Interfaces;

public interface IPropertiesService
{
    Task<List<Property>> GetProperties();
    Task<List<Property>> PopulateProperties();
}
