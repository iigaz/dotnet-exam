using Back.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Dto;
using Shared.Models;

namespace Back.Controllers;

[ApiController]
[Route("[controller]")]
public class EncounterController : ControllerBase
{
    private readonly IEncounterResolver _encounterResolver;
    private readonly IMonsterChooser _monsterChooser;

    public EncounterController(IMonsterChooser monsterChooser, IEncounterResolver encounterResolver)
    {
        _monsterChooser = monsterChooser;
        _encounterResolver = encounterResolver;
    }

    [HttpGet(Name = "GetEncounter")]
    public async Task<ResolvedEncounter> GetEncounterAsync([FromBody] Player player)
    {
        return _encounterResolver.Resolve(new Encounter(player, await _monsterChooser.ChooseAsync(player)));
    }
}