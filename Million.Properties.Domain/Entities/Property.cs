using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace Million.Properties.Domain.Entities;

public record Property
{
    [JsonPropertyName("_id")]
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public required string IdProperty { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public decimal Price { get; set; }
    public string? CodeInternal { get; set; }
    public int Year { get; set; }
    
    [BsonRepresentation(BsonType.ObjectId)]
    public required string IdOwner { get; set; }
    public Owner? Owner { get; set; }
    public ICollection<PropertyImage>? PropertyImages { get; set; }
    public ICollection<PropertyTrace>? PropertyTraces { get; set; }
}
