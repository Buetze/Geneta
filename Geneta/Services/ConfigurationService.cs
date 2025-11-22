using Geneta.Pages;
using Geneta.Simulation;
using Geneta.Simulation.Allel;

namespace Geneta.Services;

public class ConfigurationService
{
    public void MapConfiguration(ConfigurationFormModel configuration)
    {
        // Map the traits
        SimulationConfiguration.Traits = configuration.SelectedTraits;
        
        // Map the amount of children
        SimulationConfiguration.AmountOfChildren = (configuration.Amount.First(), configuration.Amount.Last());
        
        // Map the phenotype strategies
        foreach (var phenoStrategyType in configuration.PhenoMapping)
        {
            SimulationConfiguration.PhenoMapping[phenoStrategyType.Key] = PhenoStrategyFactory.Create(phenoStrategyType.Value);
        }
    }
}
