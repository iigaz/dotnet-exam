using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Back.Services;

public class RandomMonsterChooser : IMonsterChooser
{
    private readonly AppDbContext _appDbContext;

    public RandomMonsterChooser(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Monster> ChooseAsync(Creature _)
    {
        return await _appDbContext.Monsters.Skip(new Random().Next(await _appDbContext.Monsters.CountAsync()))
            .FirstAsync();
    }
}