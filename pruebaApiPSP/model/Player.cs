using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace pruebaApiPSP.model;

public class Player
{
    public long Id { get; set; }
    [BsonElement("Name")]
    [JsonPropertyName("Name")]
    public string? Name { get; set; } = null!;
    public int MaxHp { get; set; }
    public int Hp { get; set; }
    public float[]? Position { get; set; }
    public Inventory[]? Inventory { get; set; }
}