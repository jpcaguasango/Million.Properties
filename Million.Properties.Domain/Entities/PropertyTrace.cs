using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Million.Properties.Domain.Entities;

public record PropertyTrace
{
    [JsonPropertyName("_id")]
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public required string IdPropertyTrace { get; set; }
    public DateTime DateSale { get; set; }
    public string? Name { get; set; }
    public decimal Value { get; set; }
    public decimal Tax { get; set; }
    
    [BsonRepresentation(BsonType.ObjectId)]
    public required string IdProperty { get; set; }
    public Property? Property { get; set; }
}
