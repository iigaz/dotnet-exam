using Shared.Models;

namespace Shared.Dto;

public record ResolvedEncounter(Monster Monster, List<Round> Rounds, bool Won)
{
}