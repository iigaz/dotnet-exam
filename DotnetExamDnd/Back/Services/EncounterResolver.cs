using Shared.Dto;
using Shared.Models;

namespace Back.Services;

public class EncounterResolver : IEncounterResolver
{
    public ResolvedEncounter Resolve(Encounter encounter)
    {
        var cloned = (Monster)encounter.Monster.Clone();
        var rounds = new List<Round>();
        while (encounter.Player.HitPoints > 0 && encounter.Monster.HitPoints > 0)
        {
            var turns = new List<Turn> { CreateTurn(encounter.Player, encounter.Monster) };
            if (encounter.Monster.HitPoints > 0)
                turns.Add(CreateTurn(encounter.Monster, encounter.Player));
            rounds.Add(new Round(rounds.Count + 1, turns));
        }

        return new ResolvedEncounter(cloned, rounds, encounter.Player.HitPoints > 0);
    }

    private static Turn CreateTurn(Creature attacker, Creature target)
    {
        var attacks = new List<Attack>();
        for (var i = 0; i < attacker.AttacksPerRound; i++)
        {
            var attack = new Attack(attacker, target);
            if (attack.IsHit) target.HitPoints -= attack.DamageDiceRoll!.Value + attacker.DamageModifier;
            attacks.Add(attack);

            if (target.HitPoints <= 0)
                break;
        }

        return new Turn(attacks, attacker.Clone());
    }
}