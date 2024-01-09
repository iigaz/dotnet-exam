using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public class Creature
{
    public string Name { get; set; } = string.Empty;

    [Range(0, 999, ErrorMessage = "A creature can have no less than 0 and no more than 999 HP.")]
    public int HitPoints { get; set; }

    [Range(-20, 70, ErrorMessage = "A creature can have a modifier no less than -20 and no more than 70.")]
    public int AttackModifier { get; set; }

    [Range(0, 100, ErrorMessage = "A creature cannot make less than 0 or more than 100 attacks per round.")]
    public int AttacksPerRound { get; set; }

    [Range(1, 100, ErrorMessage = "A damage die multiplier cannot be less than 1 or more than 100.")]
    public int DamageDieMultiplier { get; set; }

    [Range(2, 100, ErrorMessage = "A damage die cannot have less than 2 or more than 100 sides.")]
    public int DamageDieSides { get; set; }

    [Range(-20, 70, ErrorMessage = "The damage can have a modifier no less than -20 and no more than 70.")]
    public int DamageModifier { get; set; }

    [Range(1, 100, ErrorMessage = "AC cannot be less than 1 or more than 100.")]
    public int ArmorClass { get; set; }

    public Creature Clone()
    {
        return (Creature)MemberwiseClone();
    }
}