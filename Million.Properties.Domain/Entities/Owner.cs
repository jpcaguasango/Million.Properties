using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace Million.Properties.Domain.Entities;

public record Owner
{
    [JsonPropertyName("_id")]
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public required string IdOwner { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? Photo { get; set; }
    public DateTime Birthday { get; set; }
    public ICollection<Property>? Properties { get; set; }
}
