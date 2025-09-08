using MongoDB.Bson;
using Million.Properties.Domain.Entities;
using Million.Properties.Domain.Ports;

namespace Application.Services
{
    public static class DataGeneratorService
    {
        private static readonly Random random = new Random();

        public static async
            Task<(List<Owner> owners, List<Property> properties, List<PropertyImage> images, List<PropertyTrace> traces
                )> GenerateRandomDataAsync(int count, IUnsplashService unsplashService)
        {
            var owners = new List<Owner>();
            var properties = new List<Property>();
            var images = new List<PropertyImage>();
            var traces = new List<PropertyTrace>();

            // Listas de datos para la generación
            var propertyNames = new List<string>
            {
                "Luxurious Apartment", "Country House", "Modern Loft", "Central Apartment", "Cozy Studio",
                "Villa with Pool", "Spacious Penthouse", "Bungalow by the Sea", "Family Chalet", "Townhouse"
            };
            var cities = new List<string>
            {
                "Nueva York", "Londres", "Tokio", "París", "Sídney", "Dubái", "Madrid", "Barcelona", "Roma", "Berlín"
            };

            for (int i = 0; i < count; i++)
            {
                var newOwnerId = ObjectId.GenerateNewId().ToString();
                var newPropertyId = ObjectId.GenerateNewId().ToString();
                
                // Obtener una imagen de Unsplash para el propietario
                string? ownerImageUrl = await unsplashService.SearchImagenAsync("person");

                // Crea un nuevo Owner
                var owner = new Owner
                {
                    IdOwner = newOwnerId,
                    Name = $"Owner {i + 1}",
                    Address = $"{random.Next(1, 1000)} Calle {cities[random.Next(cities.Count)]}",
                    Photo = ownerImageUrl,
                    Birthday = DateTime.UtcNow.AddYears(-random.Next(25, 60))
                };
                owners.Add(owner);

                // Crea una nueva Property
                var property = new Property
                {
                    IdProperty = newPropertyId,
                    Name = propertyNames[random.Next(propertyNames.Count)],
                    Address = $"Calle {cities[random.Next(cities.Count)]} {random.Next(1, 500)}",
                    Price = random.Next(100000, 5000000) * 1.00m,
                    CodeInternal = $"Prop-{random.Next(1000, 9999)}",
                    Year = random.Next(2000, 2025),
                    IdOwner = newOwnerId,
                };
                properties.Add(property);

                // Obtener una imagen de Unsplash para la propiedad
                string? propertyImageUrl = await unsplashService.SearchImagenAsync("house");
                
                var propertyImage = new PropertyImage
                {
                    IdPropertyImage = ObjectId.GenerateNewId().ToString(),
                    IdProperty = newPropertyId,
                    file = propertyImageUrl ?? "default_image.jpg",
                    Enabled = true
                };
                images.Add(propertyImage);
                
                var propertyTrace = new PropertyTrace
                {
                    IdPropertyTrace = ObjectId.GenerateNewId().ToString(),
                    DateSale = DateTime.UtcNow,
                    Name = "Venta",
                    Value = property.Price * 1.05m,
                    Tax = property.Price * 0.05m,
                    IdProperty = newPropertyId
                };
                traces.Add(propertyTrace);
            }

            return (owners, properties, images, traces);
        }
    }
}