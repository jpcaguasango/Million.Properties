using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace Million.Properties.Domain.Entities;

public record PropertyImage
{
    [JsonPropertyName("_id")]
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public required string IdPropertyImage { get; set; }
    
    [BsonRepresentation(BsonType.ObjectId)]
    public required string IdProperty { get; set; }
    public string? file { get; set; }
    public bool Enabled { get; set; }
    public Property? Property { get; set; }
}
