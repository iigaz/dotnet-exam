using Shared.Models;

namespace Shared.Dto;

public record Turn(List<Attack> Attacks, Creature Creature)
{
}