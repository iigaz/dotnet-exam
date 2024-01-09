using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Back;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Monster> Monsters { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Monster>().HasData(new Monster
        {
            Id = 1,
            Name = "Bonnie",
            HitPoints = 52,
            AttackModifier = 8,
            AttacksPerRound = 2,
            DamageDieMultiplier = 1,
            DamageDieSides = 6,
            DamageModifier = 4,
            ArmorClass = 14
        }, new Monster
        {
            Id = 2,
            Name = "Ashann",
            HitPoints = 91,
            AttackModifier = 10,
            AttacksPerRound = 2,
            DamageDieMultiplier = 3,
            DamageDieSides = 10,
            DamageModifier = 4,
            ArmorClass = 12
        }, new Monster
        {
            Id = 3,
            Name = "Dryad",
            HitPoints = 22,
            AttackModifier = 4,
            AttacksPerRound = 1,
            DamageDieMultiplier = 1,
            DamageDieSides = 4,
            DamageModifier = 0,
            ArmorClass = 11
        });
    }
}