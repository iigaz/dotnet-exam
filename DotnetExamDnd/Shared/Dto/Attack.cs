using System.Text.Json.Serialization;
using Shared.Models;

namespace Shared.Dto;

public class Attack
{
    private static readonly Random _random = new();

    public Attack(Creature from, Creature to)
    {
        Attacker = from.Clone();
        Target = to.Clone();
        AttackDiceRoll = _random.Next(1, 21);
        IsHit = AttackDiceRoll != 1 &&
                (AttackDiceRoll + Attacker.AttackModifier >= Target.ArmorClass || AttackDiceRoll == 20);
        if (IsHit)
            DamageDiceRoll = Enumerable.Repeat(0, from.DamageDieMultiplier * (IsCritical ? 2 : 1))
                .Select(_ => _random.Next(1, from.DamageDieSides + 1)).Sum();
    }

    public Attack()
    {
        Attacker = null!;
        Target = null!;
    }

    public Creature Attacker { get; set; }
    public Creature Target { get; set; }
    public int AttackDiceRoll { get; set; }
    public bool IsHit { get; set; }

    [JsonIgnore] public bool IsMiss => !IsHit;

    [JsonIgnore] public bool IsCritical => AttackDiceRoll is 1 or 20;

    public int? DamageDiceRoll { get; set; }
}