using Shared.Dto;

namespace Back.Services;

public interface IEncounterResolver
{
    public ResolvedEncounter Resolve(Encounter encounter);
}