using Geneta.Services;
using Geneta.Simulation;
using Geneta.Simulation.Allel;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace Geneta.Pages;

public partial class ConfigurationPage : ComponentBase
{
    [Inject] public ConfigurationService ConfigurationService { get; set; }
    [Inject] public SimulationService SimulationService { get; set; }
    [Inject] public DialogService DialogService { get; set; }
    
    [SupplyParameterFromForm]
    private ConfigurationFormModel? Model { get; set; }

    protected override void OnInitialized() => Model ??= new();

    public void Save()
    {
        ConfigurationService.MapConfiguration(Model);
        SimulationService.CreateNewSimulation();
        SimulationService.GenerationIndex = 0;
        
        StateHasChanged();
        DialogService.Close();
        
    }
    
}

public record ConfigurationFormModel
{
    public Traits SelectedTraits { get; set; }

    public IEnumerable<int> Amount { get; set; } = new List<int>() {20, 25};
    
    public Dictionary<Traits, PhenoStrategyType> PhenoMapping { get; set; } = new();
}
public static class TraitsExtensions
{
    private static readonly Dictionary<Traits, string> DisplayNames = new()
    {
        { Traits.PetalColor, "Petal Color" },
        { Traits.PetalCount, "Petal Count" },
        { Traits.PetalWidth, "Petal Width" },
        { Traits.PetalLength, "Petal Length" },
        { Traits.PetalShape, "Petal Shape" },
        { Traits.CenterColor, "Center Color" }
    };

    public static string ToDisplayName(this Traits trait)
    {
        return DisplayNames.TryGetValue(trait, out var displayName) 
            ? displayName 
            : trait.ToString();
    }
}
