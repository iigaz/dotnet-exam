using System.Net.Mime;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared.Dto;
using Shared.Models;

namespace Front.Pages;

public class IndexModel : PageModel
{
    private readonly string _getEncounterUrl;

    private HttpClient _client;

    public IndexModel(IConfiguration configuration)
    {
        _client = new HttpClient();
        _getEncounterUrl = configuration.GetConnectionString("Back") + "Encounter/";
    }

    [BindProperty] public Player Player { get; set; } = new();
    public Monster? Monster { get; set; }

    public ResolvedEncounter? ResolvedEncounter { get; set; }
    // public CreatureStats? PlayerStats { get; set; }
    // public CreatureStats? MonsterStats { get; set; }

    public void OnGet()
    {
    }

    public async Task OnPostAsync()
    {
        if (!ModelState.IsValid)
            return;
        ResolvedEncounter = await JsonSerializer.DeserializeAsync<ResolvedEncounter>(
            await (await _client.SendAsync(new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                Content = new StringContent(JsonSerializer.Serialize(Player), Encoding.UTF8,
                    MediaTypeNames.Application.Json),
                RequestUri = new Uri(_getEncounterUrl)
            })).Content.ReadAsStreamAsync(), new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DictionaryKeyPolicy = JsonNamingPolicy.CamelCase
            }
        );
        if (ResolvedEncounter != null)
            Monster = ResolvedEncounter.Monster;
    }
}