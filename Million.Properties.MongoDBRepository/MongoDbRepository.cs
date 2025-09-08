using Million.Properties.Domain.Entities;
using Million.Properties.Domain.Ports;
using MongoDB.Driver;

namespace Million.Properties.MongoDBRepository
{
    public class MongoDbRepository : IDbRepository
    {
        private readonly IMongoDatabase _database;
        private readonly TimeSpan _ttl;

        public MongoDbRepository(MongoDbSettings settings)
        {
            var url = new MongoUrl(settings.ConnectionString);
            _ttl = TimeSpan.Parse(settings.TtlTimeSpan);
            var clientSettings = MongoClientSettings.FromUrl(url);
            var client = new MongoClient(clientSettings);
            _database = client.GetDatabase(url.DatabaseName);
        }

        public IMongoCollection<Owner> Owners => _database.GetCollection<Owner>("Owners");
        public IMongoCollection<Property> Properties => _database.GetCollection<Property>("Properties");

        public IMongoCollection<PropertyImage> PropertyImages =>
            _database.GetCollection<PropertyImage>("PropertyImages");

        public IMongoCollection<PropertyTrace> PropertyTraces =>
            _database.GetCollection<PropertyTrace>("PropertyTraces");

        // GET Collections
        public async Task<List<Property>> GetPropertiesWithDetailsAsync()
        {
            var properties = _database.GetCollection<Property>("Properties");
            var owners = _database.GetCollection<Owner>("Owners");
            var propertyImages = _database.GetCollection<PropertyImage>("PropertyImages");
            var propertyTraces = _database.GetCollection<PropertyTrace>("PropertyTraces");

            var pipeline = properties.Aggregate()
                .Lookup(
                    foreignCollection: owners,
                    localField: p => p.IdOwner,
                    foreignField: o => o.IdOwner,
                    @as: (Property p) => p.Owner
                )
                .Lookup(
                    foreignCollection: propertyImages,
                    localField: p => p.IdProperty,
                    foreignField: pi => pi.IdProperty,
                    @as: (Property p) => p.PropertyImages
                )
                .Lookup(
                    foreignCollection: propertyTraces,
                    localField: p => p.IdProperty,
                    foreignField: pt => pt.IdProperty,
                    @as: (Property p) => p.PropertyTraces
                )
                .Unwind("Owner", new AggregateUnwindOptions<Property> { PreserveNullAndEmptyArrays = true });

            var result = await pipeline.ToListAsync();

            return result;
        }

        // Insert Many Collection
        public async Task InsertManyOwnersAsync(IEnumerable<Owner> owners)
        {
            await Owners.InsertManyAsync(owners);
        }

        public async Task InsertManyPropertiesAsync(IEnumerable<Property> properties)
        {
            await Properties.InsertManyAsync(properties);
        }

        public async Task InsertManyPropertyImagesAsync(IEnumerable<PropertyImage> images)
        {
            await PropertyImages.InsertManyAsync(images);
        }

        public async Task InsertManyPropertyTracesAsync(IEnumerable<PropertyTrace> traces)
        {
            await PropertyTraces.InsertManyAsync(traces);
        }
    }
}