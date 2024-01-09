using Shared.Models;

namespace Shared.Dto;

public class CreatureStats
{
    private readonly Creature _creature;

    public CreatureStats(Creature creature)
    {
        _creature = creature;
    }

    public int MinAcToAlwaysHit => 1 + _creature.AttackModifier;

    public int MinDamagePerRound =>
        _creature.AttacksPerRound * (_creature.DamageDieMultiplier + _creature.DamageModifier);

    public int MaxDamagePerRound => _creature.AttacksPerRound *
                                    (_creature.DamageDieSides * _creature.DamageDieMultiplier +
                                     _creature.DamageModifier); // The rules
    // TODO: Technically, if a creature makes a critical hit, the max damage can be doubled
}