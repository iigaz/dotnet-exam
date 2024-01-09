using System.Text.Json.Serialization;

namespace Shared.Models;

public class Monster : Creature
{
    [JsonIgnore] public int Id { get; set; }
}