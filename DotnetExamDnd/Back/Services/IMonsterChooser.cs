using Shared.Models;

namespace Back.Services;

public interface IMonsterChooser
{
    public Task<Monster> ChooseAsync(Creature creature);
}